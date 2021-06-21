using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Chameleon
{
    public static class FileManager
    {
        public static void SaveBinary(string filename, double[,] data)
        {
            try
            {
                Stream s = File.Create(filename);
                BinaryWriter bw = new BinaryWriter(s);
                bw.Write(data.GetLength(0));
                bw.Write(data.GetLength(1));
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    for (int j = 0; j < data.GetLength(1); j++)
                    {
                        bw.Write(data[i, j]);
                    }
                }
                s.Close();
            }
            catch (Exception e) { throw new Exception("Failed to save binary as " + filename, e); }
        }
        public static double[,] LoadBinary(string filename)
        {
            try
            {
                Stream s = File.OpenRead(filename);
                BinaryReader br = new BinaryReader(s);
                int len0 = br.ReadInt32();
                int len1 = br.ReadInt32();
                double[,] data = new double[len0, len1];
                for (int i = 0; i < len0; i++)
                {
                    for (int j = 0; j < len1; j++)
                    {
                        data[i, j] = br.ReadDouble();
                    }
                }
                s.Close();
                return data;
            }
            catch (Exception e) { throw new Exception("Failed to load binary from " + filename, e); }
        }
        public static void SaveBitmap(string filename, Bitmap bitmap)
        {
            try { bitmap.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg); }
            catch (Exception e) { throw new Exception("Failed to save " + filename, e); }
        }

        public static Dictionary<string, string> LoadInputs(string filename)
        {
            string[] data = File.ReadAllLines(filename);
            return parseInputs(data);
        }
        private static Dictionary<string, string> parseInputs(string[] rawInputs)
        {
            Dictionary<string, string> inputs = new Dictionary<string, string>();
            for (int i = 0; i < rawInputs.Length; i++)
            {
                string[] prop = rawInputs[i].Split('=');
                inputs.Add(prop[0], prop[1]);
            }
            return inputs;
        }
    }
}
