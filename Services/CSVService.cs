using System.Globalization;
using CsvHelper;

public interface ICSVService
{
   public IEnumerable<T> ReadCSV<T>(string path);
}

public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSV<T>(string path)
    {
        var reader = new StreamReader(path);
        var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        var records = csv.GetRecords<T>();
        return records;
    }
}
