using CsvToDatabase;

var context = new AppDbContext();

CsvUploader.LogUpload("Bulk upload of employee and department details started.");

var employeeTask = CsvUploader.ReadEmployeesFromCsvAsync("D:\\Assignments\\Assignment3\\employees.csv");
var departmentTask = CsvUploader.ReadDepartmentsFromCsvAsync("D:\\Assignments\\Assignment3\\departments.csv");

var employees = await employeeTask;
var departments = await departmentTask;

await CsvUploader.UploadDataAsync(context, employees, departments);

CsvUploader.LogUpload("Bulk upload of employee and department details completed.");

Console.WriteLine("Bulk upload completed.");