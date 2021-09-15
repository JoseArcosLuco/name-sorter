using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            List<string> dataOutFinal = new List<string>();
            List<Person> dataOrder = new List<Person>();
            int dataOutRev;

            Console.WriteLine("Data sort!");

            string lineatemp = "";
            foreach (string linea in dataOut)
            {
                Person person = new Person();
                lineatemp = linea.Replace(" ", "-");
                dataOutRev = lineatemp.LastIndexOf("-");
                person.lastName = lineatemp.Substring(dataOutRev + 1);
                person.line = linea;
                person.lastIndex = dataOutRev;

                dataOrder.Add(person);
            }
            //order by lastName
            foreach (Person lineOut in dataOrder.OrderBy(person => person.lastName))
            {
                Console.WriteLine(lineOut.line);
                dataOutFinal.Add(lineOut.line);
            }

            //create a file final    
            CreateOut(pathOut, dataOutFinal);
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
        public class Person{
            public int lastIndex { get; set; }
            public string line { get; set; }
            public string lastName { get; set; }
            
        }
    }
}
