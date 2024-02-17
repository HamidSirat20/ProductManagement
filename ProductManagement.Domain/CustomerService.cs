using ProductManagement.Domain.Models;
using System.Collections.ObjectModel;

namespace ProductManagement.Domain;

public class CustomerService
{
    public ObservableCollection<Customer> customers { get; set; } = new ObservableCollection<Customer>();
    public CustomerService()
    {
        ReadCustomers();

    }

    private void ReadCustomers()
    {
        Customer cust1 = new Customer()
        {
            Id = 1,
            FirstName = "Alice",
            LastName = "Johnson",
            PhoneNumber = 12345678901,
            Address = "100 Main St"
        };

        Customer cust2 = new Customer()
        {
            Id = 2,
            FirstName = "Bob",
            LastName = "Smith",
            PhoneNumber = 23456789012,
            Address = "200 Oak St"
        };

        Customer cust3 = new Customer()
        {
            Id = 3,
            FirstName = "Charlie",
            LastName = "Brown",
            PhoneNumber = 34567890123,
            Address = "300 Pine St"
        };

        Customer cust4 = new Customer()
        {
            Id = 4,
            FirstName = "Diana",
            LastName = "Prince",
            PhoneNumber = 45678901234,
            Address = "400 Maple St"
        };

       customers.Add(cust1);
        customers.Add(cust2);
        customers.Add(cust3);
        customers.Add(cust4);
    }
    public void AddProduct(Customer customer)
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
    }
    public void RemoveProduct(int id)
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
    }
    public void EditProduct(Customer customer)
    {
        var oldProduct = customers.First(t => t.Id == customer.Id);
        int index = customers.IndexOf(oldProduct);
        customers[index] = customer;
    }
    public int GetNextId()
    {
        int index = customers.Any() ? customers.Max(p => p.Id) + 1 : 1;
        return index;
    }
}
