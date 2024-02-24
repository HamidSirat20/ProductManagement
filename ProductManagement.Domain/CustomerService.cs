using ProductManagement.Domain.Models;
using System.Collections.ObjectModel;

namespace ProductManagement.Domain;

public class CustomerService
{
    private string path = @"./DBCustomer.csv";
    public ObservableCollection<Customer> customers { get; set; } = new ObservableCollection<Customer>();
    public CustomerService()
    {
        ReadCustomers();

    }

    private void ReadCustomers()
    {
        using (var reader = new StreamReader(path))
        {
            customers.Clear();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                Customer customer = new Customer()
                {
                    Id = Convert.ToInt32(values[0]),
                    FirstName = values[1],
                    LastName = values[2],
                    PhoneNumber = Convert.ToUInt64(values[3]),
                    Address = values[4]      
                };
                customers.Add(customer);
            }
        }
    }

    private void SaveEmployees()
    {
        using (var writer = new StreamWriter(path))
        {
            foreach (var customer in customers)
            {
                string id = customer.Id.ToString();
                string firstName = customer.FirstName;
                string lastName = customer.LastName;
                string phoneNumber = customer.PhoneNumber.ToString();
                string address = customer.Address;
               
                string line = string.Format("{0};{1};{2};{3};{4}", id, firstName, lastName, phoneNumber, address);
                writer.WriteLine(line);
            }
        }
    }
    public void AddCustomer(Customer customer)
    {
        if (customer == null)
        {
            return;
        }
        else if (customers.FirstOrDefault(i => i.Id == customer.Id) is not null)
        {
            Console.WriteLine("Already exist!");
        }
        customers.Add(customer);
        SaveEmployees();
    }
    public void RemoveCustomer(int id)
    {
        if (id == null)
        {
            return;
        }
        var foundEmployee = customers.FirstOrDefault(p => p.Id == id);
        if (foundEmployee == null)
        {
            Console.WriteLine("No such product found!");
        }
        if (foundEmployee != null)
        {
            customers.Remove(foundEmployee);
        }
        SaveEmployees();
    }
    public void EditCustomer(Customer customer)
    {
        var oldProduct = customers.First(t => t.Id == customer.Id);
        int index = customers.IndexOf(oldProduct);
        customers[index] = customer;
        SaveEmployees();
    }
    public int GetNextId()
    {
        int index = customers.Any() ? customers.Max(p => p.Id) + 1 : 1;
        return index;
    }
}
