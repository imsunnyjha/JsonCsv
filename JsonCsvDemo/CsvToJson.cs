using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonCsvDemo
{
    class CsvToJson
    {
        public static void ImplementCSVToJSON()
        {
            string importFilePath = @"C:\Users\lenovo\source\repos\JsonCsvDemo\JsonCsvDemo\Address.csv";
            string exportFilePath = @"C:\Users\lenovo\source\repos\JsonCsvDemo\JsonCsvDemo\export.json";

            //reading file
            using (var reader = new StreamReader(importFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from address.csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine("\t" + addressData.firstname);
                    Console.WriteLine("\t" + addressData.lastname);
                    Console.WriteLine("\t" + addressData.address);
                    Console.WriteLine("\t" + addressData.city);
                    Console.WriteLine("\t" + addressData.state);
                    Console.WriteLine("\t" + addressData.code);
                    Console.WriteLine("\n");
                }
                Console.WriteLine("\t%%%%%%%%%%%%%%%% Now reading from csv file and write to csv file %%%%%%%%%%%%%%");


                //writing csv file
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw = new StreamWriter(exportFilePath))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
    }
}
