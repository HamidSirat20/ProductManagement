using System.Windows;
using System.Windows.Controls;
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
            if (EmployeesGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = EmployeesGrid.SelectedItem as Employee;
                AddEditEmployee addEditEmployee = new AddEditEmployee(employeeService, CurrentEmployee);
                addEditEmployee.ShowDialog();

            }
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
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                AddEditCustomer addEditCustomer = new AddEditCustomer(customerService, CurrentCustomer);
                addEditCustomer.ShowDialog();

            }
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer addEditCustomer = new AddEditCustomer(customerService);
            addEditCustomer.ShowDialog();
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = CustomersGrid.SelectedItem as Customer;
                customerService.RemoveCustomer(CurrentCustomer.Id);
                CustomerLabel.Content = "---";
            }
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
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProduct = ProductsGrid.SelectedItem as Product;
                AddEditProduct addEditProduct = new AddEditProduct(productService, CurrentProduct);
                addEditProduct.ShowDialog();

            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsGrid.SelectedIndex >= 0)
            {
                CurrentProduct = ProductsGrid.SelectedItem as Product;
                productService.RemoveProduct(CurrentProduct.Id);
                ProductLabel.Content = "---";
            }
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addEditProduct = new AddEditProduct(productService);
            addEditProduct.ShowDialog();
        }
    }
}