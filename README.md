# Gestion Interne – Application de gestion d’équipements TI

🇫🇷 Français | 🇬🇧 [English](README.en.md) | 🇪🇸 [Español](README.es.md)

<p align="center">
  <img src="https://upload.wikimedia.org/wikipedia/commons/5/5f/Flag_of_Quebec.svg" width="120">
</p>


---

## Contexte

Cette application simule une application interne utilisée dans une entreprise industrielle québécoise
pour la gestion des équipements TI et de leurs affectations aux employés ou aux départements.

Le projet est conçu dans un contexte réaliste d’entreprise, où les applications internes doivent être :

- Simples  
- Fiables  
- Maintenables  
- Cohérentes avec les processus métier  

L’objectif n’est pas de créer une interface complexe, mais une application claire et professionnelle.

---

## Objectif du projet

Démontrer la conception et le développement d’une application web interne basée sur :

- Une architecture MVC propre
- Une base de données relationnelle
- Une gestion cohérente des statuts et des affectations
- Un environnement reproductible avec Docker
- Une séparation claire des responsabilités

Ce projet reflète une approche pragmatique orientée vers les besoins réels d’une entreprise industrielle.

---

## Fonctionnalités

### Gestion des équipements
- Création, modification, consultation et suppression (CRUD)
- Gestion du statut via un catalogue (Disponible, Assigné, En réparation)
- Date d’achat optionnelle :
  - Affichage « À définir » si non renseignée
  - Validation empêchant une date future

### Gestion des affectations
- Création, modification, consultation et suppression (CRUD)
- Relation avec les équipements (clé étrangère)
- Statut via catalogue (Actif, Terminé, En attente)
- Date de fin optionnelle :
  - Affichage « En attente de date de fin » si non renseignée

### Interface
- Interface complète en français
- Navigation cohérente
- Pages Accueil et Confidentialité adaptées au contexte interne

---

## Stack technique

- ASP.NET Core MVC (.NET 8)
- C#
- Entity Framework Core
- SQL Server
- Docker (base de données en local)
- Azure Data Studio (visualisation et gestion de la base)
- Bootstrap (interface simple issue du template MVC)
- Git & GitHub

---

## Architecture

- Pattern MVC (Models, Views, Controllers)
- Injection de dépendances native ASP.NET Core
- Base de données relationnelle
- Chargement explicite des relations via `Include`
- Validation métier via Data Annotations

L’application privilégie la lisibilité du code et la maintenabilité.

---

## Démarrage local

### Prérequis

- .NET 8 SDK
- Docker Desktop

### 1. Démarrer SQL Server (Docker)

Lancer votre conteneur SQL Server.

### 2. Vérifier la chaîne de connexion

Dans `appsettings.json` :

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=GestionInterneDb;User Id=sa;Password=StrongPassw0rd123;TrustServerCertificate=True;"
}
```
### 3. Appliquer les migrations

Exécuter :

dotnet ef database update

### 4. Lancer l’application

Exécuter :

dotnet run

---

## Portée du projet

Ce projet est volontairement simple afin de :

- Refléter une application interne réaliste
- Mettre l’accent sur la structure et la cohérence
- Éviter la complexité inutile

Il peut être étendu avec :

- Authentification
- Gestion des rôles
- API REST
- Journalisation avancée
- Déploiement cloud

---

## Auteur

Formation universitaire complétée en ingénierie des systèmes (Guatemala).  
Projet développé dans un contexte d’intégration au marché TI québécois.
