using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon.Rendering
{
    public static class ColourMappingFactory
    {
        public static IColourMapping Create(string name, string[] args, int[][] table)
        {
            if (name == "linear") return new LinearScale(args, table);
            else throw new Exception("Unknown colour mapping");
        }
    }
}
