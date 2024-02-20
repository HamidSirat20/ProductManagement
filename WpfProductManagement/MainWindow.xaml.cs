using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProductManagement.Domain.InterfaceModel; 
using ProductManagement.Domain;
using ProductManagement.Domain.Models;
using System.Collections.ObjectModel;


namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeeService employeeService = new EmployeeService();
        CustomerService customerService = new CustomerService();
        ProductService productService = new ProductService();

        ObservableCollection<Employee> employees = new ObservableCollection<Employee>();
        ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
        ObservableCollection<Product> products = new ObservableCollection<Product>();
        public Employee CurrentEmployee { get; set; } = new Employee();
        public Customer CurrentCustomer { get; set; } = new Customer();
        public Product CurrentProduct { get; set; } = new Product();
        public MainWindow()
        {
            InitializeComponent();
            FillData();
            EmployeesGrid.ItemsSource = employees;
            CustomersGrid.ItemsSource = customers;
            ProductsGrid.ItemsSource = products;
        }
        private void FillData()
        {
            employees = employeeService.Employees;
            customers = customerService.customers;
            products = productService._products;
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void btnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;

        }

        private void btnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;

        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;

        }

        private void EmployeesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >=0)
            {
                CurrentEmployee = EmployeesGrid.SelectedItem as Employee;
                EmployeeLabel.Content = CurrentEmployee.GetBasicInfo();
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addEditEmployee = new AddEditEmployee(employeeService);
            addEditEmployee.ShowDialog();
        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmployeesGrid.SelectedItem as Employee;
                employeeService.RemoveEmployee(CurrentEmployee.Id);
                EmployeeLabel.Content = "---";
            }
        }

        private void CustomersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                CustomerLabel.Content = CurrentCustomer.GetBasicInfo();
            }

        }

        private void btnEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProduct = ProductsGrid.SelectedItem as Product;
                ProductLabel.Content = CurrentProduct.GetBasicInfo();
            }

        }

        private void btnEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}