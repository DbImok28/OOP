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
    public partial class ResultSearchForm : Form
    {
        public ResultSearchForm(List<Apartment> data)
        {
            this.data = data;
            InitializeComponent();
            UpdateTable();
        }
        List<Apartment> data;
        private void button_search_Click(object sender, EventArgs e)
        {
            var form = new SearchForm(data);
            form.ShowDialog();
            data = form.data;
            UpdateTable();
        }
        public void UpdateTable()
        {
            dataGridView_Apartaments.Rows.Clear();
            foreach (var item in data)
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
            Update();
        }

    }
}
