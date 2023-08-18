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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=MOHIT\\SQLEXPRESS;Initial Catalog=gym;Integrated Security=True";
            string value1 = textBox1.Text;
            string subtime = comboBox1.SelectedItem.ToString();
            string plan = comboBox2.SelectedItem.ToString();
            string value4 = textBox4.Text;
            string value5 = textBox5.Text;
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

            DateTime currentDate = DateTime.Now;
            string cDate = currentDate.ToString("yyyy-MM-dd");
            string edate="";
            int price = 0;
            if(subtime== "01 Month")
            {
                edate= currentDate.AddDays(30).ToString("yyyy-MM-dd"); 
                price = price + 500;
            }
            else if(subtime== "02 Months")
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

            if(comboBox2.SelectedIndex==0)
            {
                price = price +0;
            }
            else if(comboBox2.SelectedIndex == 1)
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
                if (!string.IsNullOrEmpty(value1) && !string.IsNullOrEmpty(value4) && !string.IsNullOrEmpty(value5))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO gym VALUES (@Value1, @Value2, @Value3, @Value4, @Value5, @Value6, @Value7)";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Value1", value1);
                            command.Parameters.AddWithValue("@Value2", cDate);
                            command.Parameters.AddWithValue("@Value3", edate);
                            command.Parameters.AddWithValue("@Value4", plan);
                            command.Parameters.AddWithValue("@Value5", value4);
                            command.Parameters.AddWithValue("@Value6", value5);
                            command.Parameters.AddWithValue("@Value7", cDate);


                            connection.Open();
                            if (textBox5.Text.Length > 0 && textBox5.Text.Trim().Length != 0)
                            {
                                if (!rEmail.IsMatch(textBox5.Text.Trim()))
                                {
                                    MessageBox.Show("INVALID EMAIL ID");

                                }
                                else if(value1.Length>50 || value1.Length <5)
                                {
                                    MessageBox.Show("username must be between 5 and 50");
                                }
                                else
                                {
                                    int rowsAffected = command.ExecuteNonQuery();
                                    if (rowsAffected > 0)
                                    {
                                        MessageBox.Show("Total Amount = "+price+"$");
                                        MessageBox.Show("Registration Successful");
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to insert data.");
                                    }
                                }
                            }


                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please fill in all values.");
                }
            }
          catch
           {

              MessageBox.Show("Invalid Details");
          }
        }

        private void TextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
