using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleBank2
{
    public partial class IndexForm : ParentForm
    {
        public IndexForm()
        {
            InitializeComponent();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            ViewEditForm editForm = new ViewEditForm();
            editForm.Show();
            this.Hide();
        }
    }
}
