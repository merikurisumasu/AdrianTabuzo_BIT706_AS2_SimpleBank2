using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimpleBank2
{
    internal class Controller
    {
        // Declare a list to store customers.
        public List<Customers> customersList = new List<Customers>();

        public void AddCustomer(string name, string phone, string address)
        {
            customersList.Add(new Customers(name, phone, address));
        }

        public Customers FindCustomersByName(string name)
        {
            foreach (Customers c in customersList)
            {
                if (c.Name == name) { return c; }
            }
            return null;
        }

        public Customers FindCustomerByID(int id)
        {
            foreach (Customers c in customersList)
                if (c.ID == id)
                    return c;
            return null;
        }

        // Remove from the list of customers.
        public void DeleteCustomer(string name)
        {
            customersList.Remove(FindCustomersByName(name));
        }  
        
        // Set new details for customer.
        public void EditCustomer(Customers cust, string name, string phone, string address)
        {
            cust.Name = name;
            cust.Phone = phone;
            cust.Address = address;
        }
    }
}
