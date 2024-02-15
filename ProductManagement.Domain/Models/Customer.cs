using ProductManagement.Domain.InterfaceModel;
using System.Diagnostics;
using System.Xml.Linq;

namespace ProductManagement.Domain.Models;

public class Customer : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ulong PhoneNumber { get; set; }
    public string Address { get; set; }

    public string GetBasicInfo()
    {
        return string.Format($"Id: {Id} Name: " +
        $"{FirstName} LastName: {LastName} Tel: " +
           $"{PhoneNumber} Address: {Address} ");
    }
}
