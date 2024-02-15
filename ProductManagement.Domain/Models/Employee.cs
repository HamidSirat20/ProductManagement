using ProductManagement.Domain.InterfaceModel;

namespace ProductManagement.Domain.Models;

public class Employee : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Address { get; set; }
    public Department Department { get; set; }
    public decimal BaseSalary { get; set; }

    public string GetBasicInfo()
    {
        return string.Format($"FirstName: {FirstName} LastName: " +
            $"{LastName} Tel: {PhoneNumber} Address: {Address} Dept: " +
            $"{Department} SalaryL {BaseSalary}");
    }
}

public enum Department
{
    Production,
    Sales,
    Advertisement,
    Management
}
