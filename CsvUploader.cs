using CsvHelper;
using System.Globalization;

namespace CsvToDatabase;
public class CsvUploader
{
    public static async Task<List<Employee>> ReadEmployeesFromCsvAsync(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecordsAsync<Employee>();
        return await records.ToListAsync();
    }

    public static async Task<List<Department>> ReadDepartmentsFromCsvAsync(string filePath)
    {
        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecordsAsync<Department>();
        return await records.ToListAsync();
    }

    public static async Task UploadDataAsync(AppDbContext context, List<Employee> employees, List<Department> departments)
    {
        LogUpload($"Uploading {employees.Count} employees and {departments.Count} departments to the database.");

        await context.Employees.AddRangeAsync(employees);
        await context.Departments.AddRangeAsync(departments);
        await context.SaveChangesAsync();

        LogUpload("Upload to database completed.");
    }

    public static void LogUpload(string message)
    {
        File.AppendAllText("upload_log.txt", $"{DateTime.Now}: {message}\n");
    }
}
