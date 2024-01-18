using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBank2
{
    public partial class ViewEditForm : ParentForm
    {
        Controller control = new Controller();
        Customers customer;

        public ViewEditForm()
        {
            InitializeComponent();
            //control.InitialiseList();
            ReadTextFile();
            DisplayCustomers();
            Clear();
        }

        private void ReadTextFile()
        {
            Customers c = null;
            string[] strArray;

            //open file
            var myfile = new StreamReader("../../data.txt");

            while (!myfile.EndOfStream)
            {
                strArray = myfile.ReadLine().Split(',');

                control.AddCustomer(strArray[0], strArray[1], strArray[2]);

                if (c != null)
                {
                    control.customersList.Add(c);
                }

            }
            myfile.Close();
        }

        private void WriteTextFile()
        {
            //open file
            var myfile = new StreamWriter("../../data.txt");

            foreach (Customers cst in control.customersList)
            {
                myfile.WriteLine(cst.Name + "," + cst.Phone + "," + cst.Address);
            }
            myfile.Close();
        }

        private void DisplayCustomers()
        {
            listBoxCustomersDisplay.Items.Clear();

            foreach (Customers c in control.customersList)
            {
                listBoxCustomersDisplay.Items.Add(c.Name);
            }
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            listBoxCustomersDisplay.Items.Clear();
            Clear();

            // For each customers having the characters from the search box, add them on the list view.
            foreach (Customers c in control.customersList)
            {
                if (c.Name.ToLower().Contains(textBoxSearch.Text.ToLower()))
                    listBoxCustomersDisplay.Items.Add(c.Name);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBoxCID.Text == "")
            {
                MessageBox.Show("No customer selected");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Delete customer?", "Confirmation!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                control.DeleteCustomer((string)listBoxCustomersDisplay.SelectedItem);
                DisplayCustomers();
                Clear();
                WriteTextFile();
            }
        }

        private void listBoxCustomersDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (listBoxCustomersDisplay.SelectedItem != null)
            {                
                Clear();
                customer = control.FindCustomersByName((string)listBoxCustomersDisplay.SelectedItem);                
                textBoxCID.Text = customer.ID.ToString();
                textBoxName.Text = customer.Name;
                textBoxPhone.Text = customer.Phone;
                textBoxAddress.Text = customer.Address;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (textBoxCID.Text == "")
            {
                MessageBox.Show("No customer selected");
                return;
            }

            NotReadOnlyTextboxes();
            buttonEdit.Enabled = false;
            buttonSave.Enabled = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Confirm details?", "Confirmation!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                customer = control.FindCustomerByID(int.Parse(textBoxCID.Text));

                control.EditCustomer(customer, textBoxName.Text, textBoxPhone.Text, textBoxAddress.Text);
                Clear();
                DisplayCustomers();
                WriteTextFile();
                textBoxSearch.Clear();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Clear();
            DisplayCustomers();
            textBoxSearch.Clear();
        }

        private void NotReadOnlyTextboxes()
        {
            textBoxName.ReadOnly = false;
            textBoxPhone.ReadOnly = false;
            textBoxAddress.ReadOnly = false;
        }

        private void ReadOnlyTextboxes()
        {
            textBoxName.ReadOnly = true;
            textBoxPhone.ReadOnly = true;
            textBoxAddress.ReadOnly = true;
        }

        private void TextboxesClear()
        {
            textBoxCID.Clear();
            textBoxName.Clear();
            textBoxPhone.Clear();
            textBoxAddress.Clear();
        }

        private void Clear()
        {
            ReadOnlyTextboxes();
            TextboxesClear();
            buttonEdit.Enabled = true;
            buttonSave.Enabled = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.Show();
            this.Hide();
        }
    }
}
