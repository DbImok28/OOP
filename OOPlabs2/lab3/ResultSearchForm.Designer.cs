
namespace lab2
{
    partial class ResultSearchForm
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
            this.dataGridView_Apartaments = new System.Windows.Forms.DataGridView();
            this.Footage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfRooms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kitchen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Toilet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Basement = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Balcony = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearOfConstruction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeOfMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Floor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Apartaments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Apartaments
            // 
            this.dataGridView_Apartaments.AllowUserToAddRows = false;
            this.dataGridView_Apartaments.AllowUserToDeleteRows = false;
            this.dataGridView_Apartaments.AllowUserToOrderColumns = true;
            this.dataGridView_Apartaments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Apartaments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Footage,
            this.NumberOfRooms,
            this.Kitchen,
            this.Bath,
            this.Toilet,
            this.Basement,
            this.Balcony,
            this.YearOfConstruction,
            this.TypeOfMaterial,
            this.Floor,
            this.Address});
            this.dataGridView_Apartaments.Location = new System.Drawing.Point(12, 12);
            this.dataGridView_Apartaments.Name = "dataGridView_Apartaments";
            this.dataGridView_Apartaments.Size = new System.Drawing.Size(845, 464);
            this.dataGridView_Apartaments.TabIndex = 24;
            // 
            // Footage
            // 
            this.Footage.HeaderText = "Метраж";
            this.Footage.Name = "Footage";
            // 
            // NumberOfRooms
            // 
            this.NumberOfRooms.HeaderText = "Количество комнат";
            this.NumberOfRooms.Name = "NumberOfRooms";
            // 
            // Kitchen
            // 
            this.Kitchen.HeaderText = "Кухня";
            this.Kitchen.Name = "Kitchen";
            this.Kitchen.Width = 40;
            // 
            // Bath
            // 
            this.Bath.HeaderText = "Ванна";
            this.Bath.Name = "Bath";
            this.Bath.Width = 40;
            // 
            // Toilet
            // 
            this.Toilet.HeaderText = "Туалет";
            this.Toilet.Name = "Toilet";
            this.Toilet.Width = 40;
            // 
            // Basement
            // 
            this.Basement.HeaderText = "Подвал";
            this.Basement.Name = "Basement";
            this.Basement.Width = 40;
            // 
            // Balcony
            // 
            this.Balcony.HeaderText = "Балкон";
            this.Balcony.Name = "Balcony";
            this.Balcony.Width = 40;
            // 
            // YearOfConstruction
            // 
            this.YearOfConstruction.HeaderText = "Год постройки";
            this.YearOfConstruction.Name = "YearOfConstruction";
            // 
            // TypeOfMaterial
            // 
            this.TypeOfMaterial.HeaderText = "Тип материала";
            this.TypeOfMaterial.Name = "TypeOfMaterial";
            // 
            // Floor
            // 
            this.Floor.HeaderText = "Этаж";
            this.Floor.Name = "Floor";
            // 
            // Address
            // 
            this.Address.HeaderText = "Адрес";
            this.Address.Name = "Address";
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(13, 483);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(100, 23);
            this.button_search.TabIndex = 25;
            this.button_search.Text = "Search";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // ResultSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 525);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.dataGridView_Apartaments);
            this.Name = "ResultSearchForm";
            this.Text = "ResultSearchForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Apartaments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Apartaments;
        private System.Windows.Forms.DataGridViewTextBoxColumn Footage;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfRooms;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kitchen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Toilet;
        private System.Windows.Forms.DataGridViewTextBoxColumn Basement;
        private System.Windows.Forms.DataGridViewTextBoxColumn Balcony;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearOfConstruction;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeOfMaterial;
        private System.Windows.Forms.DataGridViewTextBoxColumn Floor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.Button button_search;
    }
}