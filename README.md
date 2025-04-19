

## 📚 Sommaire

## 📝 Recommandations de développement

### ✅ Bonnes pratiques à adopter

- Nous avons choisi une structure claire, inspirée du modèle **MVC adapté à WinForms**, pour mieux organiser notre code :
  - **Models** : représentent les données métier (produits, utilisateurs…).
  - **Controllers** : contiennent la logique métier (CRUD, authentification…).
  - **Views** : gèrent uniquement l’interface utilisateur, sans inclure de logique métier.

- Nous veillons à ne pas inclure de logique "intelligente" dans les formulaires. Chaque composant a un rôle bien défini pour faciliter la maintenance et la clarté du projet.

---

## 📦 Gestion des données (à intégrer)

- Nous prévoyons d’ajouter une classe `AppDbContext.cs` pour gérer la connexion à notre base de données, idéalement avec **SQL Server**.
- Nous mettrons en place un service `NotificationService.cs` pour afficher des messages d’alerte ou d’information (par exemple via `MessageBox` ou un système de toast).
- Nous allons aussi créer un `ExportService.cs` pour permettre l’exportation des données :
  - En **PDF**, avec des bibliothèques comme `iTextSharp` ou `PdfSharp`
  - En **Excel**, à l’aide de `EPPlus`, connu pour sa simplicité et son efficacité

---

## 🎯 Pistes d'amélioration pour la suite

- Nous envisageons d’ajouter une gestion des rôles (par exemple : Admin, Employé) afin de mieux sécuriser les accès selon les profils utilisateurs.
- Nous souhaitons également intégrer un système de **journalisation des actions**, pour garder une trace des opérations effectuées par les utilisateurs.
- Enfin, nous pensons rendre l’interface plus adaptable, notamment en préparant une évolution vers **.NET MAUI** afin de viser des écrans de toutes tailles et des plateformes multiples.

---

## 🧪 Tests & qualité du code

- Nous allons implémenter des **tests unitaires** sur nos contrôleurs, en utilisant des outils comme `NUnit`, pour garantir la stabilité du projet.
- Nous mettrons aussi en place des vérifications simples pour assurer la cohérence des données saisies (exemples : champs obligatoires, quantités positives, etc.).

