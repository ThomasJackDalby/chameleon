using Chameleon.Fractals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon
{
    public static class CalculationManager
    {
        public static void Calculate(params string[] args)
        {
            try
            {
                FractalInputs inputs = FractalInputs.FromDefaults();
                inputs.ApplyOverrides(args.Skip(1).ToArray());
                if (inputs.SaveInputsFileName != null) inputs.SaveInputsFile(inputs.SaveInputsFileName);
                  
                int actualWidth = (int)Math.Round(inputs.IdealWidth * inputs.Scale);
                int actualHeight = (int)Math.Round(inputs.IdealHeight * inputs.Scale);
                double[] topLeft = { -inputs.Side * 0.5 + inputs.Origin[0], -inputs.Side * 0.5 * ((double)inputs.IdealHeight / (double)inputs.IdealWidth) + inputs.Origin[1] };

                double[] xRange = new double[] { topLeft[0], actualWidth, topLeft[0] + inputs.Side, inputs.Side / actualWidth };
                double[] yRange = new double[] { topLeft[1], actualHeight, topLeft[1] + inputs.Side * actualHeight / actualWidth, (inputs.Side * actualHeight / actualWidth) / actualHeight };
                double[,] data;

                Console.WriteLine("Calculating fractal..");

                List<double[][]> groups = new List<double[][]>();
                int numberOfGroups = 10;
                int xGroupSteps = (int)Math.Floor(xRange[1] / numberOfGroups);
                int yGroupSteps = (int)Math.Floor(yRange[1] / numberOfGroups);
                double xGroupDelta = (xRange[2] - xRange[0]) / numberOfGroups;
                double yGroupDelta = (yRange[2] - yRange[0]) / numberOfGroups;

                Console.WriteLine("Minimum x steps per group: {0}", xGroupSteps);
                Console.WriteLine("Minimum y steps per group: {0}", yGroupSteps);

                for (int i = 0; i < numberOfGroups; i++)
                {
                    for (int j = 0; j < numberOfGroups; j++)
                    {
                        double[] subXRange = { xRange[0] + i * xGroupDelta, xRange[0] + (i + 1) * xGroupDelta, i };
                        double[] subYRange = { yRange[0] + j * yGroupDelta, yRange[0] + (j + 1) * yGroupDelta, j };
                        groups.Add(new double[][] { subXRange, subYRange });
                    }
                }

                data = new double[(int)xRange[1], (int)yRange[1]];
                double percentageComplete = 0;

                IFractal fractal = FractalLibrary.GetFractal(inputs.FractalName, inputs.FractalArgs);
                if (fractal == null) throw new Exception("We don't have a fractal that goes by that name..");

                Parallel.ForEach(groups, group =>
                {
                    double[] subXRange = group[0];
                    double[] subYRange = group[1];

                    double xSubDelta = (subXRange[2] - subXRange[0]) / subXRange[1];
                    double ySubDelta = (subYRange[2] - subYRange[0]) / subYRange[1];

                    int[] groupOrigin = { (int)subXRange[2] * xGroupSteps, (int)subYRange[2] * yGroupSteps };

                    for (int iX = 0; iX < xGroupSteps; iX++)
                    {
                        for (int iY = 0; iY < yGroupSteps; iY++)
                        {
                            double x = subXRange[0] + xRange[3] * iX;
                            double y = subYRange[0] + yRange[3] * iY;

                            int sX = iX + groupOrigin[0];
                            int sY = iY + groupOrigin[1];
                            data[sX, sY] = fractal.Process(x, y);
                        }
                    }
                    percentageComplete += 1.0 / (numberOfGroups * numberOfGroups);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write("{0, 2:##.}% ", percentageComplete * 100);
                });
                Console.Write("\n");

                FileManager.SaveBinary(inputs.OutputName + ".bin", data);
            }
            catch (Exception e) { throw new Exception("Messed up the calculations somehow :/", e); }
        }
    }
}
