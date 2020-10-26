using System;

namespace JsonCsvDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read data from csv>>>>>>>>>");
            CsvHandler.ImplementCSVDataHandling();
            CsvToJson.ImplementCSVToJSON();
        }
    }
}
