# CsvParser
Simple CSV File Parser.  

# Example
```cs
var csvString = "a,b,c\n1,2,3\n4,5,6\n";
var data = CsvParser.CsvReader.Read(csvString);
```
```cs
var csvString = "a,b,c\n1,2,3\n4,5,6\n";
var (header, data) = CsvParser.CsvReader.ReadHeaderAndData(csvString);
```
