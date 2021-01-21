using System;
using Newtonsoft.Json;
using System.IO;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../data.json";
            Console.WriteLine(JsonConvert.SerializeObject(File.ReadAllLines(path)));
        }
    }
}
