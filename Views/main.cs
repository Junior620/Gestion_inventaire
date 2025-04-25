using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_inventaire.Views;

namespace Gestion_inventaire
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            var SignUpForm = new SignUpForm();
            SignUpForm.Show();
            this.Hide(); // Hide the current form
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            var LoginFormUI = new LoginFormUI();
            LoginFormUI.Show();
            this.Hide(); // Hide the current form
        }
    }
}
