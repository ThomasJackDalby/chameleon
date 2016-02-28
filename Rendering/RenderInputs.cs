using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon
{
    public class RenderInputs
    {
        public string InputName { get; set; }
        public string OutputName { get; set; }
        public string ColourTableName { get; set; }
        public string[] ColourTableArgs { get; set; }
        public string ScaleName { get; set; }
        public string[] ScaleArgs { get; set; }

        public void ApplyOverride(string[] prop)
        {
            if (prop[0] == "cname") ColourTableName = prop[1];
            else if (prop[0] == "cargs") ColourTableArgs = prop[1].Split(',');
            else if (prop[0] == "sname") ScaleName = prop[1];
            else if (prop[0] == "sargs") ScaleArgs = prop[1].Split(',');
            else if (prop[0] == "fin") InputName = prop[1];
            else if (prop[0] == "fout") OutputName = prop[1];
            else throw new Exception(String.Format("Unknown render property \"{0}\"", prop[0]));
        }
        public void ApplyOverrides(params string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                string[] prop = args[i].Split(':');
                ApplyOverride(prop);
            }
        }
        private void loadInputsFile(string filename)
        {
            string[] data = File.ReadAllLines(filename);
            ApplyOverrides(data);
        }

        public static RenderInputs FromDefaults()
        {
            return new RenderInputs()
            {
                InputName = "fractal",
                OutputName = null,
                ColourTableName = "grayscale",
                ColourTableArgs = new string[] { " " },
                ScaleName = "linear",
                ScaleArgs = new string[] { "0", "255", "true" },
            };
        }
    }
}
