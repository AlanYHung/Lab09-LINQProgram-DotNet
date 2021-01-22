using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using LINQProgram.Classes;

namespace LINQProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "../../../data.json";
            string jsonSerial = File.ReadAllText(path);
            var root = JsonConvert.DeserializeObject<Root>(jsonSerial);
            int count = 1;



            // This Section Answers Question 1.
            Console.WriteLine("Output all of the neighborhoods in this data list (Final Total: 147 neighborhoods)\n");
            var query = from Feature in root.features
                        select Feature.properties.neighborhood;

            foreach (string neighborhood in query)
            {
                Console.WriteLine("{0}. {1}", count++, neighborhood);
            }
            PauseScreen();



            // This Section Answers Question 2.
            count = 1;
            Console.Clear();
            Console.WriteLine("Filter out all the neighborhoods that do not have any names (Final Total: 143)\n");
            query = from Feature in root.features
                    where Feature.properties.neighborhood != ""
                    select Feature.properties.neighborhood;

            foreach (string neighborhood in query)
            {
                Console.WriteLine("{0}. {1}", count++, neighborhood);
            }
            PauseScreen();



            // This Section Answers Question 3.
            count = 1;
            Console.Clear();
            Console.WriteLine("Remove the duplicates (Final Total: 39 neighborhoods)\n");
            // The Distinct() method removes all the duplicate neighborhoods and stores them into a new variable
            IEnumerable<string> distinctNeighborhoods = query.Distinct();

            foreach (string neighborhood in distinctNeighborhoods)
            {
                Console.WriteLine("{0}. {1}", count++, neighborhood);
            }
            PauseScreen();



            // This Section Answers Question 4.
            count = 1;
            Console.Clear();
            Console.WriteLine("Rewrite the queries from above and consolidate all into one single query.)\n");
            distinctNeighborhoods = root.features
                .Where(feature => feature.properties.neighborhood != "")
                .Select(feature => feature.properties.neighborhood)
                .Distinct();

            foreach (string neighborhood in distinctNeighborhoods)
            {
                Console.WriteLine("{0}. {1}", count++, neighborhood);
            }
            PauseScreen();



            // This Section Answers Question 5.
            count = 1;
            Console.Clear();
            Console.WriteLine("Rewrite at least one of these questions only using the opposing method (example: Use LINQ Query statements instead of LINQ method calls and vice versa.)");
            Console.WriteLine("Filter out all the neighborhoods that do not have any names using LINQ Methods (Final Total: 143)\n");
            distinctNeighborhoods = root.features
                .Where(feature => feature.properties.neighborhood != "")
                .Select(feature => feature.properties.neighborhood);

            foreach (string neighborhood in query)
            {
                Console.WriteLine("{0}. {1}", count++, neighborhood);
            }
            PauseScreen();
        }

        static void PauseScreen()
        {
            Console.WriteLine("\n\nPlease press <enter> to continue...");
            Console.ReadKey();
        }
    }
}
