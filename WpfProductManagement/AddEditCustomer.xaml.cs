using ProductManagement.Domain.Models;
using ProductManagement.Domain;
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
    /// Interaction logic for AddEditCustomer.xaml
    /// </summary>
    public partial class AddEditCustomer : Window
    {
        private CustomerService _customerService;
        private Customer _editingCustomer;
        private bool isEdit = false;
        public AddEditCustomer( CustomerService customer)
        {
            InitializeComponent();
            _customerService = customer; 
        }
        public AddEditCustomer(CustomerService customerService, Customer customer)
        {
            InitializeComponent();
            _customerService = customerService;
            _editingCustomer = customer;
            isEdit = true;
            tbFirstName.Text = _editingCustomer.FirstName;
            tbLastName.Text = _editingCustomer.LastName;
            tbPhoneNumber.Text = _editingCustomer.PhoneNumber.ToString();
            tbAddress.Text = _editingCustomer.Address;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (isEdit)
            {
                Customer customer = new Customer()
                {
                    Id = _editingCustomer.Id,
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Address = tbAddress.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                };
                _customerService.EditCustomer(customer);
            }
            else
            {
                Customer customer = new Customer()
                {
                    Id = _customerService.GetNextId(),
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text,
                    Address = tbAddress.Text,
                    PhoneNumber = Convert.ToUInt64(tbPhoneNumber.Text),
                 
                };
                _customerService.AddCustomer(customer);
            }


            this.Close();
        }
    }
}
