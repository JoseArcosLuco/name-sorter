using System;
using System.Collections.Generic;
using System.IO;

namespace name_sorter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting unsorted-names-list!");
            string pathIn = @"C:\\temp\unsorted-names-list.txt";
            string pathOut = @"C:\\temp\sorted-names-list.txt";
            List<string> dataOut = Read(pathIn);
            dataOut.Sort();
            Console.WriteLine("Data sort!");
            foreach (string linea in dataOut)
            {
                //Console.WriteLine("Starting unsorted-names-list!");
                Console.WriteLine(linea);
                //listBox1.Items.Add(linea);
            }
            CreateOut(pathOut, dataOut);
        }
        public static List<string> Read(string pathIn)
        {
            List<string> data = new List<string>();
            //Pass the file path and file name to the StreamReader constructor
            using (StreamReader sr = new StreamReader(pathIn))
            {
                while (sr.EndOfStream == false)
                {
                    data.Add(sr.ReadLine());
                }
            }
            return data;
        }
        public static void CreateOut(string path, List<string> data)
        {
            try
            {
                data.Sort();
                if (File.Exists(path)) {
                    File.Delete(path);
                }
                using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
                {
                    foreach (var line in data)
                    {
                        sw.WriteLine(line);

                    }
                    sw.Close();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message.ToString());
            }
            
            
        }
    }
}
