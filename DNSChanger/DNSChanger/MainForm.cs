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
            try
            {
                bool result = DNSChanger.Set((string)cmbbxNetworks.SelectedItem); ;
                if (result)
                {
                    MessageBox.Show("DNS set success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DNS set error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("DNS set error!\n Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool result = DNSChanger.Delete((string)cmbbxNetworks.SelectedItem);
                if (result)
                {
                    MessageBox.Show("DNS delete success!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("DNS delete error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("DNS delete error!\n Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<string> networks = new List<string>();
            networks = DNSChanger.CheckNetworks();
            foreach (string item in networks)
                cmbbxNetworks.Items.Add(item);
            cmbbxNetworks.Enabled = true;
            btnDelete.Enabled = true;
            btnSet.Enabled = true;
        }
    }
}
