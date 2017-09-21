using System;
using System.Diagnostics;
using System.Drawing;
namespace RefactorMe
{
   
    class Risovatel
    {
        public static int iteration = 0;
        static Bitmap image = new Bitmap(800, 600);
        static float x, y;
        static Graphics graphics;
        static public int b = 20;
        static public int a = 170;

        public static void Initialize()
        {
            image = new Bitmap(800, 600);
            graphics = Graphics.FromImage(image);
        }

        public static void SetPos(float x0, float y0)
        {
            x = x0;
            y = y0;
            Draw(b, a);
        }

        public static void Go(double L, double angle)
        {
            //Делает шаг длиной L в направлении angle и рисует пройденную траекторию
            Pen colorOfFigure = Pens.Red;
            var x1 = (float)(x + L * Math.Cos(angle));
            var y1 = (float)(y + L * Math.Sin(angle));
            graphics.DrawLine(colorOfFigure, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void ShowResult()
        {
            image.Save("result.bmp");
            Process.Start("result.bmp");
        }

        public static void Draw(double b, double a)
        {
            Go(a, Math.PI / 2 * iteration);
            Go(b * Math.Sqrt(2), Math.PI / 4 + Math.PI / 2 * iteration);
            Go(a, Math.PI + Math.PI / 2 * iteration);
            Go(a - (double)b, Math.PI / 2 * (iteration + 1));
            iteration++;
        }
    }

    public class StrangeThing
    {

        public static void Main()
        {
            Risovatel.Initialize();

            //Рисуем четыре одинаковые части невозможного квадрата.
            // Часть первая:
            Risovatel.SetPos(Risovatel.b, 0);

            // Часть вторая:
            Risovatel.SetPos(Risovatel.a + 2 * Risovatel.b, Risovatel.b);

            // Часть третья:
            Risovatel.SetPos(Risovatel.a + Risovatel.b, Risovatel.a + Risovatel.b * 2);

            // Часть четвертая:
            Risovatel.SetPos(0, Risovatel.a + Risovatel.b);

            Risovatel.ShowResult();
        }
    }
}