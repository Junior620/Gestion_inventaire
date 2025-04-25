using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Path: Models/Produits.cs
// Représente un produit en stock (nom, prix, quantité, seuil...)

namespace Gestion_inventaire.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Categorie { get; set; }
        public int QuantiteEnStock { get; set; }
        public int SeuilAlerte { get; set; }
        public decimal PrixUnitaire { get; set; }
    }
}
