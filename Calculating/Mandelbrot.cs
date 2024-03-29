﻿using System;

namespace Chameleon.Fractals
{
    public class Mandelbrot : IFractal
    {
        public int IterationLimit { get; set; }
        public double[] C0 { get; set; }
        public int Power { get; set; }

		public Mandelbrot(string[] args)
		{ 
			Console.WriteLine("Created a Mandelbrot fractal");
		    Power = int.Parse(args[0]);
            C0 = new double[] { double.Parse(args[1]), double.Parse(args[2]) };
            IterationLimit = int.Parse(args[3]);
		}

        public double Process(double x, double y)
        {
            int iteration = 1;
            double[] zN = { 0, 0 };
			double[] c0 = { x, y };

            while (iteration < IterationLimit)
            {
                zN = ComplexNumberExtensions.Add(ComplexNumberExtensions.Power(zN, Power), c0);
                if (ComplexNumberExtensions.Magnitude(zN) > 2) break;
                iteration++;
            }
            return iteration;
        }
    }
}
