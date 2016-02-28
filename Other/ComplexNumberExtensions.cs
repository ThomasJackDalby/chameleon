using System;

namespace Chameleon
{
	public class ComplexNumberExtensions 
	{
		public static double[] Add(double[] a, double[] b)
		{
			return new double[] { a[0] + b[0], a[1] + b[1] };
		}	

		public static double[] Multiply(double[] a, double[] b)
		{
			return new double[] { a[0] * b[0] - a[1]*b[1], a[0]*b[1] + a[1]*b[0] };
		}

		public static double[] Multiply(double[] a, double c)
		{
			return Multiply(a, new double[] { c, 0 });
		}
		
		public static double Magnitude(double[]a)
		{
			return Math.Sqrt(a[0]*a[0] + a[1]*a[1]);
		}

		public static double[] Power(double[] a, int exp)
		{
            double[] result = { 1, 0 };
            while (exp > 0)
            {
                result = Multiply(result, a);
                exp--;
            }
            return result;
		}
	}
}
