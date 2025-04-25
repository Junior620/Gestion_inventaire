using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Path: Models/Utilisateurs.cs
// // Représente un utilisateur (nom, prénom, mot de passe, rôle...)

namespace Gestion_inventaire.Models
{
    //internal class Utilisateurs
    //{}
    public class Utilisateur
    {
        public int Id { get; set; }  // 
        public string Nom { get; set; }
        public string Login { get; set; }
        public string MotDePasse { get; set; }
        public string Role { get; set; } // Exemple : "Admin" ou "Agent"
    }
}
