using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Arborescence
{
    public class File
    {
        //Variables
        public string Nom { get; set; }
        public Directory Parent { get; set; }
        public int permission;

        //Constructeur
        public File(string nom, Directory parent)
        {
            this.Nom = nom;
            this.Parent = parent;
            permission = 4;
        }

        //Methodes
        public bool CanWrite()
        {
            return (permission & 2) > 0;
        }
        public bool CanExecute()
        {
            return (permission & 1) > 0;
        }
        public bool CanRead()
        {
            return (permission & 4) > 0;
        }
        public string GetPermission()
        {
            string permission = "";
            if (this.CanExecute())
            {
                permission = permission + "x";
            }
            else if (this.CanRead())
            {
                permission = permission + "r";
            }
            else if (this.CanWrite())
            {
                permission = permission + "w";
            }
            else
            {
                permission = permission + "-";
            }
            return permission;
        }

        public string GetPath()
        {
            File courant = this;
            string path = "";
            while (courant.Nom!="/")
            {
                path = courant.Nom + "/" + path;
                courant = courant.Parent;
            }
            return path;

        }

        public File GetRoot()
        {
            File courant = this;
            while (this.Parent.Nom !="/" )
            {
                courant = this.Parent;
                return courant;
            }
            return courant;
        }

        public bool RenameTo(string newName) 
        {
            this.Nom = newName;
            if (Nom == newName)
                return true;
            else
                return false;
        }

        public File GetParent()
        {
            File parentRetour = null;
            if (this.Parent != null)
            {
                parentRetour = this.Parent;
                return parentRetour;
            }
            else
            {
                Console.WriteLine("C'est déjà l'origine du monde");
                return this.Parent;
            }
        }

        public bool IsDirectory()
        {
            if (this.GetType() == typeof(Directory))
                return true;
            else
                return false;
        }


        public bool IsFile() 
        {
            if (this.GetType() == typeof(File))
                return true;
            else
                return false;
        }

        public string GetName() 
        {
            string nomFile = this.Nom;
            return nomFile;            
        }

        public void Chmod(int permission)
        {
            this.permission = permission;
        }


    }
}
