using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.DataAccess;
using Gestion_inventaire.Models;

namespace Gestion_inventaire.Controllers
{
    /// Contrôleur responsable de la gestion des mouvements de stock.
    /// Il communique avec la couche DataAccess via MouvementRepository.
    public class MouvementController
    {
        // Référence vers le repository pour exécuter les requêtes SQL sur les mouvements
        private readonly MouvementRepository repo;

        /// Constructeur avec injection de chaîne de connexion (string).
        public MouvementController(string connectionString)
        {
            repo = new MouvementRepository(connectionString);
        }

        /// Ajoute un nouveau mouvement dans la base de données via le repository.
        /// La date du mouvement est automatiquement définie à la date actuelle.
        public bool AjouterMouvement(MvtStocks mouvement)
        {
            mouvement.DateOperation = DateTime.Now;
            return repo.AjouterMouvement(mouvement);
        }

        /// Récupère la liste des mouvements à afficher (mouvement d’entrée ou de sortie).
        public List<MouvementDisplay> ObtenirTousLesMouvements()
        {
            return repo.ObtenirTousLesMouvements();
        }
    }
}
