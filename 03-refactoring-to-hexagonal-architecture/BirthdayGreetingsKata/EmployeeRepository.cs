using System.Collections.Generic;

namespace BirthdayGreetingsKata;

public interface EmployeeRepository {
    List<Employee> Get();
}