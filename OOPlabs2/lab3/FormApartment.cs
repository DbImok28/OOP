using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class FormApartment : Form
    {
        public FormApartment(DataController dataController)
        {
            data = dataController;
            InitializeComponent();
            RefreshTable();
        }
        private DataController data;

        private void button_adress_Click(object sender, EventArgs e)
        {
            FormAddress formAddress = new FormAddress(data);
            formAddress.Show();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try 
            {
                var apartment = new Apartment(
                    (int)numericUpDown_Footage.Value,
                    trackBar_NumberOfRooms.Value,
                    checkedListBox_rooms.GetSelected(0),
                    checkedListBox_rooms.GetSelected(1),
                    checkedListBox_rooms.GetSelected(2),
                    checkedListBox_rooms.GetSelected(3),
                    checkedListBox_rooms.GetSelected(4),
                    dateTimePicker_YearOfConstruction.Value.Year,
                    (string)comboBox_TypeOfMaterial.SelectedItem,
                    (int)numericUpDown_Floor.Value,
                    (Address)comboBox_AddressOfRoom.SelectedItem);
                dataGridView_Apartaments.Rows.Add(
                    apartment.Footage,
                    apartment.NumberOfRooms,
                    apartment.Kitchen,
                    apartment.Bath,
                    apartment.Toilet,
                    apartment.Basement,
                    apartment.Balcony,
                    apartment.YearOfConstruction,
                    apartment.TypeOfMaterial,
                    apartment.Floor,
                    apartment.AddressOfRoom);
                data.AddApartment(apartment);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void comboBox_AddressOfRoom_Click(object sender, EventArgs e)
        {
            comboBox_AddressOfRoom.Items.Clear();
            foreach (var item in data.addresses)
            {
                comboBox_AddressOfRoom.Items.Add(item);
            }
        }
        public void RefreshTable()
        {
            foreach (var item in data.apartments)
            {
                dataGridView_Apartaments.Rows.Add(
                                item.Footage,
                                item.NumberOfRooms,
                                item.Kitchen,
                                item.Bath,
                                item.Toilet,
                                item.Basement,
                                item.Balcony,
                                item.YearOfConstruction,
                                item.TypeOfMaterial,
                                item.Floor,
                                item.AddressOfRoom);
            }
            
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            data.Save();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            data.Load();
            RefreshTable();
        }
        ~FormApartment()
        {
            data.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SearchForm(data.apartments).ShowDialog();
        }
    }
}
