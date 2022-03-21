using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab5
{
    public partial class FormApartment : Form
    {
        public FormApartment(IDataController dataController)
        {
            controller = new ApartmentController(dataController);
            controller.OnNewApartment += Controller_OnNewApartment;
            config = UIConfig.GetInstance();
            InitializeComponent();
            BackColor = config.BGColor;
            dataGridView_Apartaments.Font = config.GridFont;
            dataGridView_Apartaments.BackgroundColor = config.GridBGColor;

            RefreshTable();
        }

        private void button_adress_Click(object sender, EventArgs e)
        {
            FormAddress formAddress = new FormAddress(controller.data);
            formAddress.Show();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            try 
            {
                var apartment = controller.Add(
                    (int)numericUpDown_Footage.Value,
                    trackBar_NumberOfRooms.Value,
                    dateTimePicker_YearOfConstruction.Value.Year,
                    (string)comboBox_TypeOfMaterial.SelectedItem,
                    (int)numericUpDown_Floor.Value,
                    (Address)comboBox_AddressOfRoom.SelectedItem);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void Controller_OnNewApartment(object sender, Apartment apartment)
        {
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

        }
        private void comboBox_AddressOfRoom_Click(object sender, EventArgs e)
        {
            comboBox_AddressOfRoom.Items.Clear();
            foreach (var item in controller.data.addresses)
            {
                comboBox_AddressOfRoom.Items.Add(item);
            }
        }
        public void RefreshTable()
        {
            foreach (var item in controller.data.apartments)
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
            controller.Save();
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            controller.Load();
            RefreshTable();
        }
        ~FormApartment()
        {
            controller.Save();
        }
        private UIConfig config;
        private ApartmentController controller;
    }
}
