using System;

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
    }
}
