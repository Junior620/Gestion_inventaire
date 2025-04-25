using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.DataAccess;
using Npgsql;
using Gestion_inventaire.Models;
using Gestion_inventaire.Views;

// Contient les opérations sur les produits (ajouter, modifier, supprimer, rechercher…).
// Ce fichier contient la logique métier pour gérer les produits dans l'application.
// Il agit comme un intermédiaire entre la couche de données (repository) et les interfaces utilisateur.

namespace Gestion_inventaire.Controllers
{
    public class ProduitController
    {
        // Références vers les classes de repository qui gèrent l'accès aux données
        private readonly HistoriqueRepository historiqueRepo = new HistoriqueRepository();

        private readonly ProduitRepository repo = new ProduitRepository();

        // Méthode pour récupérer tous les produits enregistrés
        public List<Produit> ObtenirTous()
        {
            return repo.GetAll();
        }

        // Méthode pour ajouter un nouveau produit dans la base de données
        public bool AjouterProduit(Produit produit)
        {
            return repo.AjouterProduit(produit);
            
        }

        // Méthode pour modifier les informations d’un produit existant
        public bool ModifierProduit(Produit produit)
        {
            return repo.ModifierProduit(produit);
        }

        // Méthode pour supprimer un produit de la base de données via son ID
        public bool SupprimerProduit(int id)
        {
            return repo.SupprimerProduit(id);
        }

        // Méthode de recherche : retourne une liste de produits dont le nom contient le texte saisi
        public List<Produit> RechercherParNom(string nom)
        {
            var tous = repo.GetAll();
            return tous.FindAll(p => p.Nom.ToLower().Contains(nom.ToLower()));
        }
    }
}
