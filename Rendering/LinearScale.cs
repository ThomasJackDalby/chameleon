using System;

namespace Chameleon
{
	public class LinearScale : IColourMapping
	{
		public double Cy { get;set; }
		public double Cx { get;set; }
	 	public double M { get; set; }	
		
		public int[][] ColourTable { get; set; }

		public bool Loop { get; set; }	
		public bool Mirror { get; set; }	


		public LinearScale(string[] args, int[][] colourTable)
		{
			int i = 0;	
			double minV = double.Parse(args[i++]);
			double maxV = double.Parse(args[i++]);
			Loop = bool.Parse(args[i++]);
			ColourTable = colourTable;

			// Setup the Value to Index transform
			M = ColourTable.Length / (maxV - minV);
			Cy = 0;
			Cx = minV;
		}

		public int[] GetColour(double value)
		{
			int index = (int) ( M * (value - Cx) + Cy);
			if (value == double.PositiveInfinity || value == double.NegativeInfinity) index = int.MaxValue;

			if (Loop)
			{
				if (Mirror)
				{
					if (index < 0) index = index * -1;	
				}
				else
				{
					
				}
				if (index >= ColourTable.Length) index = index % ColourTable.Length;
			}

			if (index < 0) index = 0;
			if (index >= ColourTable.Length)  index = ColourTable.Length - 1;

			return ColourTable[index];
		}
	}
}
