using ProductManagement.Domain.Models;
using System.Collections.ObjectModel;

namespace ProductManagement.Domain;

public class ProductService
{
    private string path = @"./DBProduct.csv";
    public ObservableCollection<Product> _products { get; set; } = new ObservableCollection<Product>();
    public ProductService()
    {
        ReadProducts();

    }

    private void ReadProducts()
    {
        using (var reader = new StreamReader(path))
        {
            _products.Clear();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split(';');
                Product prod = new Product()
                {
                    Id = Convert.ToInt32(values[0]),
                    Name = values[1],
                    Description = values[2],
                    Price = Convert.ToDecimal(values[3]),
                    Owner = values[4],
                    Count = Convert.ToInt32(values[5]),
                };

                _products.Add(prod);
            }
        }
    }

    private void SaveProduct()
    {
        using (var writer = new StreamWriter(path))
        {
            foreach (var product in _products)
            {
                string id = product.Id.ToString();
                string name = product.Name;
                string description = product.Description;
                string price = product.Price.ToString();
                string owner = product.Owner;
                string count = product.Count.ToString();
                string line = string.Format("{0};{1};{2};{3};{4};{5}", id, name, description, price, owner, count);
                writer.WriteLine(line);
            }
        }
    }
    public void AddProduct(Product product)
    {
        if (product == null)
        {
            return;
        }
        else if (_products.FirstOrDefault(i => i.Id ==product.Id) is not null)
        {
            Console.WriteLine("Already exist!");
        }
        _products.Add(product);
        SaveProduct();
    }
    public void RemoveProduct(int id) 
    {  
        if (id == null) 
        { 
            return;
        } 
       var foundProduct=  _products.FirstOrDefault(p=>p.Id == id);
        if (foundProduct == null) {
            Console.WriteLine("No such product found!");
        }
        if (foundProduct != null)
        {
            _products.Remove(foundProduct);
        }
        SaveProduct();
    }
    public void EditProduct(Product product)
    {
        var oldProduct = _products.First(t=>t.Id == product.Id);
        int index = _products.IndexOf(oldProduct);
        _products[index] = product;
        SaveProduct();
    }
    public int GetNextId()
    {
        int index = _products.Any() ? _products.Max(p=>p.Id) + 1 : 1 ;
        return index;
    }

}
