namespace POS_SQLServer
{
    partial class EditProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEditId = new System.Windows.Forms.TextBox();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.txtEditPrice = new System.Windows.Forms.TextBox();
            this.txtEditQtyInStock = new System.Windows.Forms.TextBox();
            this.comboEditCid = new System.Windows.Forms.ComboBox();
            this.btnEditUpdate = new System.Windows.Forms.Button();
            this.btnEditDelete = new System.Windows.Forms.Button();
            this.btnEditSearchId = new System.Windows.Forms.Button();
            this.editPictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.editPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "EditQtyInStock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 416);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cid";
            // 
            // txtEditId
            // 
            this.txtEditId.Location = new System.Drawing.Point(258, 136);
            this.txtEditId.Name = "txtEditId";
            this.txtEditId.Size = new System.Drawing.Size(293, 38);
            this.txtEditId.TabIndex = 6;
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(258, 202);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(293, 38);
            this.txtEditName.TabIndex = 7;
            // 
            // txtEditPrice
            // 
            this.txtEditPrice.Location = new System.Drawing.Point(258, 269);
            this.txtEditPrice.Name = "txtEditPrice";
            this.txtEditPrice.Size = new System.Drawing.Size(293, 38);
            this.txtEditPrice.TabIndex = 8;
            // 
            // txtEditQtyInStock
            // 
            this.txtEditQtyInStock.Location = new System.Drawing.Point(258, 340);
            this.txtEditQtyInStock.Name = "txtEditQtyInStock";
            this.txtEditQtyInStock.Size = new System.Drawing.Size(293, 38);
            this.txtEditQtyInStock.TabIndex = 9;
            // 
            // comboEditCid
            // 
            this.comboEditCid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEditCid.FormattingEnabled = true;
            this.comboEditCid.Items.AddRange(new object[] {
            "Spice Infused",
            "Sweet Pastries",
            "Occasion Cake"});
            this.comboEditCid.Location = new System.Drawing.Point(258, 409);
            this.comboEditCid.Name = "comboEditCid";
            this.comboEditCid.Size = new System.Drawing.Size(293, 39);
            this.comboEditCid.TabIndex = 11;
            // 
            // btnEditUpdate
            // 
            this.btnEditUpdate.Location = new System.Drawing.Point(55, 590);
            this.btnEditUpdate.Name = "btnEditUpdate";
            this.btnEditUpdate.Size = new System.Drawing.Size(168, 52);
            this.btnEditUpdate.TabIndex = 14;
            this.btnEditUpdate.Text = "Update";
            this.btnEditUpdate.UseVisualStyleBackColor = true;
            this.btnEditUpdate.Click += new System.EventHandler(this.btnEditUpdate_Click);
            // 
            // btnEditDelete
            // 
            this.btnEditDelete.Location = new System.Drawing.Point(55, 693);
            this.btnEditDelete.Name = "btnEditDelete";
            this.btnEditDelete.Size = new System.Drawing.Size(168, 52);
            this.btnEditDelete.TabIndex = 15;
            this.btnEditDelete.Text = "Delete";
            this.btnEditDelete.UseVisualStyleBackColor = true;
            this.btnEditDelete.Click += new System.EventHandler(this.btnEditDelete_Click);
            // 
            // btnEditSearchId
            // 
            this.btnEditSearchId.Location = new System.Drawing.Point(620, 122);
            this.btnEditSearchId.Name = "btnEditSearchId";
            this.btnEditSearchId.Size = new System.Drawing.Size(215, 52);
            this.btnEditSearchId.TabIndex = 16;
            this.btnEditSearchId.Text = "Search By ID";
            this.btnEditSearchId.UseVisualStyleBackColor = true;
            this.btnEditSearchId.Click += new System.EventHandler(this.btnEditSearchId_Click);
            // 
            // editPictureBox1
            // 
            this.editPictureBox1.Image = global::POS_SQLServer.Properties.Resources.Default_Image;
            this.editPictureBox1.Location = new System.Drawing.Point(272, 533);
            this.editPictureBox1.Name = "editPictureBox1";
            this.editPictureBox1.Size = new System.Drawing.Size(279, 277);
            this.editPictureBox1.TabIndex = 13;
            this.editPictureBox1.TabStop = false;
            this.editPictureBox1.Click += new System.EventHandler(this.editPictureBox1_Click);
            // 
            // EditProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 859);
            this.Controls.Add(this.btnEditSearchId);
            this.Controls.Add(this.btnEditDelete);
            this.Controls.Add(this.btnEditUpdate);
            this.Controls.Add(this.editPictureBox1);
            this.Controls.Add(this.comboEditCid);
            this.Controls.Add(this.txtEditQtyInStock);
            this.Controls.Add(this.txtEditPrice);
            this.Controls.Add(this.txtEditName);
            this.Controls.Add(this.txtEditId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "EditProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditProduct";
            ((System.ComponentModel.ISupportInitialize)(this.editPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEditId;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.TextBox txtEditPrice;
        private System.Windows.Forms.TextBox txtEditQtyInStock;
        private System.Windows.Forms.ComboBox comboEditCid;
        private System.Windows.Forms.PictureBox editPictureBox1;
        private System.Windows.Forms.Button btnEditUpdate;
        private System.Windows.Forms.Button btnEditDelete;
        private System.Windows.Forms.Button btnEditSearchId;
    }
}