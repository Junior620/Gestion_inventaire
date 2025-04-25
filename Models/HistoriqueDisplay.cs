using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_inventaire.Models
{
    public class HistoriqueDisplay
    {
        public DateTime Date { get; set; }
        public string Action { get; set; }
        public string Produit { get; set; }
        public int Quantite { get; set; }
    }

}
