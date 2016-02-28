using System;
using System.Text;

namespace Chameleon
{
	public static class DoubleArrayExtensions
	{
		public static void DisplayMap(double[,] map)
		{
			for(int i=0;i<map.GetLength(0);i++)
			{
				StringBuilder sb = new StringBuilder();
				for(int j=0;j<map.GetLength(1);j++)
				{
					sb.Append(String.Format("{0, 3}", map[i,j]));
				}
				Console.WriteLine(sb.ToString());
			}
		}
		public static double Max(double[,] map)
		{
			double max = double.MinValue;
			for(int i=0;i<map.GetLength(0);i++)
			{
				for(int j=0;j<map.GetLength(1);j++)
				{
					if (map[i,j] > max) max = map[i,j];
				}
			}
			return max;
		}
		public static double Min(double[,] map)
		{
			double min = double.MaxValue;
			for(int i=0;i<map.GetLength(0);i++)
			{
				for(int j=0;j<map.GetLength(1);j++)
				{
					if (map[i,j] < min) min = map[i,j];
				}
			}
			return min;
		}

	}
}
