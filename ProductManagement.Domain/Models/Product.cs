using ProductManagement.Domain.InterfaceModel;

namespace ProductManagement.Domain.Models;

public class Product : IProduct
{
    public int Id { get ; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Owner { get; set; }
    public int Count { get; set; }

    public string GetBasicInfo()
    {
        return string.Format($"Id: {Id} Name: " +
            $"{Name} Description: {Description} Price: " +
            $"{Price} Owner: {Owner} Count: {Count}");
    }
}
