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
    public partial class EditProduct : Form
    {
        string selectedImagePath = "";
        private readonly string defaultPhotoPath = Path.Combine(Application.StartupPath, "Default_Photo.jpg");
        public EditProduct()
        {
            InitializeComponent();
            LoadCategories();
        }
        //load combobox in edit form
        private void LoadCategories()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT id, categoryname FROM tblCategory", DataConection.DataCon))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    comboEditCid.DataSource = dt;
                    comboEditCid.DisplayMember = "categoryname";
                    comboEditCid.ValueMember = "id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading categories: " + ex.Message);
            }
        }

        //Clear Form
        private void ClearForm()
        {
            txtEditId.Text = string.Empty;
            txtEditName.Text = string.Empty;
            txtEditPrice.Text = string.Empty;
            txtEditQtyInStock.Text = string.Empty;
            comboEditCid.SelectedIndex = 0;

            editPictureBox1.Image?.Dispose();
            editPictureBox1.Image = Properties.Resources.Default_Image;
            editPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            selectedImagePath = string.Empty;
        }
        //buttub search by id
        private void btnEditSearchId_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtEditId.Text, out long id))
            {
                MessageBox.Show("Please enter a valid ID.");
                return;
            }

            try
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProduct WHERE id = @id", DataConection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Fill the form with data from the database


                            long id1 = reader.GetInt64(0);
                            string pName = reader.GetString(1);
                            double price = reader.GetSqlMoney(2).ToDouble();
                            int qtyInStock = reader.GetInt32(3);
                            byte[] photo = (byte[])reader[4];
                            long categoryId = reader.GetInt64(5);
                            txtEditId.Text = id1.ToString();
                            txtEditName.Text = pName;
                            txtEditPrice.Text = price.ToString("N2");
                            txtEditQtyInStock.Text = qtyInStock.ToString();
                            comboEditCid.SelectedValue = categoryId;

                            if (reader["photo"] != DBNull.Value)
                            {
                                byte[] imgBytes = (byte[])reader["photo"];
                                using (MemoryStream ms = new MemoryStream(imgBytes))
                                {
                                    editPictureBox1.Image = Image.FromStream(ms);
                                    editPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                                }
                            }
                            else
                            {
                                editPictureBox1.Image = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Product not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        //place picture in picturebox
        private void editPictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    editPictureBox1.Image?.Dispose();
                    editPictureBox1.Image = Image.FromFile(selectedImagePath);
                    editPictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void btnEditUpdate_Click(object sender, EventArgs e)
        {
            //Update Button

            // Confirm update
            var confirm = MessageBox.Show("Are you sure you want to update this product?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            // Validate inputs
            if (!long.TryParse(txtEditId.Text, out long id))
            {
                MessageBox.Show("Invalid ID.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEditName.Text) ||
                string.IsNullOrWhiteSpace(txtEditPrice.Text) ||
                string.IsNullOrWhiteSpace(txtEditQtyInStock.Text) ||
                comboEditCid.SelectedValue == null)
            {
                MessageBox.Show("Please complete all fields.");
                return;
            }

            try
            {
                string sql = "UPDATE tblProduct SET pname = @name, price = @price, qtyInStock = @qty, cid = @cid";

                // Optional image update
                byte[] imgBytes = null;
                if (!string.IsNullOrEmpty(selectedImagePath) && File.Exists(selectedImagePath))
                {
                    imgBytes = File.ReadAllBytes(selectedImagePath);
                    sql += ", photo = @photo"; // Add photo to SQL only if selected
                }

                sql += " WHERE id = @id"; // Append WHERE clause

                using (SqlCommand cmd = new SqlCommand(sql, DataConection.DataCon))
                {
                    cmd.Parameters.AddWithValue("@name", txtEditName.Text.Trim());
                    cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtEditPrice.Text));
                    cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(txtEditQtyInStock.Text));
                    cmd.Parameters.AddWithValue("@cid", Convert.ToInt32(comboEditCid.SelectedValue));
                    cmd.Parameters.AddWithValue("@id", id);

                    if (imgBytes != null)
                    {
                        cmd.Parameters.AddWithValue("@photo", imgBytes);
                    }

                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        ClearForm();
                       // LoadAllProducts(); // Refresh grid
                        MessageBox.Show("Product updated successfully.");
                    }
                    else
                        MessageBox.Show("Update failed or no changes made.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating product: " + ex.Message);
            }
        }

        private void btnEditDelete_Click(object sender, EventArgs e)
        {
            if (!long.TryParse(txtEditId.Text, out long productId))
            {
                MessageBox.Show("Please enter a valid product ID to delete.");
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Are you sure you want to delete product with ID {productId}?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string deleteQuery = "DELETE FROM tblProduct WHERE id = @id";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, DataConection.DataCon))
                    {
                        cmd.Parameters.AddWithValue("@id", productId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Product deleted successfully.");
                            ClearForm();
                            //LoadAllProducts(); // Refresh grid
                        }
                        else
                        {
                            MessageBox.Show("No product found with that ID.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting product: " + ex.Message);
                }
            }
        }
    }
}
