using ProductManagement.Domain;
using ProductManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditEmployee.xaml
    /// </summary>
    public partial class AddEditEmployee : Window
    {
        private EmployeeService _employeeService;
        public AddEditEmployee( EmployeeService employeeService)
        {
            InitializeComponent();
            _employeeService = employeeService;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
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
            this.Close();
        }
    }
}
