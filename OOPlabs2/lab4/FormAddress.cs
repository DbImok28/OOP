using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab4
{
    public partial class FormAddress : Form
    {
        public FormAddress(DataController dataController)
        {
            data = dataController;
            factory = new BrestAddressFactory();
            InitializeComponent();
            RefreshTable();
        }
        private void button_add_adress_Click(object sender, EventArgs e)
        {
            try
            {
                var address = factory.CreateAddress(
                    textBox_District.Text,
                    textBox_Street.Text,
                    textBox_House.Text,
                    textBox_Building.Text,
                    textBox_ApartmentNumber.Text
                    );
                dataGridView_addreses.Rows.Add(
                    address.Country, 
                    address.City, 
                    address.District, 
                    address.Street, 
                    address.House, 
                    address.Building, 
                    address.ApartmentNumber
                    );
                data.AddAddress(address);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }
        public void RefreshTable()
        {
            foreach (var item in data.addresses)
            {
                dataGridView_addreses.Rows.Add(
                                item.Country,
                                item.City,
                                item.District,
                                item.Street,
                                item.House,
                                item.Building,
                                item.ApartmentNumber
                );
            }

        }
        private DataController data;
        private IAddressFactory factory;
    }
}
