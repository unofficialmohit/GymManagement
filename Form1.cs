using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;
            if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value2))
            {
                if (value1 == "mohit" && value2 == "mohit")
                {
                  
                 this.Hide();
                 new Menu().Show();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password.");
                }
            }
            else
            {
                MessageBox.Show("Please fill in all values.");
            }

        }
    }
}
