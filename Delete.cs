using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymManagement
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string username = selectedRow.Cells[0].Value.ToString();
                string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM gym WHERE username = @uname";

                    using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@uname", username);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Membership of "+ username+" Removed successfully.");
                            dataGridView1.Rows.Remove(selectedRow); // Remove the row from the DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the Membership.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No row selected.");
            }
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'gymDataSet5.gym' table. You can move, or remove it, as needed.
            this.gymTableAdapter.Fill(this.gymDataSet5.gym);
            // TODO: This line of code loads data into the 'gymDataSet1.gym' table. You can move, or remove it, as needed.
           
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


        }
    }
}
