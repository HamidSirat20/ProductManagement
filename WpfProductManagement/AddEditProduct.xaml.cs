using ProductManagement.Domain.Models;
using ProductManagement.Domain;
using System.Windows;
using System.Net;
using System.Linq.Expressions;

namespace WpfProductManagement;

/// <summary>
/// Interaction logic for AddEditProduct.xaml
/// </summary>
public partial class AddEditProduct : Window
{
    private ProductService _productService;
    private Product _editingProduct;
    private bool isEdit = false;
    public AddEditProduct(ProductService productService)
    {
        InitializeComponent();
        _productService = productService;
    }
    public AddEditProduct(ProductService productService, Product product)
    {
        InitializeComponent();
        _productService = productService;
        _editingProduct = product;
        isEdit = true;
        tbName.Text = _editingProduct.Name;
        tbDescription.Text = _editingProduct.Description;
        tbOwner.Text = _editingProduct.Owner;
        tbPrice.Text = _editingProduct.Price.ToString();
        tbCount.Text = _editingProduct.Count.ToString();
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
        bool isValid = true;
        isValid = ValidateProduct();
        if (isValid)
        {
            if (isEdit)
            {
                Product product = new Product()
                {
                    Id = _editingProduct.Id,
                    Name = tbName.Text,
                    Description = tbDescription.Text,
                    Price = Convert.ToInt64(tbPrice.Text),
                    Owner = tbOwner.Text,
                    Count = Convert.ToInt32(tbCount.Text),
                };
                _productService.EditProduct(product);
            }
            else
            {
                Product product = new Product()
                {
                    Id = _productService.GetNextId(),
                    Name = tbName.Text,
                    Description = tbDescription.Text,
                    Price = Convert.ToInt64(tbPrice.Text),
                    Owner = tbOwner.Text,
                    Count = Convert.ToInt32(tbCount.Text),
                };
                _productService.AddProduct(product);
            }


            this.Close();
        }
    }

    private bool ValidateProduct()
    {

        bool isValid = true;
        string name = tbName.Text.Trim().ToLower();
        string description = tbDescription.Text.Trim().ToLower();
        string price = tbPrice.Text.Trim().ToLower();
        string count = tbCount.Text.Trim().ToLower();
        if (string.IsNullOrEmpty(name))
        {
            isValid = false;
            lblError.Content = "**Name is invalid!";
        }
        else if (string.IsNullOrEmpty(description))
        {
            isValid = false;
            lblError.Content = "**Description is invalid!";
        }
        else if (!decimal.TryParse(price, out decimal p))
        {
            isValid = false;
            lblError.Content = "**Price is invalid!";
        }
        else if (!int.TryParse(count, out int s) || s <0)
        {
            isValid = false;
            lblError.Content = "**count is invalid!";
        }
        else
        {
            lblError.Content = "";
        }

        return isValid;
    }
}
