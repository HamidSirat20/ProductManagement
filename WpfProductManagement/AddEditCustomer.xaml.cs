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
            bool isValid = true;
            isValid = ValidateCustomer();
            if (isValid)
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

        private bool ValidateCustomer()
        {

            bool isValid = true;
            string firstName = tbFirstName.Text.Trim().ToLower();
            string lastName = tbLastName.Text.Trim().ToLower();
            string address = tbAddress.Text.Trim().ToLower();
            string phoneNumber = tbPhoneNumber.Text.Trim().ToLower();        
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
            else if (string.IsNullOrEmpty(address))
            {
                isValid = false;
                lblError.Content = "**Address is invalid!";
            }
            else
            {
                lblError.Content = "";
            }

            return isValid;
        }
    }
}
