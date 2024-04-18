using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the path to the directory containing SQL files:");
        string directoryPath = Console.ReadLine();

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Directory does not exist.");
            return;
        }

        var sqlFiles = Directory.GetFiles(directoryPath, "*.sql", SearchOption.AllDirectories);

        var records = new List<Record>();
        int totalLines = 0;
        int slNo = 1;

        foreach (var file in sqlFiles)
        {
            int lineCount = File.ReadLines(file).Count();
            totalLines += lineCount;
            records.Add(new Record
            {
                SlNo = slNo++,
                FileName = Path.GetFileName(file),
                NumberOfLines = lineCount,
                Path = file
            });
        }

        records.Add(new Record
        {
            SlNo = slNo,
            FileName = "Total",
            NumberOfLines = totalLines,
            Path = "N/A"
        });

        // Generate a timestamp for the file name
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        string outputFileName = Path.Combine(directoryPath, $"SqlFileScanResults_{timestamp}.csv");

        using (var writer = new StreamWriter(outputFileName))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(records);
        }

        Console.WriteLine($"CSV file has been created at: {outputFileName}");
    }
}

public class Record
{
    public int SlNo { get; set; }
    public string FileName { get; set; }
    public int NumberOfLines { get; set; }
    public string Path { get; set; }
}
