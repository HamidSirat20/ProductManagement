using ProductManagement.Domain;
using ProductManagement.Domain.Models;
using System.Windows;

namespace WpfProductManagement;

/// <summary>
/// Interaction logic for AddEditEmployee.xaml
/// </summary>
public partial class AddEditEmployee : Window
{
    private EmployeeService _employeeService;
    private Employee _editingEmployee;
    private bool isEdit = false;
    public AddEditEmployee(EmployeeService employeeService)
    {
        InitializeComponent();
        _employeeService = employeeService;
    }
    public AddEditEmployee(EmployeeService employeeService, Employee employee)
    {
        InitializeComponent();
        _employeeService = employeeService;
        _editingEmployee = employee;
        isEdit = true;
        tbFirstName.Text = _editingEmployee.FirstName;
        tbLastName.Text = _editingEmployee.LastName;
        tbPhoneNumber.Text = _editingEmployee.PhoneNumber.ToString();
        tbAddress.Text = _editingEmployee.Address;
        comboDepartment.SelectedIndex = (int)_editingEmployee.Department;
        tbSalary.Text = _editingEmployee.BaseSalary.ToString();
    }

    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

    private void btnOk_Click(object sender, RoutedEventArgs e)
    {
        bool isValid = true;
        isValid = ValidateEmploye();

        if (isValid)
        {
            if (isEdit)
            {
                Employee employee = new Employee()
                {
                    Id = _editingEmployee.Id,
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Address = tbAddress.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                    Department = (Department)comboDepartment.SelectedIndex,
                    BaseSalary = Convert.ToDecimal(tbSalary.Text),
                };
                _employeeService.EditEmployee(employee);
            }
            else
            {
                Employee employee = new Employee()
                {
                    Id = _employeeService.GetNextId(),
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Address = tbAddress.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                    Department = (Department)comboDepartment.SelectedIndex,
                    BaseSalary = Convert.ToDecimal(tbSalary.Text),
                };
                _employeeService.AddEmployee(employee);
            }
            this.Close();
        }



    }

    private bool ValidateEmploye()
    {
        bool isValid = true;
        string firstName = tbFirstName.Text.Trim().ToLower();
        string lastName = tbLastName.Text.Trim().ToLower();
        string address = tbAddress.Text.Trim().ToLower();
        string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
        int department = (int)comboDepartment.SelectedIndex;
        string baseSalary = tbSalary.Text.Trim().ToLower();
        if (string.IsNullOrEmpty(firstName))
        {
            isValid = false;
            lblError.Content = "**First Name is invalid!";
        }
        else if (string.IsNullOrEmpty(lastName))
        {
            isValid = false;
            lblError.Content = "**Last Name is invalid!";
        }
        else if (!UInt64.TryParse(phoneNumber, out ulong p)) 
        { 
            isValid = false;
            lblError.Content = "**Phone number type is invalid!";
        }
        else if (department < 0)
        {
            isValid = false;
            lblError.Content = "**Please select a department!";
        }
        else if(!decimal.TryParse(baseSalary, out decimal s) || s > 50000)
        {
            isValid = false;
            lblError.Content="**Salary is invalid!";    
        }
        else
        {
            lblError.Content = "";
        }

        return isValid;
    }

    private void tbPhoneNumber_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
        string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();
         if (!UInt64.TryParse(phoneNumber, out ulong p))
        {
           
            lblError.Content = "**Phone number type is invalid!";
        }
        else
        {
            lblError.Content = "";
        }

    }
}

