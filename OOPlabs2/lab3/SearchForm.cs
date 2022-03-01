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
            Find(item => item.NumberOfRooms.ToString());
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Find(item => item.YearOfConstruction.ToString());
            Close();
        }

        private void button_city_Click(object sender, EventArgs e)
        {
            Find(item => item.AddressOfRoom.City);
            Close();
        }

        private void button_District_Click(object sender, EventArgs e)
        {
            Find(item => item.AddressOfRoom.District);
            Close();
        }
        public void Find(Func<Apartment, string> field)
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
                data = result;              
                //new ResultSearchForm(result).ShowDialog();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }
        public List<Apartment> data { get; private set; }
    }
}
