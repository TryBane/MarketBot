using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace Template.Utilities
{
    public class Images
    {
        private Image ClipImageToCircle(Image image, int imageRadius = 0)
        {
            Image destination = new Bitmap(image.Width, image.Height, image.PixelFormat);
            var radius = imageRadius > 0 ? imageRadius : image.Width / 2;
            var x = image.Width / 2;
            var y = image.Height / 2;

            using Graphics g = Graphics.FromImage(destination);
            var r = new Rectangle(x - radius, y - radius, radius * 2, radius * 2);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using(Brush brush = new SolidBrush(Color.Transparent))
            {
                g.FillRectangle(brush, 0, 0, destination.Width, destination.Height);
            }

            var path = new GraphicsPath();
            path.AddEllipse(r);
            g.SetClip(path);
            g.DrawImage(image, 0, 0);
            return destination;
        }

        private Image CopyRegionIntoImage(Image source, Image destination, int offset = 0, int imageRadius = 200)
        {
            using var grD = Graphics.FromImage(destination);
            var x = offset;
            var y = 0;
            var sourRect = new Rectangle(0, 0, source.Width, source.Height);
            Rectangle destRect;

            destRect = new Rectangle(x, y, (int)(imageRadius * source.Width / source.Height), imageRadius);

            grD.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            grD.DrawImage(source, destRect, sourRect,GraphicsUnit.Pixel);
            return destination; 
        }

        private Image DrawTextToImage(Image image, string header, string subheader, int yOffset, int textOffset = 0, string textColor = "#FFFFFF", int fontSize = 38, string subColor = "#CCCCCC")
        {
            var myFont = new PrivateFontCollection();
            

            var roboto = new Font("Exocet", fontSize, FontStyle.Regular);
            var robotoSmall = new Font("Exocet", fontSize, FontStyle.Regular);

            var brushWhite = new SolidBrush(ColorTranslator.FromHtml(textColor));
            var brushGrey = new SolidBrush(ColorTranslator.FromHtml(subColor));

            var headerX = 35;
            var headerY = yOffset + textOffset;

            var subheaderX = (float)(35 + ((header.Length * fontSize) * .8));
            var subheaderY = yOffset + textOffset;

            var drawFormat = new StringFormat
            {
                LineAlignment = StringAlignment.Near,
                Alignment = StringAlignment.Near
            };

            using var GrD = Graphics.FromImage(image);
            GrD.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            if (header != "")
            {
                GrD.DrawString(header, roboto, brushWhite, headerX, headerY, drawFormat);
            }
            GrD.DrawString(subheader, robotoSmall, brushGrey, subheaderX, subheaderY, drawFormat);

            var img = new Bitmap(image);
            return img;
        }

        private async Task<Image> FetchImageAsync(string url)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if(!response.IsSuccessStatusCode)
            {
                var backupResponse = await client.GetAsync("https://images.unsplash.com/photo-1500829243541-74b677fecc30?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=1955&q=80");
                var backupStream = await backupResponse.Content.ReadAsStreamAsync();
                return Image.FromStream(backupStream);
            }

            var stream = await response.Content.ReadAsStreamAsync();
            return Image.FromStream(stream);
        }
        private async Task<string> CopyImage(string link, int radius, Image theBanner, int theOffset)
        {
            var image = await FetchImageAsync(link);
            image = ClipImageToCircle(image, radius);
            var bitmap = image as Bitmap;
            bitmap?.MakeTransparent();

            theBanner = CopyRegionIntoImage(bitmap, theBanner, theOffset, radius);
            return "0";
        }

        public async Task<string> CreateRunewordImageAsync(List<Tuple<string,int,int>> affixes, string name, string slots, string runes, string url = "https://cdn.discordapp.com/attachments/881552119784681493/881598049397391380/oie_DeJvaQZt4aAb.PNG")
        {
            int imageRadius = 196;

            var background = await FetchImageAsync(url);

            List<Image> slotList = new List<Image>();
            List<string> theSlots = new List<string>
            {
                "Helm",
                "Shield",
                "Armor",
                "Head",

                "Axe",
                "Bow",
                "Club",
                "Crossbow",
                "Dagger",
                "Hammer",
                "Javelin",
                "Katar",
                "Mace",
                "Orb",
                "Polearm",
                "Scepter",
                "Spear",
                "Staff",
                "Sword",
                "Wand",
                "All Weapons"
            };
            var headerFontSize = 60;
            var subFontSize = 38;
            int biggestSizeAffixText = 0;

            foreach(var thisAffix in affixes)
            {
                int textSize = (thisAffix.Item1.Length + thisAffix.Item2.ToString().Length + thisAffix.Item3.ToString().Length);
                biggestSizeAffixText = Math.Max(biggestSizeAffixText, textSize);
            }

            var width = (int) Math.Max(((name.Length + runes.Length) * headerFontSize * .65) + 35, (biggestSizeAffixText * subFontSize * .65) + 35);
            var height = headerFontSize + imageRadius + (affixes.Count * (subFontSize + 10)) + 40;

            var size = new Size(width, height);

            Image banner = CropToRunewordBanner(background, size);

            int slotOffset = 0;
            // Need to loop for each type provided, separated by ,'s. Provide size of image as offset for next iteration
            foreach (var thisSlot in theSlots)
            {
                if (slots.Contains(thisSlot))
                {
                    switch (thisSlot)
                    {
                        // Armors
                        case "Helm":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/full_helm_armor_diablo2_wiki_guide_196px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius - 40;
                            break;
                        case "Shield":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/buckler_shields_diablo2_wiki_guide_100x150px.png", imageRadius, banner, slotOffset);
                            slotOffset += (imageRadius * 2 / 3);
                            break;
                        case "Armor":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/leather_armor_diablo2_wiki_guide_196px.png", imageRadius, banner, slotOffset);
                            slotOffset += (imageRadius * 3 / 5);
                            break;
                        case "Head":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/unraveller_head_shrunken_heads_diablo2_wiki_guide2.png", imageRadius, banner, slotOffset);
                            slotOffset += (imageRadius / 5 * 2);
                            break;

                        // Weapons
                        case "Axe":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/axe_weapons_diablo_2_resurrected_wiki_guide.png", imageRadius, banner, slotOffset);
                            slotOffset += (int)(imageRadius / 2.5);
                            break;
                        case "Bow":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/hunters_bow_weapons_diablo_2_resurrected_wiki_guide.png", imageRadius, banner, slotOffset);
                            slotOffset += (imageRadius * 2 / 5);
                            break;
                        case "Club":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/club_weapons_diablo_2_wiki_guide_125px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 4;
                            break;
                        case "Crossbow":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/crossbow_weapons_diablo_2_resurrected_wiki_guide.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 2;
                            break;
                        case "Dagger":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/dagger_weapons_diablo_2_resurrected_wiki_guide.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 4;
                            break;
                        case "Hammer":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/maul_weapons_diablo_2_wiki_guide_125px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 3;
                            break;
                        case "Javelin":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/pilum_weapons_diablo_2_resurrected_wiki_guide.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 10;
                            break;
                        case "Katar":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/katar_diablo_2_wiki_guide_196px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 3;
                            break;
                        case "Mace":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/morning_star_weapon_diablo_2_resurrected_wiki_guide_125px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 4;
                            break;
                        case "Orb":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/sacred_globe_diablo_2_wiki_guide_196px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 3;
                            break;
                        case "Polearm":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/voulge_weapons_diablo_2_resurrected_wiki_guide_196px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 3;
                            break;
                        case "Scepter":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/grand_scepter_weapons_diablo_2_resurrected_wiki_guide_196xp.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 3;
                            break;
                        case "Spear":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/brandistock_weapons_diablo_2_resurrected_wiki_guide_201px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 4;
                            break;
                        case "Staff":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/long_staff_diablo_2_wiki_guide_125px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 6;
                            break;
                        case "Sword":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/crystal_sword_diablo_2_wiki_guide196px.png", imageRadius, banner, slotOffset);
                            slotOffset += imageRadius / 3;
                            break;
                        case "Wand":
                            await CopyImage("https://diablo2.wiki.fextralife.com/file/Diablo-2/bone_wand_diablo_2_wiki_guide_125px.png", imageRadius, banner, slotOffset);
                            break;
                        case "All Weapons":
                            break;
                        default:
                            break;
                    }
                }
            }

            var offset = 160;
            banner = DrawTextToImage(banner, $"{name}", $"{runes}",10, offset, "#7F5200", headerFontSize, "#ab3d0e");

            //foreach (var thisSlot in slotList)
            //{
            //    banner = CopyRegionIntoImage(thisSlot, banner, slotOffset);
            //    slotOffset -= imageRadius * 2;
            //}

            offset += 100;
            foreach (var thisAffix in affixes)
            {
                string textColor = "#FFFFFF";
                if(thisAffix.Item3 != 0)
                {
                    textColor = "#4169E1";

                    banner = DrawTextToImage(banner, $"{thisAffix.Item2}-{thisAffix.Item3}", $"{thisAffix.Item1}", 10, offset, textColor);
                    offset += subFontSize + 10;
                    continue;
                }
                if (thisAffix.Item2 != 0)
                {
                    banner = DrawTextToImage(banner, $"{thisAffix.Item2}", $"{thisAffix.Item1}", 10, offset, textColor);
                    offset += subFontSize + 10;
                    continue;
                }
                banner = DrawTextToImage(banner, $"", $"{thisAffix.Item1}", 10, offset, textColor);
                offset += subFontSize + 10;
            }
            string path = $"{Guid.NewGuid()}.png";
            banner.Save(path);
            return await Task.FromResult(path);
        }

        private static Bitmap CropToRunewordBanner(Image image, Size size)
        {
            var originalWidth = image.Width;
            var originalHeight = image.Height;
            var destinationSize = size;

            var heightRatio = (float)originalHeight / destinationSize.Height;
            var widthRatio = (float)originalWidth / destinationSize.Width;

            var ratio = Math.Min(heightRatio, widthRatio);

            var heightScale = Convert.ToInt32(destinationSize.Height * ratio);
            var widthScale = Convert.ToInt32(destinationSize.Width * ratio);

            var startX = (originalWidth - widthScale) / 2;
            var startY = (originalHeight - heightScale) / 2;

            var sourceRectangle = new Rectangle(startX, startY, widthScale, heightScale);
            var bitmap = new Bitmap(destinationSize.Width, destinationSize.Height);
            var destinationRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

            using var g = Graphics.FromImage(bitmap);

            Brush brush = new TextureBrush(image);
            Pen pen = new Pen(brush);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            //g.DrawImage(image, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);
            g.FillRectangle(brush, destinationRectangle);
            g.DrawRectangle(pen, destinationRectangle);

            return bitmap;
        }
    }
}

