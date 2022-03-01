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
            SetTitle("Open");
        }
        private DataController data;
        public static int CalcPrice(Apartment item)
        {
            int price = 0;
            price += item.Footage * 800;
            price += Convert.ToInt32(item.Kitchen) * 500;
            price += Convert.ToInt32(item.Bath) * 150;
            price += Convert.ToInt32(item.Toilet) * 50;
            price += Convert.ToInt32(item.Basement) * 100;
            price += Convert.ToInt32(item.Balcony) * 50;
            price += (item.YearOfConstruction - DateTime.Now.Year) * 10;
            return price;
        }
        public void SetTitle(string title)
        {
            Text = "";
            Text = title;
            Text += ", ";
            Text += DateTime.Now.ToString();

        }

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
                data.AddApartment(apartment);
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
                SetTitle("Add Apartment");
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
                                CalcPrice(item),
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
            SetTitle("Save");
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            dataGridView_Apartaments.Rows.Clear();
            data.Load();
            RefreshTable();
            SetTitle("Load");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new SearchForm(data.apartments);
            form.ShowDialog();
            new ResultSearchForm(form.data).ShowDialog();
            SetTitle("Search");
        }

        private void button_SortByFootage_Click(object sender, EventArgs e)
        {
            dataGridView_Apartaments.Sort(dataGridView_Apartaments.Columns[0], checkBox_SortByDescending.Checked ? ListSortDirection.Descending : ListSortDirection.Ascending);
            var sorted = checkBox_SortByDescending.Checked ? data.apartments.OrderByDescending(x => x.Footage) : data.apartments.OrderBy(x => x.Footage);
            DataController.Save(new List<Apartment>(sorted), "Sorted.xml");
            SetTitle("Sort");
        }

        private void button_SortByNumberOfRooms_Click(object sender, EventArgs e)
        {
            //data.apartments.OrderBy(x => x.NumberOfRooms);
            dataGridView_Apartaments.Sort(dataGridView_Apartaments.Columns[1], checkBox_SortByDescending.Checked ? ListSortDirection.Descending : ListSortDirection.Ascending);
            var sorted = checkBox_SortByDescending.Checked ? data.apartments.OrderByDescending(x => x.NumberOfRooms) : data.apartments.OrderBy(x => x.NumberOfRooms);
            DataController.Save(new List<Apartment>(sorted), "Sorted.xml");
            SetTitle("Sort");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView_Apartaments.Sort(dataGridView_Apartaments.Columns[2], checkBox_SortByDescending.Checked ? ListSortDirection.Descending : ListSortDirection.Ascending);
            var sorted = checkBox_SortByDescending.Checked ? data.apartments.OrderByDescending(x => CalcPrice(x)) : data.apartments.OrderBy(x => CalcPrice(x));
            DataController.Save(new List<Apartment>(sorted), "Sorted.xml");
            SetTitle("Sort");
        }

        private void button_LoadSorted_Click(object sender, EventArgs e)
        {
            dataGridView_Apartaments.Rows.Clear();
            data.Load("Sorted.xml");
            RefreshTable();
            SetTitle("Load Sorted");
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            data.apartments.Clear();
            dataGridView_Apartaments.Rows.Clear();
            SetTitle("Clear");
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Якушик Павел 2курс 2группа ФИТ 2022, Версия 2.0", "О программе");
        }

        private void hideAndShow_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible)
            {
                menuStrip1.Hide();
                hideAndShow.Text = "Показать";
            }
            else
            {
                menuStrip1.Show();
                hideAndShow.Text = "Скрыть";
            }
        }
    }
}
