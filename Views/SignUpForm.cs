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
using Gestion_inventaire.Models;

namespace Gestion_inventaire.Views
{
    public partial class SignUpForm : Form
    {
        public SignUpForm()
        {
            InitializeComponent();
        }

        public class Produit
        {
            public string Type { get; set; }
        }

            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Username_TextChanged(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void signup_button_Click(object sender, EventArgs e)
        {
            var utilisateur = new Utilisateur
            {
                Nom = Username.Text,
                Login = email.Text,
                MotDePasse = password.Text,
                Role = cmbAgentAdmin.Text
            };

            var auth = new AuthControllers();
            if (auth.Inscrire(utilisateur))
            {
                System.Windows.Forms.MessageBox.Show("Inscription réussie !");
                this.Hide();
                new LoginFormUI().Show();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ce login existe déjà.");
            }
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            cmbAgentAdmin.Items.Clear(); // vide les anciens items si déjà chargés

            cmbAgentAdmin.Items.AddRange(new string[] { "Agent", "Admin" });
            cmbAgentAdmin.DropDownStyle = ComboBoxStyle.DropDownList; // empêche la saisie libre
            cmbAgentAdmin.SelectedIndex = 0; // facultatif : sélectionne un rôle par défaut
        }

        private void cmbAgentAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Load += new System.EventHandler(this.SignUpForm_Load);

        }
    }
}
