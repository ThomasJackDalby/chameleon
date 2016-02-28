using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chameleon
{
    public static class Tools
    {
        public static string GetPath(string directory, string name)
        {
            if (directory == "") return name;
            return String.Format("{0}//{1}", directory, name);
        }
        public static void DealWithPoorCoding(Exception e)
        {
            Console.WriteLine("Something didn't quite go to plan... :(");
            while (e.InnerException != null)
            {
                Console.WriteLine(e.Message);
                e = e.InnerException;
            }
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }

        //    Console.WriteLine("Loading inputs..");
        //    string[] data = File.ReadAllLines(filename);
        //    for(int i=0;i<data.Length;i++)
        //    {
        //        string[] prop = data[i].Split(':');

        //        if (prop[0] == "ox") Origin[0] = double.Parse(prop[1]);
        //        else if (prop[0] == "oy") Origin[1] = double.Parse(prop[1]);
        //        else if (prop[0] == "side") Side = double.Parse(prop[1]);
        //        else if (prop[0] == "w") IdealWidth = int.Parse(prop[1]);
        //        else if (prop[0] == "h") IdealHeight = int.Parse(prop[1]);
        //        else if (prop[0] == "scale") Scale = double.Parse(prop[1]);
        //        else if (prop[0] == "fname") FractalName = prop[1]; 
        //        else if (prop[0] == "fargs") FractalArgs = prop[1].Split(',');
        //        else if (prop[0] == "cname") ColourTableName = prop[1];
        //        else if (prop[0] == "cargs") ColourTableArgs = prop[1].Split(',');
        //        else if (prop[0] == "sname") ScaleName = prop[1];
        //        else if (prop[0] == "sargs") ScaleArgs = prop[1].Split(',');
        //    }
    }
}
