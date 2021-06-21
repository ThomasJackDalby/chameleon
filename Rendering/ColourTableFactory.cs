using System;

namespace Chameleon
{
    public static class ColourTableFactory
	{
		public static int[][] Create(string name, string[] args)
		{
			if (name == "gradient") return CreateGradient(args);
			else if (name == "grayscale") return BasicGrayScale(args);
			else return null;
		}

		public static int[][] CreateGradient(string[] args)
		{
			int i = 0;
			int length = int.Parse(args[i++]);

			int r1 = int.Parse(args[i++]);
			int g1 = int.Parse(args[i++]);
			int b1 = int.Parse(args[i++]);

			int r2 = int.Parse(args[i++]);
			int g2 = int.Parse(args[i++]);
			int b2 = int.Parse(args[i++]);

			int[] c1 = { r1, g1, b1 };
			int[] c2 = { r2, g2, b2 }; 

			int[][] colourTable = new int[length][];

			double[] del = { 0, 0, 0 };
			for(int j=0;j<3;j++)
			{
				del[j] = (c2[j] - c1[j]) / (double)length;
			}

			Console.WriteLine("del r: " + del[0] + "g: " + del[1] + "b: " + del[2]); 
 
			for(int j=0;j<length;j++)
			{
				int[] colour = { 0, 0, 0 };
				for(int k=0;k<3;k++)
				{
					colour[k] = (int)(c1[k] + j*del[k]);
				}
				colourTable[j] = colour;
			}
			return colourTable;
		}
		public static int[][] BasicGrayScale(string[] args)
		{
			int[][] colourTable = new int[255][];
			for(int i=0;i<255;i++) colourTable[i] = new int[] { i, i, i };
			return colourTable;
		}
	}
}
