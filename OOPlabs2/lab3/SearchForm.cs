using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace lab2
{
    public partial class SearchForm : Form
    {
        public SearchForm(List<Apartment> data)
        {
            this.data = data;
            InitializeComponent();
        }

        private void button_rooms_Click(object sender, EventArgs e)
        {
            FindAndShow(item => item.NumberOfRooms.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FindAndShow(item => item.YearOfConstruction.ToString());
        }

        private void button_city_Click(object sender, EventArgs e)
        {
            FindAndShow(item => item.AddressOfRoom.City);
        }

        private void button_District_Click(object sender, EventArgs e)
        {
            FindAndShow(item => item.AddressOfRoom.District);
        }
        public void FindAndShow(Func<Apartment, string> field)
        {
            try
            {
                var findValue = textBox_Input.Text;
                List<Apartment> result = new List<Apartment>();
                foreach (var item in data)
                {
                    if (Regex.IsMatch(field(item).ToString(), findValue))
                    {
                        result.Add(item);
                    }
                }
                new ResultSearchForm(result).ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }
        private List<Apartment> data;
    }
}
