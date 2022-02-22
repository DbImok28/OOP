
namespace lab2
{
    partial class FormApartment
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
            this.numericUpDown_Footage = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Floor = new System.Windows.Forms.NumericUpDown();
            this.comboBox_TypeOfMaterial = new System.Windows.Forms.ComboBox();
            this.dateTimePicker_YearOfConstruction = new System.Windows.Forms.DateTimePicker();
            this.checkedListBox_rooms = new System.Windows.Forms.CheckedListBox();
            this.trackBar_NumberOfRooms = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_adress = new System.Windows.Forms.Button();
            this.comboBox_AddressOfRoom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_add = new System.Windows.Forms.Button();
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
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Footage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Floor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_NumberOfRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Apartaments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Метраж";
            // 
            // numericUpDown_Footage
            // 
            this.numericUpDown_Footage.Location = new System.Drawing.Point(23, 30);
            this.numericUpDown_Footage.Name = "numericUpDown_Footage";
            this.numericUpDown_Footage.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown_Footage.TabIndex = 13;
            // 
            // numericUpDown_Floor
            // 
            this.numericUpDown_Floor.Location = new System.Drawing.Point(24, 374);
            this.numericUpDown_Floor.Name = "numericUpDown_Floor";
            this.numericUpDown_Floor.Size = new System.Drawing.Size(105, 20);
            this.numericUpDown_Floor.TabIndex = 12;
            // 
            // comboBox_TypeOfMaterial
            // 
            this.comboBox_TypeOfMaterial.FormattingEnabled = true;
            this.comboBox_TypeOfMaterial.Items.AddRange(new object[] {
            "Кирпич",
            "Дерево"});
            this.comboBox_TypeOfMaterial.Location = new System.Drawing.Point(23, 320);
            this.comboBox_TypeOfMaterial.Name = "comboBox_TypeOfMaterial";
            this.comboBox_TypeOfMaterial.Size = new System.Drawing.Size(105, 21);
            this.comboBox_TypeOfMaterial.TabIndex = 11;
            // 
            // dateTimePicker_YearOfConstruction
            // 
            this.dateTimePicker_YearOfConstruction.CustomFormat = "yyyy";
            this.dateTimePicker_YearOfConstruction.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_YearOfConstruction.Location = new System.Drawing.Point(23, 265);
            this.dateTimePicker_YearOfConstruction.Name = "dateTimePicker_YearOfConstruction";
            this.dateTimePicker_YearOfConstruction.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker_YearOfConstruction.TabIndex = 10;
            // 
            // checkedListBox_rooms
            // 
            this.checkedListBox_rooms.FormattingEnabled = true;
            this.checkedListBox_rooms.Items.AddRange(new object[] {
            "кухня",
            "ванна",
            "туалет",
            "подвал",
            "балкон"});
            this.checkedListBox_rooms.Location = new System.Drawing.Point(23, 142);
            this.checkedListBox_rooms.Name = "checkedListBox_rooms";
            this.checkedListBox_rooms.Size = new System.Drawing.Size(104, 94);
            this.checkedListBox_rooms.TabIndex = 9;
            // 
            // trackBar_NumberOfRooms
            // 
            this.trackBar_NumberOfRooms.Location = new System.Drawing.Point(22, 91);
            this.trackBar_NumberOfRooms.Name = "trackBar_NumberOfRooms";
            this.trackBar_NumberOfRooms.Size = new System.Drawing.Size(104, 45);
            this.trackBar_NumberOfRooms.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Количество комнат";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Год постройки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Тип материала";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 358);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Этаж";
            // 
            // button_adress
            // 
            this.button_adress.Location = new System.Drawing.Point(24, 455);
            this.button_adress.Name = "button_adress";
            this.button_adress.Size = new System.Drawing.Size(107, 23);
            this.button_adress.TabIndex = 19;
            this.button_adress.Text = "Добавить Адрес";
            this.button_adress.UseVisualStyleBackColor = true;
            this.button_adress.Click += new System.EventHandler(this.button_adress_Click);
            // 
            // comboBox_AddressOfRoom
            // 
            this.comboBox_AddressOfRoom.FormattingEnabled = true;
            this.comboBox_AddressOfRoom.Location = new System.Drawing.Point(24, 428);
            this.comboBox_AddressOfRoom.Name = "comboBox_AddressOfRoom";
            this.comboBox_AddressOfRoom.Size = new System.Drawing.Size(105, 21);
            this.comboBox_AddressOfRoom.TabIndex = 20;
            this.comboBox_AddressOfRoom.Click += new System.EventHandler(this.comboBox_AddressOfRoom_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 412);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Адрес";
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(22, 493);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(109, 23);
            this.button_add.TabIndex = 22;
            this.button_add.Text = "Добавить";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // dataGridView_Apartaments
            // 
            this.dataGridView_Apartaments.AllowUserToAddRows = false;
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
            this.dataGridView_Apartaments.Location = new System.Drawing.Point(187, 14);
            this.dataGridView_Apartaments.Name = "dataGridView_Apartaments";
            this.dataGridView_Apartaments.Size = new System.Drawing.Size(845, 464);
            this.dataGridView_Apartaments.TabIndex = 23;
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
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(187, 493);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(112, 23);
            this.button_save.TabIndex = 24;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(305, 493);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(112, 23);
            this.button_load.TabIndex = 25;
            this.button_load.Text = "Load";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormApartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 527);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.dataGridView_Apartaments);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_AddressOfRoom);
            this.Controls.Add(this.button_adress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_Footage);
            this.Controls.Add(this.numericUpDown_Floor);
            this.Controls.Add(this.comboBox_TypeOfMaterial);
            this.Controls.Add(this.dateTimePicker_YearOfConstruction);
            this.Controls.Add(this.checkedListBox_rooms);
            this.Controls.Add(this.trackBar_NumberOfRooms);
            this.Name = "FormApartment";
            this.Text = "Apartment";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Footage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Floor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_NumberOfRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Apartaments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Footage;
        private System.Windows.Forms.NumericUpDown numericUpDown_Floor;
        private System.Windows.Forms.ComboBox comboBox_TypeOfMaterial;
        private System.Windows.Forms.DateTimePicker dateTimePicker_YearOfConstruction;
        private System.Windows.Forms.CheckedListBox checkedListBox_rooms;
        private System.Windows.Forms.TrackBar trackBar_NumberOfRooms;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_adress;
        private System.Windows.Forms.ComboBox comboBox_AddressOfRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_add;
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
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button1;
    }
}

