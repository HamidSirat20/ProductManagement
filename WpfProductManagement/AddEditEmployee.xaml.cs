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
    private bool isEdit=false;
    public AddEditEmployee( EmployeeService employeeService)
    {
        InitializeComponent();
        _employeeService = employeeService;
    }
    public AddEditEmployee(EmployeeService employeeService, Employee employee)
    {
        InitializeComponent();
        _employeeService = employeeService;
        _editingEmployee = employee;
        isEdit=true;
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
