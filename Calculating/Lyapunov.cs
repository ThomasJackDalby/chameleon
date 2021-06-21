using System;

namespace Chameleon.Fractals
{
    public class Lyapunov : IFractal
    {
        public int IterationLimit { get; set; }
        public int[] Series { get; set; }

        public Lyapunov(string[] args)
        {
            Console.WriteLine("Created a Lyapunov fractal");
            string inputString = args[0];
            IterationLimit = int.Parse(args[1]);

            Series = new int[inputString.Length];
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] == '0') Series[i] = 0;
                else if (inputString[i] == '1') Series[i] = 1;
                else Series[i] = -1;
            }
        }

        public double Process(double x, double y)
        {
            double xN = 0.5;
            double lambda = 0;
            int N = IterationLimit;
            double[] zN = { x, y };

            for (int n = 0; n < N; n++)
            {
                double rn;
                if (Series[n % Series.Length] == 0) rn = zN[0];
                else rn = zN[1];

                xN = rn * xN * (1 - xN);
                lambda += Math.Log(Math.Abs(rn * (1 - 2 * xN)));
            }

            return lambda / N;
        }
    }
}
