using ProductManagement.Domain.Models;

namespace ProductManagement.Domain;

public class ProductService
{
    public List<Product> _products { get; set; } = new List<Product>();
    public ProductService()
    {
        ReadProducts();

    }

    private void ReadProducts()
    {
        Product pr1 = new Product()
        {
            Id = 1,
            Name = "Product 1",
            Description = "Good product",
            Price = 100.00m,
            Owner = "Owner 1",
            Count = 10
        };

        Product pr2 = new Product()
        {
            Id = 2,
            Name = "Product 2",
            Description = "Better product",
            Price = 150.00m,
            Owner = "Owner 2",
            Count = 5
        };

        Product pr3 = new Product()
        {
            Id = 3,
            Name = "Product 3",
            Description = "Best product",
            Price = 200.00m,
            Owner = "Owner 3",
            Count = 8
        };

        Product pr4 = new Product()
        {
            Id = 4,
            Name = "Product 4",
            Description = "Excellent product",
            Price = 250.00m,
            Owner = "Owner 4",
            Count = 4
        };

        Product pr5 = new Product()
        {
            Id = 5,
            Name = "Product 5",
            Description = "Exceptional product",
            Price = 300.00m,
            Owner = "Owner 5",
            Count = 7
        };

        _products.Add(pr1);
        _products.Add(pr2); 
        _products.Add(pr3); 
        _products.Add(pr4); 
        _products.Add(pr4);

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
    }
    public void EditProduct(Product product)
    {
        var oldProduct = _products.First(t=>t.Id == product.Id);
        int index = _products.IndexOf(oldProduct);
        _products[index] = product;
    }
    public int GetNextId()
    {
        int index = _products.Any() ? _products.Max(p=>p.Id) + 1 : 1 ;
        return index;
    }

}
