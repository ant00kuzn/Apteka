using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apteka
{
    public static class Captha
    {
        public static string captha = "";

        public static Bitmap Gena(int width, int height)
        {
            Random random = new Random();
            string chars = "qwertyuiopasdfghjklzxcvbnm1234567890";

            char[] gen = new char[4];

            for(int i = 0; i < 4; i++)
            {
                gen[i] = chars[random.Next(chars.Length)];
            }

            captha = new string(gen);

            return GenImage(width, height, captha);
        }

        public static Bitmap GenImage(int width, int height, string captha)
        {
            Random random = new Random();
            var bitmap = new Bitmap(width, height);

            using (var graph = Graphics.FromImage(bitmap))
            {
                graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graph.Clear(Color.White);

                for (int i = 0; i < width * height / 8; i++)
                {
                    var x = random.Next(width);
                    var y = random.Next(height);
                    var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                    bitmap.SetPixel(x, y, color);
                }

                var font = new Font("Times New Roman", 12, FontStyle.Strikeout);
                var brush = new SolidBrush(Color.Black);

                var position1 = new PointF(5, 15);
                var position2 = new PointF(45, 46);
                var position3 = new PointF(75, 10);
                var position4 = new PointF(105, 33);

                graph.DrawString(captha[0].ToString(), font, brush, position1);
                graph.DrawString(captha[1].ToString(), font, brush, position2);
                graph.DrawString(captha[2].ToString(), font, brush, position3);
                graph.DrawString(captha[3].ToString(), font, brush, position4);

                graph.Flush();
            }

            return bitmap;
        }
    }
}
