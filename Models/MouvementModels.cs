using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Gestion_inventaire.Models;
using Gestion_inventaire.DataAccess;

namespace Gestion_inventaire.Models
{
    using System;

    namespace Gestion_inventaire.Models
    {
        // Correspond à la table MouvementsStock
        public class MouvementStock
        {
            public int Id { get; set; }
            public int ProduitId { get; set; }
            public string Type { get; set; } // "ENTREE" ou "SORTIE"
            public int QuantiteEnStock { get; set; }
            public DateTime DateOperation { get; set; }
            public int? UtilisateurId { get; set; }
            public string Remarque { get; set; }
        }

        // Classe d'affichage dans la grille (avec le nom du produit au lieu de l'ID)
        
    }

}
