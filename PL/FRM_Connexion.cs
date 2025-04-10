using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BibliodeJeux.PL
{
    public partial class FRM_Connexion : Form
    {
        private dbJeux db;
        private Form frmmenu;
        // instancier un objet de la classe CLS_Connexion
        BL.CLS_Connexion C = new BL.CLS_Connexion();
        public FRM_Connexion(Form Menu)
        {
            InitializeComponent();
            db = new dbJeux();
            this.frmmenu = Menu;
        }

        //pour vérifier les champs obligatoires
        string testobligatoire()
        {
            bool nomVide = string.IsNullOrWhiteSpace(txtNom.Text) || txtNom.Text == "Nom d'utilisateur";
            bool motDePasseVide = string.IsNullOrWhiteSpace(txtmotdepasse.Text) || txtmotdepasse.Text == "Mot de passe";

            if (nomVide && motDePasseVide)
            {
                return "Veuillez remplir les deux champs.";
            }
            if (nomVide)
            {
                return "Entrer votre nom d'utilisateur";
            }
            if (motDePasseVide)
            {
                return "Entrer votre mot de passe";
            }
            return null;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnquitter_Click(object sender, EventArgs e)
        {
            //Quittere le formulaire
            this.Close();
        }

        private void txtNom_Enter(object sender, EventArgs e)
        {
            //Pour vider le text box
            if(txtNom.Text == "Nom d'utilisateur")
            {
                txtNom.Text = "";
                txtNom.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtmotdepasse_Enter(object sender, EventArgs e)
        {
            if(txtmotdepasse.Text == "Mot de passe")
            {
                txtmotdepasse.Text = "";
                txtmotdepasse.UseSystemPasswordChar = false;
                txtmotdepasse.PasswordChar = '*';
                txtmotdepasse.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtNom_Leave(object sender, EventArgs e)
        {
            if(txtNom.Text == "")
            {
                txtNom.Text = "Nom d'utilisateur";
                txtNom.ForeColor = Color.Silver;
            }
        }

        private void txtmotdepasse_Leave(object sender, EventArgs e)
        {
            if(txtmotdepasse.Text == "")
            {
                txtmotdepasse.Text = "Mot de passe";
                txtmotdepasse.UseSystemPasswordChar = true; //désactiver le mot de passe
                txtmotdepasse.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          if(testobligatoire() == null)
            {
                if (C.ConnexionValide(db, txtNom.Text, txtmotdepasse.Text)== true) // l'utilisateur existe dans la base
                {
                    MessageBox.Show("Connexion réussie", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    (frmmenu as FRM_Menu).activerForm();
                    this.Close(); //fermer le formulaire
                }
                else
                {
                    MessageBox.Show("Connexion échoué", "Connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(testobligatoire(), "Obligtoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
