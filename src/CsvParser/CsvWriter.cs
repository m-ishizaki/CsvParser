namespace RkSoftware.CsvParser;

public static class CsvWriter
{
    public static string Write(string[][] data) => _Write(data);

    public static string Write(string[] header, string[][] data) => Write(new string[][] { header }.Concat(data).ToArray());

    private static string _Write(string[][] data)
    {
        var sb = new System.Text.StringBuilder();
        foreach (var line in data ?? Array.Empty<string[]>())
            sb.Append(string.Join(",", line.Select(Escape)) + '\n');
        return sb.ToString();

        static string Escape(string cell) =>
            (cell.Contains('"') || cell.Contains('\'') || cell.Contains(',') || cell.Contains('\n'))
            ? $"\"{cell.Replace("\"", "\"\"")}\""
            : cell;
    }
}
