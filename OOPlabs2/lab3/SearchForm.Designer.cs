
namespace lab2
{
    partial class SearchForm
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
            this.textBox_Input = new System.Windows.Forms.TextBox();
            this.button_rooms = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_District = new System.Windows.Forms.Button();
            this.button_city = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Input
            // 
            this.textBox_Input.Location = new System.Drawing.Point(12, 12);
            this.textBox_Input.Name = "textBox_Input";
            this.textBox_Input.Size = new System.Drawing.Size(156, 20);
            this.textBox_Input.TabIndex = 9;
            // 
            // button_rooms
            // 
            this.button_rooms.Location = new System.Drawing.Point(12, 38);
            this.button_rooms.Name = "button_rooms";
            this.button_rooms.Size = new System.Drawing.Size(75, 23);
            this.button_rooms.TabIndex = 10;
            this.button_rooms.Text = "Rooms";
            this.button_rooms.UseVisualStyleBackColor = true;
            this.button_rooms.Click += new System.EventHandler(this.button_rooms_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Year";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_District
            // 
            this.button_District.Location = new System.Drawing.Point(93, 67);
            this.button_District.Name = "button_District";
            this.button_District.Size = new System.Drawing.Size(75, 23);
            this.button_District.TabIndex = 12;
            this.button_District.Text = "District";
            this.button_District.UseVisualStyleBackColor = true;
            this.button_District.Click += new System.EventHandler(this.button_District_Click);
            // 
            // button_city
            // 
            this.button_city.Location = new System.Drawing.Point(12, 67);
            this.button_city.Name = "button_city";
            this.button_city.Size = new System.Drawing.Size(75, 23);
            this.button_city.TabIndex = 13;
            this.button_city.Text = "City";
            this.button_city.UseVisualStyleBackColor = true;
            this.button_city.Click += new System.EventHandler(this.button_city_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 102);
            this.Controls.Add(this.button_city);
            this.Controls.Add(this.button_District);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_rooms);
            this.Controls.Add(this.textBox_Input);
            this.Name = "SearchForm";
            this.Text = "SearchForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Input;
        private System.Windows.Forms.Button button_rooms;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_District;
        private System.Windows.Forms.Button button_city;
    }
}