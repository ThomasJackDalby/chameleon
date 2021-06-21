using Chameleon.Rendering;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace Chameleon
{
    public class RenderManager
    {
        public static void Render(params string[] args)
        {
            try
            {
                RenderInputs inputs = RenderInputs.FromDefaults();
                inputs.ApplyOverrides(args.Skip(1).ToArray());

                double[,] data = FileManager.LoadBinary(inputs.InputName + ".bin");

                Bitmap bitmap = renderFractal(data, inputs);

                string name = inputs.OutputName;
                if (name == null) name = inputs.InputName;

                FileManager.SaveBitmap(name + ".jpg", bitmap);
            }
            catch (Exception e) { throw new Exception("Came unstuck rendering", e); }
        }

        private static Bitmap renderFractal(double[,] data, RenderInputs inputs)
        {
            try
            {
                Console.WriteLine("Rendering..");

                int width = data.GetLength(0);
                int height = data.GetLength(1);

                // Set the colour table and mapping
                //int[][] colourTable = ColourTableFactory.Create(ColourTableName, ColourTableArgs);
                int[][] colourTable = ColourTableFactory.Create(inputs.ColourTableName, inputs.ColourTableArgs);


                IColourMapping map = ColourMappingFactory.Create(inputs.ScaleName, inputs.ScaleArgs, colourTable);

                Bitmap bitmap = new Bitmap(width, height);
                for (int iX = 0; iX < width; iX++)
                {
                    for (int iY = 0; iY < height; iY++)
                    {
                        int[] c = map.GetColour(data[iX, iY]);
                        bitmap.SetPixel(iX, iY, Color.FromArgb(255, c[0], c[1], c[2]));
                    }
                }
                return bitmap;
            }
            catch (Exception e) { throw new Exception("Messed up rendering the damn thing.", e); }
        }
        //public static Bitmap addGridlines(Bitmap input)
        //{
        //    try
        //    {
        //        int numberOfGridlines = 10;
        //        int grdDP = 3;

        //        Bitmap bitmap = (Bitmap)input.Clone();

        //        Pen pRed = new Pen(Brushes.Red, 0.1f);
        //        Pen pGreen = new Pen(Brushes.Green, 0.1f);

        //        Font arialFont = new Font("Arial", 10);
        //        Graphics g = Graphics.FromImage(bitmap);

        //        int gap = (int)(xRange[1] * (1.0 / numberOfGridlines));
        //        for (int iX = 0; iX < xRange[1]; iX += gap)
        //        {
        //            g.DrawString(String.Format("({0:N" + grdDP + "},{1:N" + grdDP + "})", iX * xRange[3] + xRange[0], yRange[0]), arialFont, Brushes.Red, new Point(iX, 0));
        //            g.DrawLine(pRed, new Point(iX, 0), new Point(iX, (int)yRange[1]));
        //        }
        //        for (int iY = 0; iY < yRange[1]; iY += gap)
        //        {
        //            g.DrawString(String.Format("({0:N" + grdDP + "},{1:N" + grdDP + "})", xRange[0], iY * yRange[3] + yRange[0]), arialFont, Brushes.Red, new Point(0, iY));
        //            g.DrawLine(pRed, new Point(0, iY), new Point((int)xRange[1], iY));
        //        }

        //        // Draw centrelines
        //        g.DrawLine(pGreen, new Point(0, (int)yRange[1] / 2), new Point((int)xRange[1], (int)yRange[1] / 2));
        //        g.DrawLine(pGreen, new Point((int)xRange[1] / 2, 0), new Point((int)xRange[1] / 2, (int)yRange[1]));
        //        g.DrawString(String.Format("({0:N" + grdDP + "},{1:N" + grdDP + "})", xRange[0] + (int)xRange[1] / 2 * xRange[3], (int)yRange[1] / 2 * yRange[3] + yRange[0]), arialFont, Brushes.Green, new Point((int)xRange[1] / 2, (int)yRange[1] / 2));

        //        return bitmap;
        //    }
        //    catch (Exception e) { throw new Exception("Error when trying to apply gridlines.", e); }
        //}
        private void showBitmap(string filename)
        {
            try { Process.Start(filename); }
            catch (Exception e) { throw new Exception("Unable to display IT", e); }
        }
    }
}
