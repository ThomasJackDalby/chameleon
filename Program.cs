using System;

namespace Chameleon
{
    public class Program
	{
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0) 
                {
                    showHelp();
                    return;
                }
                else
                {
                    string mode = args[0];
                    switch (mode)
                    {
                        case "-calc":
                            CalculationManager.Calculate(args);     
                            break;
                        case "-render":
                            RenderManager.Render(args);
                            break;
                        default:
                            Console.WriteLine("Unknown command \"{0}\"", mode);
                            return;
                    }
                }             
            }
            catch (Exception e)
            {
                Tools.DealWithPoorCoding(e);
            }
        }

        private static void showHelp()
        {
            Console.WriteLine("BWAHAHAHAHA THERE IS NO HELP!");
            Console.ReadLine();
        }
	}
}
