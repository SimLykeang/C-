using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2_POS_System_Product;

namespace POS_SQLServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            new LoginForm().ShowDialog(this);
        }

        private void btnOrderProducts_Click(object sender, EventArgs e)
        {
            try
            {
                MyData.Products = DataConection.GetProducts();
                new _2_POS_System_Product.Form1().ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            new AddProduct().ShowDialog(this);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            new EditProduct().ShowDialog(this);
        }
    }
}
