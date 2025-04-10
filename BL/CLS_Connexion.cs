using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliodeJeux.BL
{
    class CLS_Connexion
    {
        // function pour vérifier
        public bool ConnexionValide(dbJeux db, string Nom, string MotDePasse)
        {
            User U = new User(); //instancier un objet de la classe User
            U.Username = Nom;
            U.PasswordHash = MotDePasse;
            if(db.Users.SingleOrDefault(s => s.Username == Nom && s.PasswordHash == MotDePasse) != null)//si l'utilisateur et le mot de passe existe dans la base
            {
                return true;
            }
            else // si il existe pas
            {
                return false;
            }
        }
    }
}
