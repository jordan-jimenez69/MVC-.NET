Application de Gestion des Événements
Cette application permet de gérer des événements, avec des fonctionnalités de création, modification, suppression et consultation. Elle utilise ASP.NET Core MVC, avec Entity Framework Core pour l'accès à la base de données et ASP.NET Identity pour la gestion des utilisateurs et des rôles (enseignants et étudiants).

Prérequis
Avant de pouvoir utiliser l'application, vous devez vous assurer que vous avez les éléments suivants installés sur votre machine :

.NET 6.0 ou une version supérieure : Télécharger .NET
Visual Studio ou un autre éditeur de code compatible avec .NET (par exemple, Visual Studio Code) : Télécharger Visual Studio
SQL Server ou une autre base de données compatible pour héberger les données (SQL Server Express est suffisant pour le développement).
Installation
1. Cloner le projet
Pour commencer, vous devez cloner ce projet sur votre machine. Utilisez la commande suivante dans votre terminal ou invite de commande :

bash
Copier le code
git clone https://votre-url-de-dépôt.git
2. Ouvrir le projet
Ouvrez le dossier du projet dans Visual Studio ou votre éditeur de code préféré.

3. Configurer la base de données
L'application utilise Entity Framework Core pour gérer la base de données. Pour configurer la base de données, suivez ces étapes :

Ouvrez le Package Manager Console (dans Visual Studio : Outils > Gestionnaire de package NuGet > Console du gestionnaire de package).
Exécutez la commande suivante pour appliquer les migrations et créer la base de données :
bash
Copier le code
Update-Database
Cela va créer la base de données et les tables nécessaires (dont celles pour les utilisateurs et les événements).

4. Créer les rôles
Une fois la base de données en place, il faut initialiser les rôles (Teacher et Student). Pour cela, l'application contient une méthode qui crée ces rôles automatiquement lors du démarrage. Cependant, vous pouvez aussi exécuter manuellement une commande pour vous assurer qu'ils existent.

Si nécessaire, ajoutez ces rôles en exécutant le code suivant dans le Program.cs (dans la méthode Configure):

csharp
Copier le code
RoleInitializer.InitializeRoles(serviceProvider).Wait();
Cela s'assurera que les rôles sont créés dans votre base de données.

5. Configurer l'authentification
L'application utilise ASP.NET Identity pour la gestion des utilisateurs. Vous pouvez créer un utilisateur "Teacher" ou "Student" en utilisant l'interface d'inscription de l'application. L'utilisateur "Teacher" aura accès à la gestion des événements (création, modification, suppression), tandis que l'utilisateur "Student" pourra seulement consulter les événements.

Lancer l'application
Une fois que vous avez configuré la base de données et les rôles, vous pouvez lancer l'application :

Appuyez sur F5 ou cliquez sur le bouton Démarrer dans Visual Studio pour exécuter l'application.
L'application s'ouvrira dans votre navigateur par défaut. Vous serez redirigé vers une page de connexion si vous n'êtes pas encore connecté.

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
Résolution des problèmes
Erreur de rôle manquant ?

Assurez-vous que les rôles sont bien créés dans la base de données en utilisant RoleInitializer si nécessaire.
Problèmes de connexion ?

Vérifiez que l'utilisateur dispose du bon rôle (Teacher ou Student).
Problèmes de base de données ?

Si vous rencontrez des erreurs liées à la base de données, essayez de réexécuter Update-Database pour appliquer les migrations.
Conclusion
Ce projet est une application simple de gestion des événements avec des fonctionnalités de base. Elle permet aux utilisateurs d'ajouter, consulter, modifier et supprimer des événements en fonction de leur rôle (enseignant ou étudiant).

Si vous avez des questions ou des problèmes, n'hésitez pas à consulter la documentation officielle de ASP.NET Core ou à me contacter.
