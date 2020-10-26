using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace JsonCsvDemo
{
    class CsvHandler
    {
        public static void ImplementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\lenovo\source\repos\JsonCsvDemo\JsonCsvDemo\Address.csv";
            string exportFilePath = @"C:\Users\lenovo\source\repos\JsonCsvDemo\JsonCsvDemo\export.csv";

            //reading file
            using (var reader=new StreamReader(importFilePath))
            using (var csv=new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from address.csv");
                foreach(AddressData addressData in records)
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
                using (var writer = new StreamWriter(exportFilePath))
                using (var csvExport = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }
            }
        }
    }
}
