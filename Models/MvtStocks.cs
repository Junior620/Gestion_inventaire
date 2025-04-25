using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Gestion_inventaire.Models
    {

        public class MvtStocks
        {
            public int Id { get; set; }
            public int ProduitId { get; set; }
            public string Type { get; set; } // "ENTREE" ou "SORTIE"
            public int QuantiteEnStock { get; set; }
            public DateTime DateOperation { get; set; }
            public string Remarque { get; set; }
            public int? UtilisateurId { get; set; }
        }

    public class MouvementDisplay
    {
        public string Type { get; set; }
        public string Produit { get; set; }
        public int Quantite { get; set; }
        public DateTime DateHeure { get; set; }
        public string Remarque { get; set; }
        public int ProduitId { get; set; }  // important pour filtrer

    }

}

