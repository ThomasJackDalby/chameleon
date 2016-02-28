using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon
{
    public class FractalInputs
    {
        public double[] Origin { get; set; }
        public double Side { get; set; }
        public int IdealWidth { get; set; }
        public int IdealHeight { get; set; }
        public double Scale { get; set; }
        public string FractalName { get; set; }
        public string[] FractalArgs { get; set; }
        public string OutputName { get; set; }
        public string SaveInputsFileName { get; set; }

        public void ApplyOverrides(params string[] args)
        {
            for(int i=0;i<args.Length;i++)
            {
                string[] prop = args[i].Split(':');
                ApplyOverride(prop);
            }
        }
        public void ApplyOverride(string[] prop)
        {
            if (prop[0] == "ox") Origin[0] = double.Parse(prop[1]);
            else if (prop[0] == "oy") Origin[1] = double.Parse(prop[1]);
            else if (prop[0] == "side") Side = double.Parse(prop[1]);
            else if (prop[0] == "w") IdealWidth = int.Parse(prop[1]);
            else if (prop[0] == "h") IdealHeight = int.Parse(prop[1]);
            else if (prop[0] == "scale") Scale = double.Parse(prop[1]);
            else if (prop[0] == "fname") FractalName = prop[1];
            else if (prop[0] == "fargs") FractalArgs = prop[1].Split(',');
            else if (prop[0] == "load") loadInputsFile(prop[1]);
            else if (prop[0] == "save") SaveInputsFileName = prop[1];
            else if (prop[0] == "fout") OutputName = prop[1];
            else throw new Exception("Unknown calculation property");
        }
        private void loadInputsFile(string filename)
        {
            string[] data = File.ReadAllLines(filename);
            ApplyOverrides(data);
        }
        public void SaveInputsFile(string filename)
        {
            string[] contents = new string[10];
            int i = 0;
            contents[i++] = getTag("ox", Origin[0]);
            contents[i++] = getTag("oy", Origin[1]);
            contents[i++] = getTag("side", Side);
            contents[i++] = getTag("w", IdealWidth);
            contents[i++] = getTag("h", IdealHeight);
            contents[i++] = getTag("scale", Scale);
            contents[i++] = getTag("fname", FractalName);
            contents[i++] = getTag("fargs", FractalArgs);
            contents[i++] = getTag("fout", OutputName);
            File.WriteAllLines(filename, contents);
        }

        private string getTag(string property, object value)
        {
            return String.Format("{0}:{1}", property, value.ToString());
        }
        private string getTag(string property, object[] values)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < values.Length;i++ )
            {
                sb.Append(values[i]);
                if (i != values.Length - 1) sb.Append(",");
            }
            return String.Format("{0}:{1}", property, sb.ToString());
        }

        public static FractalInputs FromDefaults()
        {
            return new FractalInputs()
            {
                Origin = new double[] { 0, 0 },
                Side = 4,
                Scale = 1,
                IdealWidth = 1920,
                IdealHeight = 1024,
                FractalName = "mandelbrot",
                FractalArgs = new string[] { "2", "0", "0", "100" },
                OutputName = "fractal",
                SaveInputsFileName = null,
            };
        }


    }
}
