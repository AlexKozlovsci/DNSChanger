using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSChanger
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            bool result = DNSChanger.Set();
            if (result)
            {
                MessageBox.Show("DNS set success!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("DNS set error!", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool result = DNSChanger.Delete();
            if (result)
            {
                MessageBox.Show("DNS delete success!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("DNS delete error!", "Error", MessageBoxButtons.OK);
            }
        }
    }
}
