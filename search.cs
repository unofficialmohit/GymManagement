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
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet4.gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter.Fill(this.gymDataSet4.gym);
            // TODO: This line of code loads data into the 'gymDataSet.gym' table. You can move, or remove it, as needed.
           

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string filterValue = textBox1.Text; // Get the value from textbox1

            // Build the filter expression using the filterValue
            string filterExpression = $"username LIKE '%{filterValue}%'";

            DataRow[] filteredRows = gymDataSet4.Tables[0].Select(filterExpression);

            if (filteredRows.Length > 0)
            {
                DataTable filteredTable = filteredRows.CopyToDataTable();
                dataGridView1.DataSource = filteredTable;
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }
    }
}
