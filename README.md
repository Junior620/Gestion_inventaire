# Application de Gestion de Stock – WinForms + PostgreSQL

## 🎯 Objectif
Cette application permet de gérer efficacement les stocks de produits d’un magasin :
- Suivi des produits (nom, prix, stock, seuil)
- Mouvements d’entrées / sorties
- Alerte automatique pour les stocks faibles
- Notifications avec sons
- Exports Excel / PDF
- Tableau de bord analytique

## 🏗️ Architecture
- **Models** : Entités comme `Produit`, `MvtStocks`, `Notification`
- **DataAccess** : Accès à la BD PostgreSQL
- **Controllers** : Logique métier
- **Views** : Interfaces utilisateur WinForms
- **Services** : Génération d’exports, alertes

## 🧩 Fonctionnalités clés
- Authentification avec rôle utilisateur
- Interface Produit : Ajout, modification, suppression
- Mouvement : Entrée / sortie avec vérification du stock
- Notifications : stock faible avec sons et filtres
- Export structuré : Excel multi-feuilles + PDF
- Tableau de bord : statistiques dynamiques, graphique journalier

## 🔧 Technologies utilisées
- C# (WinForms)
- PostgreSQL
- EPPlus (.xlsx)
- iTextSharp (.pdf)
- Chart .NET
- SoundPlayer (.wav)

## ✅ Améliorations envisagées
- Ajout d’un système de rôles plus avancé
- Export automatique par email
- Interface web (Blazor, ASP.NET MVC)
