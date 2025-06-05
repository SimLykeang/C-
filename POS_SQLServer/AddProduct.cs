using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_SQLServer
{
    public partial class AddProduct : Form
    {
        string selectedImagePath = "";
        public AddProduct()
        {
            InitializeComponent();
            this.Shown += AddProduct_Load;
        }

        //to load product
        private void AddProduct_Load(object sender, EventArgs e)
        {
            //load The Next Available ID
            try
            {
                // Replace with your actual credentials


                long nextID = DataConection.GetNextProductID();

                // Update the label
                labelID.Text = $"{nextID}";
                labelID.ForeColor = Color.DarkBlue;
                labelID.Visible = true;
            }
            catch (Exception ex)
            {
                labelID.Text = "Error: Could not load ID";
                labelID.ForeColor = Color.Red;

                // For debugging - remove in production
                MessageBox.Show($"Database Error:\n{ex.Message}",
                              "Connection Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }

            //Bind ComboBox and Sql Cid
            try
            {

                // SECTION 1: LOAD CATEGORIES SORTED BY ID

                // Modified query to sort by id instead of categoryname
                string categoryQuery = "SELECT id, categoryname FROM tblCategory ORDER BY id"; // Changed here

                SqlDataAdapter categoryAdapter = new SqlDataAdapter(categoryQuery, DataConection.DataCon);
                DataTable categoryTable = new DataTable();
                categoryAdapter.Fill(categoryTable);

                // Bind with CORRECT column names
                comboCid.DataSource = categoryTable;
                comboCid.DisplayMember = "categoryname";  // Shows "Soft Drink", "Water" etc.
                comboCid.ValueMember = "id";              // Stores 1, 2, 3 etc.
                comboCid.SelectedIndex = 0;               // Select first item

                // SECTION 2: SHOW NEXT PRODUCT ID (UNCHANGED)

                labelID.Text = DataConection.GetNextProductID().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        // Button to browse and show image


        private void btnSelectImage_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Select an image";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    pictureBox1.Image = Image.FromFile(selectedImagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // 1. VALIDATE INPUTS
            if (string.IsNullOrWhiteSpace(selectedImagePath) ||
                string.IsNullOrWhiteSpace(txtAddName.Text) ||
                string.IsNullOrWhiteSpace(txtAddPrice.Text) ||
                string.IsNullOrWhiteSpace(txtAddQtyInStock.Text) ||
                comboCid.SelectedItem == null)
            {
                MessageBox.Show("Please fill all fields and select an image.");
                return;
            }
            try
            {
                // 2. CONVERT IMAGE TO BYTES
                byte[] imageBytes = File.ReadAllBytes(selectedImagePath);
                // 3. EXECUTE DATABASE INSERT (YOUR ORIGINAL CODE)
                string sql = "INSERT INTO tblProduct (pname, price, qtyInStock, photo, cid) " +
                            "VALUES (@pname, @price, @qtyInStock, @photo, @cid)";

                using (SqlCommand cmd = new SqlCommand(sql, DataConection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@pname", txtAddName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtAddPrice.Text));
                    cmd.Parameters.AddWithValue("@qtyInStock", Convert.ToInt32(txtAddQtyInStock.Text));
                    cmd.Parameters.AddWithValue("@photo", imageBytes);
                    cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(comboCid.SelectedValue));

                    cmd.ExecuteNonQuery();
                }

                // 4. CLEAR FORM AFTER SUCCESS
                txtAddName.Clear();
                txtAddPrice.Clear();
                txtAddQtyInStock.Clear();
                comboCid.SelectedIndex = 0; // Reset to first category
                selectedImagePath = string.Empty;
                pictureBox1.Image = Properties.Resources.Default_Image;


                // Clear image preview if you have one

                // Refresh next available ID
                labelID.Text = DataConection.GetNextProductID().ToString();

                MessageBox.Show("Product saved successfully!");
            }
            catch (Exception ex)
            {
                // 5. HANDLE ERRORS
                MessageBox.Show($"Error saving product: {ex.Message}",
                                "Database Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }
    }
}
