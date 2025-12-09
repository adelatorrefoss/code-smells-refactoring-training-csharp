using System;
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
            var birthday = DateTime.ParseExact(employeeData[2], "yyyy/MM/dd", null);
            var employee = new Employee(employeeData[1], employeeData[0], employeeData[3],
                    new OurDate(birthday));
            employees.Add(employee);
        }

        return employees;
    }
}