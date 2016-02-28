using System;

namespace Chameleon
{
	public interface IColourMapping
	{
		int[] GetColour(double value);
	}
}
