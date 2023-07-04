using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int taille = 10;
            string[,] etudiants = new string[taille, 5];
            string reponse = "oui";
            bool loginSuccess = false;
            string username = "mary", password = "1234";
            int maxAttempts = 3;
            int attempts = 0;
            string inputId = "";

            while (!loginSuccess && attempts < maxAttempts)
            {
                Console.Write("Entrez votre username: ");
                username = Console.ReadLine();

                Console.Write("Entrez votre password: ");
                password = Console.ReadLine();

                Console.Clear();
                loginSuccess = Login(username, password);

                if (!loginSuccess)
                {
                    Console.Clear();
                    Console.WriteLine("Username ou password est invalide!");
                    attempts++;
                }
                else { break; }
            }

            if (!loginSuccess)
            {
                Console.WriteLine("Nombre maximum de tentatives de connexion atteint. Sortie...\"");
                Console.ReadKey();
                Environment.Exit(0);
            }
            do
            {
            start:
                try
                {
                    Console.WriteLine("\n\n********Gestion des etudiants**********");
                    Console.WriteLine("1. Ajouter Etudiants");
                    Console.WriteLine("2. Lister tous les etudiants");
                    Console.WriteLine("3. Rechercher un etudiant");
                    Console.WriteLine("4. Quitter");
                    Console.WriteLine("Entrez votre choix: ");
                    int choix = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    switch (choix)
                    {
                        case 1:
                            etudiants = Ajouter(etudiants);
                            break;
                        case 2:
                            bool isNull = IsEmpty(etudiants);
                            if (isNull)
                                Console.WriteLine("Aucun etudiant dans la liste");
                            else
                                Lister(etudiants);
                            break;
                        case 3:
                            Console.WriteLine("Entrez ID: ");
                            inputId = Console.ReadLine();                                                       
                            Rechercher(etudiants, inputId);                                                                  
                            break;
                        case 4:
                            Console.WriteLine("Merci, Au revoir!");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Entree invalide. \nChoississez entre 1,2,3, 4");
                            break;
                    }
                    Console.WriteLine("\nVoulez-vous faire un autre tache?: ");
                    reponse = Console.ReadLine().ToLower();
                    Console.Clear();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entree invalide!");
                }
                goto start;
            } while (reponse == "oui" || reponse == "o");
            //Console.ReadKey();
        }

        public static bool Login(string username, string password)
        {
            if (username == "mary" && password == "1234")
            {
                Console.WriteLine("Login Success!");
                return true;
            }
            return false;
        }
        public static string[,] Ajouter(string[,] etudiants)
        {
            string code;
            bool isValidSize = false;
            int taille; 
            do
            {
                Console.WriteLine("Combine d'etudiant voulez-vous entrer: ");
                if (int.TryParse(Console.ReadLine(), out taille) && taille > 0)
                {
                    isValidSize = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Taille invalide. Veuillez entrer un nombre entier positif.");
                }
            } while (!isValidSize);
                   
            etudiants = new string[taille, 5];
            for (int i = 0; i < taille; i++)
            {
                int idEntree = GetValidId(etudiants, i);
                etudiants[i, 0] = idEntree.ToString();

                Console.Write("Prenom: ");
                etudiants[i, 1] = GetValidStringInput("Prenom:");

                Console.Write("Nom: ");
                etudiants[i, 2] = GetValidStringInput("Nom: ");

                Console.Write("Annee de Naissance: ");
                etudiants[i, 3] = Console.ReadLine();

                string yearOfBirth = etudiants[i, 3];
                code = etudiants[i, 2].Substring(0, 3) + etudiants[i, 1].Substring(0, 1) + yearOfBirth;
                etudiants[i, 4] = code;

                Console.Write("Code: " + etudiants[i, 4]);
                Console.ReadLine();
            }
            Console.WriteLine("\nEtudiants ont été ajoutés avec succès!");
            Console.WriteLine();
            return etudiants;
        }
        public static int GetValidId(string[,] etudiants, int index)
        {
            int idEntree;
            bool idExists;
            do
            {
                Console.Write("ID: ");
                idEntree = int.Parse(Console.ReadLine());
                idExists = false;
                for (int j = 0; j < index; j++)
                {
                    if (etudiants[j, 0] == idEntree.ToString())
                    {
                        idExists = true;
                        Console.WriteLine("Etudiant avec cet Id deja exists!");
                        break;
                    }
                }
            } while (idExists);
            return idEntree;
        }
        public static void Lister(string[,] etudiants)
        {
            Console.WriteLine("{0,-5} {1, -15} {2, -15} {3, -20} {4,-10}",
                "ID", "PRENOM", "NOM", "DATE NAISSANCE", "CODE");
            Console.WriteLine("{0,-5} {1, -15} {2, -15} {3, -20} {4,-10}",
                 "--", "-----", "----", "-------------", "----");
            for (int i = 0; i < etudiants.GetLength(0); i++)
            {
                Console.WriteLine($"{etudiants[i, 0],-5} {etudiants[i, 1],-15} {etudiants[i, 2],-15} {etudiants[i, 3],-20} {etudiants[i, 4],-10}");
            }
        }
        public static bool IsEmpty(string[,] etudiants)
        {
            int rowCount = etudiants.GetLength(0);
            int colCount = etudiants.GetLength(1);
            bool isEmpty = true;

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (etudiants[i, j] != null)
                    {
                        isEmpty = false;
                        break;
                    }
                }
                if (!isEmpty)
                    break;
            }
            return isEmpty;
        }

        public static void Rechercher(string[,] etudiants, string id)
        {
            bool found = false;
            Console.WriteLine("{0,-5} {1, -15} {2, -15} {3, -20} {4,-10}",
              "ID", "PRENOM", "NOM", "DATE NAISSANCE", "CODE");
            Console.WriteLine("{0,-5} {1, -15} {2, -15} {3, -20} {4,-10}",
                 "--", "-----", "----", "-------------", "----");

            for (int i = 0;i <etudiants.GetLength(0) ;i++)
            {
                if (etudiants[i,0] == id)
                {
                    found = true;
                    Console.WriteLine($"{etudiants[i, 0],-5} {etudiants[i, 1],-15} {etudiants[i, 2],-15} {etudiants[i, 3],-20} {etudiants[i, 4],-10}");
                    //Console.WriteLine("Informationds de l'etudiant:");
                    //Console.WriteLine($"Identifiant: {etudiants[i,0]}");
                    //Console.WriteLine($"Nom: {etudiants[i,1]}");
                    //Console.WriteLine($"Age: {etudiants[i,2]}");
                    //Console.WriteLine($"Annee de Naissance: {etudiants[i, 3]}");
                    //Console.WriteLine($"Code: {etudiants[i,4]}");
                    Console.WriteLine();
                }
            }
            if (!found)
            {
                Console.WriteLine("Etudiant introuvable.");
            }
        }
        public static string GetValidStringInput(string nomChamp)
        {
            string input;
            bool isValidInput =false;
            do
            {
                //Console.WriteLine("Annee de Naissance: ");
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input) && !input.Any(char.IsDigit))
                {
                    isValidInput = true;
                }
                else
                {
                   // Console.Clear();
                    Console.WriteLine($"Entree invalide pour {nomChamp}. Veuillez entree un chaine de caractere.");
                    Console.Write($"{nomChamp} ");
                }
            }while(!isValidInput);
            return input;
        }
        /*
        public static string GetValidAnneNaissance()
        {
            string input;
            bool isValidInput = false;
            do
            {
                Console.Write("Annee de Naissance: ");
                input = Console.ReadLine();
                if (input.Length == 4 && (int.TryParse(input, out _) || input.All(char.IsLetter)))
                {
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Entree invalide pour Annee de Naissance. Veuillez entrer une chaine de 4 caracteres (chiffres ou lettres).");
                }
            } while (!isValidInput);

            return input;
        }
        */
    }


}

