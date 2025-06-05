using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SQLServer
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            comboAuthentication.SelectedIndex = 0;
        }

        private void comboAuthentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboAuthentication.SelectedIndex;
            if(index == 0)
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string server = txtIP.Text.Trim();
            string dbName = "dbsv1";
            string user = txtUserName.Text.Trim();
            string pass = txtPassword.Text.Trim();
            int index = comboAuthentication.SelectedIndex; 
            try
            {
                if (index == 0)
                {
                    DataConection.ConnectionString(server, dbName);
                }
                else
                {
                    DataConection.ConnectionString(server, dbName, user, pass);
                }
                this.DialogResult = DialogResult.OK;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
