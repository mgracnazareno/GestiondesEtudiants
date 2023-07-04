# Gestion des Etudiants
Vous êtes contactés par l’administration d’une école, afin de lui réaliser une application qui permet la gestion de ses étudiants, en utilisant le logiciel Visual Studio et le langage de programmation C#.
On considère que nous avons un seul agent pour le moment, qui va gérer l’application.
Avant d’accéder à son application, l’agent doit d’abord se loguer avec un nom d’utilisateur examen et un mot de passe 1234.
Cet agent a le droit a trois tentatives erronées, sinon le programme quitte l’application.
Si le login est bon, le menu suivant sera affiché à l’agent :
 ![Picture1](https://github.com/mgracnazareno/GestiondesEtudiants/assets/47845955/175ac334-f922-4513-969c-0aecb993e292)

### Règles de fonctionnement:
1.	L’option 1: permet d’inscrire un nouvel étudiant dans la liste des étudiants, suivant le modèle suivant :
-	Id de l’étudiant 
-	Le nom et le prénom de l’étudiant
-	L’année de naissance d’un étudiant
À partir de ces informations, le programme doit être en mesure de construire
le nom d’utilisateur de l’étudiant, ce nom doit être composé des 3 premières lettre du nom de famille + la première lettre du prénom +l’année de naissance
-	Stockez ces étudiants dans un tableau statique à deux dimensions.
1.	L’option 2 : Permet d’afficher tous les étudiants de la liste, si la liste est vide afficher un message suivant : il n’y a aucun étudiant dans la liste
1.	L’option 3 permet de faire une recherche en fournissant l’identifiant de l’étudiant, grâce à cette information le programme doit afficher toutes les informations de cet étudiant.
1.-	L’option 4 : Quitter le programme avec un message de confirmation.
 	
### Consignes :
1.-	L’identifiant de l’étudiant lors de l’inscription doit être unique, sinon redemander à l’agent de saisir un identifiant valide.
1.-	Appelez une méthode qui permet de faire la validation de l’id.
1.-	Utilisez la structure switch case afin de choisir les options.
1.-	Chaque option appelle une méthode.
1.-	L’affichage de la liste des étudiants doit être sous forme de matrice
1.-	Faites les validations de type et de valeurs nécessaires.
1.-	A chaque fin de tache réaffichez le menu afin que l’utilisateur puisse choisir une autre option.
