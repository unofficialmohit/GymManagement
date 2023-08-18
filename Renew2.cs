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
    public partial class Renew2 : Form
    {
        public Renew2(String s)
        {
            InitializeComponent();
            string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM gym WHERE username = @uname";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@uname", s);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string username = reader["username"].ToString();
                            string email = reader["email"].ToString();
                            string contact = reader["contact"].ToString();
                            textBox1.Text = username;
                            textBox4.Text = contact;
                            textBox5.Text = email;

                        }
                        else
                        {
                            MessageBox.Show("No record found.");
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Renew2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True";
            string username = textBox1.Text;
            string subtime = comboBox1.SelectedItem.ToString();
            string plan = comboBox2.SelectedItem.ToString();
            DateTime currentDate = DateTime.Now;
            string rdate = currentDate.ToString("yyyy-MM-dd");
            string edate = "";
            int price = 0;
            if (subtime == "01 Month")
            {
                edate = currentDate.AddDays(30).ToString("yyyy-MM-dd");
                price = price + 500;
            }
            else if (subtime == "02 Months")
            {
                edate = currentDate.AddDays(60).ToString("yyyy-MM-dd");
                price = price + 1000;
            }
            else if (subtime == "03 Months")
            {
                edate = currentDate.AddDays(90).ToString("yyyy-MM-dd");
                price = price + 1500;
            }
            else if (subtime == "04 Months")
            {
                edate = currentDate.AddDays(120).ToString("yyyy-MM-dd");
                price = price + 2000;
            }
            else if (subtime == "05 Months")
            {
                edate = currentDate.AddDays(150).ToString("yyyy-MM-dd");
                price = price + 2500;
            }
            else if (subtime == "06 Months")
            {
                edate = currentDate.AddDays(180).ToString("yyyy-MM-dd");
                price = price + 3000;
            }
            else if (subtime == "07 Months")
            {
                edate = currentDate.AddDays(210).ToString("yyyy-MM-dd");
                price = price + 3500;
            }
            else if (subtime == "08 Months")
            {
                edate = currentDate.AddDays(240).ToString("yyyy-MM-dd");
                price = price + 4000;
            }
            else if (subtime == "09 Months")
            {
                edate = currentDate.AddDays(270).ToString("yyyy-MM-dd");
                price = price + 4500;
            }
            else if (subtime == "10 Months")
            {
                edate = currentDate.AddDays(300).ToString("yyyy-MM-dd");
                price = price + 5000;
            }
            else if (subtime == "11 Months")
            {
                edate = currentDate.AddDays(330).ToString("yyyy-MM-dd");
                price = price + 5500;
            }
            else
            {
                edate = currentDate.AddDays(360).ToString("yyyy-MM-dd");
                price = price + 6000;
            }

            if (comboBox2.SelectedIndex == 0)
            {
                price = price + 0;
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                price = price + 400;
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                price = price + 500;
            }
            else if (comboBox2.SelectedIndex == 3)
            {
                price = price + 600;
            }
            else if (comboBox2.SelectedIndex == 4)
            {
                price = price + 700;
            }
            else
            {
                price = price + 800;
            }



            try
            {
               
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                         string query = "UPDATE gym SET enddate = @edate, renewdate = @rdate, aplan = @plan WHERE username = @uname";


                    using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@edate", edate);
                            command.Parameters.AddWithValue("@rdate", rdate);
                            command.Parameters.AddWithValue("@plan", plan);
                            command.Parameters.AddWithValue("@uname", username);



                        connection.Open();
                           
                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Total Amount = " + price + "$");
                                         MessageBox.Show("Subscription Renewed");
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to insert data.");
                                    }
                               
                            }


                        }
                    
                
               
            }
            catch
            {

                MessageBox.Show("Invalid Details");
            }
        }
    }
}
