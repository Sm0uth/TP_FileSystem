using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Arborescence
{
    public class Directory:File
    {
        //Variables
        public List<File> listeFiles;

        //Constructeur
        public Directory(string nom, Directory parent): base (nom, parent)
        {
            this.Nom = nom;
            listeFiles = new List<File>();
            permission = 4;
        }

        //Méthodes
        public bool Mkdir(string name)
        {
            listeFiles.Add(new Directory(name, this));
            if (listeFiles.Last().Nom == name)
                return true;
            else
                return false;
        }

        public List<File> Ls() 
        {
                return this.listeFiles;

        }

        public bool CreateNewFile(string name)
        {
            listeFiles.Add(new File(name, this));
            if (listeFiles.Last().Nom == name)
                return true;
            else
                return false;
        }

        public bool Delete(string name)
        {
            foreach (File file in listeFiles) 
            {
                if (file.Nom == name)
                {
                    listeFiles.Remove(file);
                    return true;
                }
                else
                    return false;
            }
            return false;
        }


        public File Cd(string name)
        {
            File courantRemplacer = null;
            foreach (File file in listeFiles)
            {
                if (file.Nom == name)
                {
                    courantRemplacer = file;
                }
            }
            return courantRemplacer;
        }

        public List<File> Search(string name)
        {
            List<File> retour = null;


            retour = new List<File>();

            foreach (File searchDir in listeFiles)
            {

                if (searchDir.Nom == name)
                {
                    retour.Add(searchDir);
                }


                List<File> retour2 = new List<File>();
                Directory searchDir2 = (Directory)searchDir;
                retour2 = searchDir2.Search(name);
                foreach (File courant in retour2)
                {
                    retour.Add(courant);
                }
            }
            return retour;
        }
    }
}
