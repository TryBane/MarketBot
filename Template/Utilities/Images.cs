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
        public async Task<string> CreateImageAsync(SocketGuildUser user, string url = "https://images.unsplash.com/photo-1602408959965-cbde35cfab50?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=933&q=80")
        {
            var avatar = await FetchImageAsync(user.GetAvatarUrl(size: 2048, format: Discord.ImageFormat.Png) ?? user.GetDefaultAvatarUrl());
            var background = await FetchImageAsync(url);

            background = CropToBanner(background);
            avatar = ClipImageToCircle(avatar);

            var bitmap = avatar as Bitmap;
            bitmap?.MakeTransparent();

            var banner = CopyRegionIntoImage(bitmap, background);
            banner = DrawTextToImage(banner, $"{user.Username}#{user.Discriminator} joined the server", $"Member #{user.Guild.MemberCount}", background.Height / 2);

            string path = $"{Guid.NewGuid()}.png";
            banner.Save(path);
            return await Task.FromResult(path);
        }

        private static Bitmap CropToBanner(Image image)
        {
            var originalWidth = image.Width;
            var originalHeight = image.Height;
            var destinationSize = new Size(1100, 450);

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
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(image, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);

            return bitmap;
        }

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

        private Image CopyRegionIntoImage(Image source, Image destination, int offset = -100)
        {
            using var grD = Graphics.FromImage(destination);
            var x = (source.Width / 2) + offset;
            var y = (source.Height / 2) - 100;

            grD.DrawImage(source, x, y, source.Width, source.Height);
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

            var subheaderX = 35 + (header.Length * fontSize);
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

        public async Task<string> CreateRunewordImageAsync(List<Tuple<string,int,int>> affixes, string name, string slots, string runes, string url = "https://cdn.discordapp.com/attachments/881552119784681493/881598049397391380/oie_DeJvaQZt4aAb.PNG")
        {
            int imageRadius = 200;
            var helm = await FetchImageAsync("https://diablo2.wiki.fextralife.com/file/Diablo-2/skull_cap_helm_armor_diablo2_wiki_guide_196px.png");
            var shield = await FetchImageAsync("https://diablo2.wiki.fextralife.com/file/Diablo-2/buckler_shields_diablo2_wiki_guide_100x150px.png");
            var background = await FetchImageAsync(url);

            List<string> theSlots = new List<string>
            {
                "Helm",
                "Shield"
            };
            var headerFontSize = 60;
            var subFontSize = 38;
            int biggestSizeAffixText = 0;

            foreach(var thisAffix in affixes)
            {
                int textSize = (thisAffix.Item1.Length + thisAffix.Item2.ToString().Length + thisAffix.Item3.ToString().Length);
                biggestSizeAffixText = Math.Max(biggestSizeAffixText, textSize);
            }

            var width = ( Math.Max((((name.Length + runes.Length) * headerFontSize) + 20), biggestSizeAffixText * subFontSize));
            var height = headerFontSize + 20 + (affixes.Count * (subFontSize + 15));

            var size = new Size(width, height);

            Image banner = CropToRunewordBanner(background, size);

            // Need to loop for each type provided, separated by ,'s. Provide size of image as offset for next iteration
            int slotOffset = -100;
            //foreach (var thisSlot in theSlots)
            //{
            //    if (slots.Contains(thisSlot))
            //    {
            //        Bitmap bitmap;
            //        switch (thisSlot)
            //        {
            //            case "Helm":
            //                helm = ClipImageToCircle(helm, imageRadius);
            //                bitmap = helm as Bitmap;
            //                bitmap?.MakeTransparent();
            //
            //                banner = CopyRegionIntoImage(bitmap, tryThis, slotOffset);
            //
            //                break;
            //            case "Shield":
            //                shield = ClipImageToCircle(shield, imageRadius);
            //                bitmap = shield as Bitmap;
            //                bitmap?.MakeTransparent();
            //
            //                banner = CopyRegionIntoImage(bitmap, tryThis, slotOffset);
            //                break;
            //            default:
            //                break;
            //        }
            //        slotOffset += 200;
            //    }
            //}

            banner = DrawTextToImage(banner, $"{name}", $"{runes}",10, 0, "#7F5200", headerFontSize, "#ab3d0e");

            
            //foreach (var thisSlot in slotList)
            //{
            //    banner = CopyRegionIntoImage(thisSlot, banner, slotOffset);
            //    slotOffset -= imageRadius * 2;
            //}

            var offset = 100;
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
            background.Save(path);
            return await Task.FromResult(path);
        }

        private static Bitmap CropToRunewordBanner(Image image, Size size)
        {
            Image destination = new Bitmap(image.Width, image.Height, image.PixelFormat);
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

            Brush brush = new TextureBrush(destination);
            Pen thisPen = new Pen(brush);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(brush,destinationRectangle);
            //g.DrawRectangle(thisPen, destinationRectangle);

            g.DrawImage(image, destinationRectangle, sourceRectangle, GraphicsUnit.Pixel);

            return bitmap;
        }
    }
}

