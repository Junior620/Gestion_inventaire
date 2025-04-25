using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Gestion_inventaire.DataAccess;

namespace Gestion_inventaire.Services
{

    /// Classe statique responsable de la gestion des notifications système.
    /// Elle génère des alertes et joue un son lorsqu'une nouvelle notification importante apparaît.
    public static class NotificationManager
    {
        // Stocke l'identifiant de la dernière notification pour éviter de rejouer plusieurs fois le son
        private static int dernierIdNotificationLue = 0;

        // Accès à la base des notifications
        private static readonly NotificationRepository repo = new NotificationRepository();


        /// Vérifie s'il y a de nouvelles alertes de stock faible.
        /// Si une nouvelle notification est détectée, elle déclenche un son.
        public static void VerifierEtGenererAlertes()
        {
            var repo = new NotificationRepository();

            // Génère automatiquement des notifications pour les produits dont le stock est faible
            repo.GenererNotificationStockFaible();

            // Récupérer la dernière notification non lue (s'il y en a)
            var derniereNonLue = repo.GetDerniereNotificationNonLue();

            // Si une nouvelle notification non lue est disponible, on joue un son
            if (derniereNonLue != null && derniereNonLue.Id > dernierIdNotificationLue)
            {
                JouerSonAlerte();
                dernierIdNotificationLue = derniereNonLue.Id;
            }
        }

        private static void JouerSonAlerte()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("alerte.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                // Gérer erreur si fichier introuvable
            }
        }

    }
}
