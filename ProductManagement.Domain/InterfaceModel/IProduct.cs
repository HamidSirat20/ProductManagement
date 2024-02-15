namespace ProductManagement.Domain.InterfaceModel;

public interface IProduct
{
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
    decimal Price { get; set; }
    string Owner { get; set; }
    string GetBasicInfo();
    
}
