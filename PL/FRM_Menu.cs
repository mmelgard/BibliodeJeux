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
    public partial class FRM_Menu : Form
    {
        public FRM_Menu()
        {
            InitializeComponent();
            panel1.Size = new Size(375, 622);
            pnlParamettrer.Visible = false;
        }

        //désactiver les boutons du menu
        public void desactiverForm()
        {
            btnbibliotheque.Enabled = false;
            btnclient.Enabled = false;
            btnutilisateur.Enabled = false;
            btndecoonecter.Enabled = false;
            pnlBut.Enabled = false;
            //connecter activer
            btnconnecter.Enabled = true;
        }

        //activer les boutons du menu
        public void activerForm()
        {
            btnbibliotheque.Enabled = true;
            btnclient.Enabled = true;
            btnutilisateur.Enabled = true;
            btndecoonecter.Enabled = true;
            pnlBut.Enabled = true;
            //connecter désactiver
            btnconnecter.Enabled = false;
            pnlParamettrer.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(panel1.Width == 375)
            {
                panel1.Size = new Size(100, 622);
            }
            else
            {
                panel1.Size = new Size(375, 622);
            }
        }

        private void btnbibliotheque_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnbibliotheque.Top;
        }

        private void btnclient_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnclient.Top;
            if(!pnlaficher.Controls.Contains(USER_Liste_Client.Instance))
            {
                pnlaficher.Controls.Add(USER_Liste_Client.Instance);
                USER_Liste_Client.Instance.Dock = DockStyle.Fill;
                USER_Liste_Client.Instance.BringToFront();
            }
            else
            {
                USER_Liste_Client.Instance.BringToFront();
            }
        }

        private void btnutilisateur_Click(object sender, EventArgs e)
        {
            pnlBut.Top = btnutilisateur.Top;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnparamettre_Click(object sender, EventArgs e)
        {
            pnlParamettrer.Size = new Size(316, 105);
            pnlParamettrer.Visible = !pnlParamettrer.Visible;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Afficher le formulaire de connexion
            FRM_Connexion frmC = new FRM_Connexion(this);// this = le formulaire actuel
            frmC.ShowDialog();
        }

        private void FRM_Menu_Load(object sender, EventArgs e)
        {
            desactiverForm();
        }

        private void btndecoonecter_Click(object sender, EventArgs e)
        {
            desactiverForm();
        }
    }
}
