using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon
{
    public static class ComplexTools
    {
        public static double[] Add(double[] a, double[] b)
        {
            return new double[] { a[0] + b[0], a[1] + b[1] };
        }
        public static double[] Multiply(double[] a, double[] b)
        {
            double[] c = new double[2];
            c[0] = a[0] * b[0] - a[1] * b[1];
            c[1] = a[0] * b[1] + a[1] * b[0];
            return c;
        }
        public static double[] Multiply(double[] a, double b)
        {
            double[] bA = { b, 0 };
            return Multiply(a, bA);
        }
        public static double[] Power(double[] c1, int exp)
        {
            double[] result = { 1, 0 };
            while (exp > 0)
            {
                result = Multiply(result, c1);
                exp--;
            }
            return result;
        }
        public static double Power(double num, int exp)
        {
            double result = 1.0;
            while (exp > 0)
            {
                if (exp % 2 == 1)
                    result *= num;
                exp >>= 1;
                num *= num;
            }

            return result;
        }
        public static double Weibull(double x, double l = 1, double k = 5)
        {
            if (x < 0) return 0;
            return 1 - Math.Pow(Math.E, -Math.Pow(x / l, k));
        }
        public static double Magnitude(double[] a)
        {
            return Math.Sqrt(a[0] * a[0] + a[1] * a[1]);
        }



        public static int Max(int[,] a)
        {
            int t = int.MinValue;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > t) t = a[i, j];
                }
            }
            return t;
        }




        public static int max(int[,] a)
        {
            int t = int.MinValue;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] > t) t = a[i, j];
                }
            }
            return t;
        }

        public static double[] lewisFractal(double[] z, double[] c, int p)
        {
            double[] result = z;
            result = add(result, multiply(power(z, 3), 1));
            result = add(result, multiply(power(z, 2), 1));
            result = add(result, multiply(z, 1));
            result = add(result, multiply(c, 1));
            return result;
        }
        public static double[] tomFractal(double[] z, double[] c, int p)
        {
            double[] result = z;
            result = add(result, power(z, 5));
            result = add(result, power(z, 2));
            result = add(result, multiply(c, 1));
            return result;
        }
        public static double[] add(double[] a, double[] b)
        {
            return new double[] { a[0] + b[0], a[1] + b[1] };
        }
        public static double[] multiply(double[] a, double[] b)
        {
            double[] c = new double[2];
            c[0] = a[0] * b[0] - a[1] * b[1];
            c[1] = a[0] * b[1] + a[1] * b[0];
            return c;
        }
        public static double[] multiply(double[] a, double b)
        {
            double[] bA = { b, 0 };
            return multiply(a, bA);
        }
        public static double[] power(double[] c1, int exp)
        {
            double[] result = { 1, 0 };
            while (exp > 0)
            {
                result = multiply(result, c1);
                exp--;
            }
            return result;
        }
        public static double power(double num, int exp)
        {
            double result = 1.0;
            while (exp > 0)
            {
                if (exp % 2 == 1)
                    result *= num;
                exp >>= 1;
                num *= num;
            }

            return result;
        }
        public static double weibull(double x, double l = 1, double k = 5)
        {
            if (x < 0) return 0;
            return 1 - Math.Pow(Math.E, -Math.Pow(x / l, k));
        }
    }
}
