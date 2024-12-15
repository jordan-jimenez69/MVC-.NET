Application de Gestion des Événements
Cette application permet de gérer des événements, avec des fonctionnalités de création, modification, suppression et consultation.
Elle utilise ASP.NET Core MVC, avec Entity Framework Core pour l'accès à la base de données et ASP.NET Identity pour la gestion
des utilisateurs et des rôles (enseignants et étudiants).

Prérequis
.net8.0 : Télécharger .NET

1. Cloner le projet
git clone https://github.com/jordan-jimenez69/MVC-.NET.git

2. Modifier appsettings.son
{
  "ConnectionStrings": {
    "DefaultConnection": "server=127.0.0.1;database=SchoolDB;user=root;password="
  },
Avec vos identifiants de votre base de données.
Puis lancer ses lignes dans le terminal de votre editeur : 
- dotnet ef migrations add Initial 
- dotnet ef database update 

3. Lancer l'application
Une fois que vous avez configuré la base de données.

Fonctionnalités principales
Connexion et Inscription :

Les utilisateurs peuvent s'inscrire en tant qu'enseignant (Teacher) ou étudiant (Student).
Les enseignants peuvent créer des événements, les modifier et les supprimer.
Les étudiants peuvent consulter les événements existants.

Gestion des événements :
Les événements peuvent être filtrés par date.
Les enseignants peuvent créer, modifier et supprimer des événements.
Les étudiants peuvent voir tous les événements créés.

Pages principales :
Page d'accueil : Liste des événements (accessible à tous les utilisateurs connectés).
Détails de l'événement : Permet de consulter les informations détaillées sur un événement.
Création et modification d'événements : Seulement accessible aux enseignants.

Structure du code
Voici une brève explication de la structure des fichiers du projet :

Controllers : Contient la logique de chaque page, comme la gestion des événements ou des utilisateurs.
Models : Contient les classes représentant les entités de votre application, comme Event, AccountModel, et Student.
Views : Contient les vues (pages HTML) utilisées pour afficher les informations dans le navigateur.
Data : Contient la configuration de la base de données et des rôles.
