using ProductManagement.Domain.Models;
using System.Collections.ObjectModel;

namespace ProductManagement.Domain;

public class EmployeeService
{
    private string path = @"./DBEmployee.csv";
    public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    public EmployeeService()
    {
        ReadEmployees();

    }

    private void ReadEmployees()
    {
       using (var reader = new StreamReader(path))
        {
            Employees.Clear();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                Enum.TryParse(values[5],out Department department);
                Employee emp = new Employee()
                {
                    Id = Convert.ToInt32(values[0]),
                    FirstName = values[1],
                    LastName = values[2],
                    PhoneNumber = Convert.ToUInt64(values[3]),
                    Address = values[4],
                    Department =department,
                    BaseSalary = Convert.ToDecimal(values[6])
                };
                Employees.Add(emp);
            }
        }
    }
    private void SaveEmployees()
    {
        using (var writer = new StreamWriter(path))
        {
            foreach (var employee in Employees)
            {
                string Id = employee.Id.ToString();
                string FirstName = employee.FirstName;
                string LastName = employee.LastName;
                string PhoneNumber = employee.PhoneNumber.ToString();
                string Address = employee.Address;
                string Department = employee.Department.ToString();
                string baseSalary = employee.BaseSalary.ToString();
                string line = string.Format("{0};{1};{2};{3};{4};{5};{6}",Id,FirstName,LastName,PhoneNumber,Address,Department,baseSalary);
                writer.WriteLine(line);
            }
        }
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
        SaveEmployees();
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
        SaveEmployees() ;
    }
    public void EditEmployee(Employee employee)
    {
        var oldProduct = Employees.First(t => t.Id == employee.Id);
        int index = Employees.IndexOf(oldProduct);
        Employees[index] = employee;
        SaveEmployees();
    }
    public int GetNextId()
    {
        int index = Employees.Any() ? Employees.Max(p => p.Id) + 1 : 1;
        return index;
    }
}
