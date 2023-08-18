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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
            new register().Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
        
            new search().Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            
            new renew().Show();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
           
            new Delete().Show();
        }
    }
}
