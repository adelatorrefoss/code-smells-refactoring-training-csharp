using System.Collections.Generic;
using System.IO;

namespace BirthdayGreetingsKata;

public class FileEmployeeRepository : EmployeeRepository {
    private readonly string fileName;

    public FileEmployeeRepository(string fileName) {
        this.fileName = fileName;
    }

    public List<Employee> Get() {
        using var reader = new StreamReader(fileName);
        var str = "";
        str = reader.ReadLine(); // skip header
        var employees = new List<Employee>();
        while ((str = reader.ReadLine()) != null) {
            var employeeData = str.Split(", ");
            var employee = new Employee(employeeData[1], employeeData[0],
                    employeeData[2], employeeData[3]);
            employees.Add(employee);
        }

        return employees;
    }
}