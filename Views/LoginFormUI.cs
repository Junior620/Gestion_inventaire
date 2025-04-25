using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gestion_inventaire.Controllers;
using Gestion_inventaire.DataAccess;

namespace Gestion_inventaire.Views
{
    public partial class LoginFormUI : Form
    {
        public LoginFormUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            var auth = new AuthControllers();
            var utilisateur = auth.Connecter(email.Text, password.Text);

            if (utilisateur != null)
            {
                SessionManager.DemarrerSession(utilisateur);
                System.Windows.Forms.MessageBox.Show($"Bienvenue {utilisateur.Nom} ({utilisateur.Role})");

                this.Hide();
                if (utilisateur.Role == "Admin")
                    new DashboardForm().Show();
                else
                    new ProduitsForm().Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Identifiants incorrects");
            }
        }
    }
}
