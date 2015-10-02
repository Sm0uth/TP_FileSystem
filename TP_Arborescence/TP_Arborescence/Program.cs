using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Arborescence
{
    class Program
    {
        static void Main(string[] args)
        {
            File courant = new Directory("/", null);
            Directory courantDir=null;
            string saisieUser = "";
            string utilisateur = "Benjamin_T";
            Console.WriteLine("Bienvenue dans ce splendide simulateur UNIX");
            Console.WriteLine("Veuillez saisir les commandes souhaitées.");
            Console.WriteLine("Pour quitter le simulateur, veuillez saisir exit.\n");

            while (saisieUser != "exit") 
            {
                Console.Write("["+utilisateur+"] $ " + courant.Nom + "/  ");
                saisieUser = Console.ReadLine();
                string[] saisieSplit = saisieUser.Split(' ');

                  if (courant.IsDirectory() == true){
                      courantDir = (Directory)courant;
                  }

                switch (saisieSplit[0])
 
                {
                    case "cd":
                        File fileCD = courantDir.Cd(saisieSplit[1]);
                        if (saisieSplit.Length == 1)
                        {
                            Console.WriteLine("Veuillez spécifier un dossier ou un fichier.");
                        }                        
                        else if (fileCD != null)
                        {
                            courant = fileCD;
                        }
                        else
                            Console.WriteLine("Le déplacement n'est pas possible (Fichier inexistant)");
                        break;


                    case "ls":
                         if (courantDir.CanRead())
                            {
                                List<File> liste = courantDir.Ls();
                                if (courant.IsDirectory() == true)
                                {
                                    foreach (File file in liste)
                                    {
                                        Console.WriteLine(file.GetPermission()+ " " + file.Nom);
                                    }
                                }
                                else if (courant.IsFile() == true)
                                {
                                    Console.WriteLine("Vous êtes dans un file");
                                }
                            }
                            else {
                                Console.WriteLine("Vous n'avez pas la permission");
                            }
                        break;


                    case "mkdir":
                        if (saisieSplit.Length >= 2) 
                        {
                            if (courantDir.Mkdir(saisieSplit[1]))
                            {
                                Console.WriteLine("Le dossier " + saisieSplit[1] + " est bien créé.");
                            }
                            else
                            {
                                Console.WriteLine("Echec de la création du dossier.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "path":
                        string path = courant.GetPath();
                        Console.WriteLine(path);
                        break;


                    case "root":
                        courant = courant.GetRoot();
                        break;


                    case "rename":
                        if (saisieSplit.Length>=3)
                        {
                            if(courant.RenameTo(saisieSplit[2]))
                            {
                                Console.WriteLine("Le fichier ou dossier précisé a bien été renommé");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "create":
                        if (saisieSplit.Length >= 2)
                        {
                            if (courantDir.CreateNewFile(saisieSplit[1]))
                            {
                                Console.WriteLine("Fichier bien créé.");
                            }
                            else
                            {
                                Console.WriteLine("Echec de la création.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "parent":
                        courant = courant.GetParent();                        
                        break;

                    case "search":
                        if (saisieSplit.Length >= 2)
                        {
                            List<File> resultat = courantDir.Search(saisieSplit[1]);
                            if (resultat != null)
                            {
                                foreach (File file in resultat)
                                    Console.WriteLine(file.GetPath());
                            }
                            else
                            {
                                Console.WriteLine("La recherche n'a pas abouti");
                            }
                        }
                        else 
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }
                        break;


                    case "file":
                        if (courant.IsFile())
                        {
                            Console.WriteLine("Ceci est une file");
                        }
                        else
                        {
                            Console.WriteLine("Ceci n'est pas une file.");
                        }
                        break;


                    case "directory":
                        if (courant.IsDirectory())
                        {
                            Console.WriteLine("Ceci est un directory");
                        }
                        else
                        {
                            Console.WriteLine("Ceci n'est pas un directory");
                        }
                        break;


                    case "name":
                        Console.WriteLine("Le nom du fichier est " + courant.GetName());
                        break;


                    case "delete":
                        if (saisieSplit.Length >= 2)
                        {
                            if (courantDir.Delete(saisieSplit[1]))
                            {
                                Console.WriteLine("Fichier bien supprimé.");
                            }
                            else
                            {
                                Console.WriteLine("Echec de la supression.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Veuillez saisir la commande complète svp.");
                        }

                        break;


                    case "chmod":
                        if (saisieSplit.Length >= 2)
                        {
                            courant.Chmod(int.Parse(saisieSplit[1]));
                            Console.WriteLine("Modification de permission effectuée avec succès.");
                        }
                        else
                            Console.WriteLine("Veuillez saisir le degré de permission.");
                        break;

                    default:
                        Console.WriteLine("Commande erronée ou inconnue. Veuillez recommencer.");
                        break;
                }

            }

        }
    }
}