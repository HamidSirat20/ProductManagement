using ProductManagement.Domain.Models;
using System.Collections.ObjectModel;

namespace ProductManagement.Domain;

public class EmployeeService
{
    public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    public EmployeeService()
    {
        ReadEmployees();

    }

    private void ReadEmployees()
    {
        Employee emp1 = new Employee()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = 1234567890,
            Address = "123 Main St",
            Department = Department.Production,
            BaseSalary = 50000m
        };

        Employee emp2 = new Employee()
        {
            Id = 2,
            FirstName = "Jane",
            LastName = "Doe",
            PhoneNumber = 0987654321,
            Address = "456 Side St",
            Department = Department.Sales,
            BaseSalary = 55000m
        };

        Employee emp3 = new Employee()
        {
            Id = 3,
            FirstName = "Jim",
            LastName = "Beam",
            PhoneNumber = 1122334455,
            Address = "789 Wide St",
            Department = Department.Advertisement,
            BaseSalary = 52000m
        };

        Employee emp4 = new Employee()
        {
            Id = 4,
            FirstName = "Jill",
            LastName = "Hill",
            PhoneNumber = 9988776655,
            Address = "321 Narrow St",
            Department = Department.Management,
            BaseSalary = 60000m
        };
       
        Employees.Add(emp1);
        Employees.Add(emp2);
        Employees.Add(emp3);
        Employees.Add(emp4);
       


    }
    public void AddEmployee(Employee employee)
    {
        if (employee == null)
        {
            return;
        }
        else if (Employees.FirstOrDefault(i => i.Id == employee.Id) is not null)
        {
            Console.WriteLine("Already exist!");
        }
        Employees.Add(employee);
    }
    public void RemoveEmployee(int id)
    {
        if (id == null)
        {
            return;
        }
        var foundEmployee = Employees.FirstOrDefault(p => p.Id == id);
        if (foundEmployee == null)
        {
            Console.WriteLine("No such product found!");
        }
        if (foundEmployee != null)
        {
            Employees.Remove(foundEmployee);
        }
    }
    public void EditEmployee(Employee employee)
    {
        var oldProduct = Employees.First(t => t.Id == employee.Id);
        int index = Employees.IndexOf(oldProduct);
        Employees[index] = employee;
    }
    public int GetNextId()
    {
        int index = Employees.Any() ? Employees.Max(p => p.Id) + 1 : 1;
        return index;
    }
}
