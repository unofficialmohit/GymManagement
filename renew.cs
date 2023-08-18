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
    public partial class renew : Form
    {
        public renew()
        {
            InitializeComponent();
        }

        private void Renew_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet3.gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter.Fill(this.gymDataSet3.gym);
            // TODO: This line of code loads data into the 'gymDataSet2.gym' table. You can move, or remove it, as needed.
        
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.gymBindingSource.Filter = $"enddate <= '{DateTime.Now.ToString("yyyy-MM-dd")}'";

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string username = selectedRow.Cells[0].Value.ToString();
                this.Hide();
                new Renew2(username).Show();
            }
            else
            {
                MessageBox.Show("No Row Selected");


            }
        }


    }
}

