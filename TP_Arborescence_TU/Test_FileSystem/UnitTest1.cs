using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_Arborescence;

namespace Test_FileSystem
{
    [TestClass]
    public class UnitTest1
    {
        //J'initialise mes variables
        int newPermission;
        Directory courant = new Directory("/", null);
        Directory courantReplace;
        Directory testDirectory;
        Directory test;
        Directory test1;
        Directory test2;
        File testDirectory1;
        File fileTest;
        File testFile;

        [TestMethod]
        public void TestCreate()
        {
            Assert.IsTrue(courant.CreateNewFile("Test"));
            Assert.AreEqual("/", courant.Nom);
            Assert.IsTrue(courant.listeFiles.Count == 1);
        }
        [TestMethod]
        public void TestNotCreate()
        {   //Normal que le test plante, car le premier bool est a true, car la création a réussi.
            Assert.IsFalse(courant.CreateNewFile("Test"));
            Assert.IsTrue(courant.listeFiles.Count == 0);
        }
        [TestMethod]
        public void TestMkdir()
        {
            Assert.IsTrue(courant.Mkdir("Test"));
            Assert.IsTrue(courant.listeFiles.Count == 1);
        }
        [TestMethod]
        public void TestNotMkdir()
        {   //Normal que le test plante, car le premier bool est a true, car la création a réussi.
            Assert.IsFalse(courant.Mkdir("Test"));
            Assert.IsTrue(courant.listeFiles.Count == 00);
        }
        [TestMethod]
        public void TestRename()
        {
            Assert.IsTrue(courant.RenameTo("Test"));
        }
        [TestMethod]
        public void TestNotRename()
        {
            //Normal que le teste plante, il a réussi à rename.
            Assert.IsFalse(courant.RenameTo("Test"));
        }
        [TestMethod]
        public void TestChmod1()
        {
            newPermission = 1;
            courant.Chmod(newPermission);
            Assert.AreEqual(1, courant.permission);
        }
        [TestMethod]
        public void TestChmod2()
        {
            newPermission = 2;
            courant.Chmod(newPermission);
            Assert.AreEqual(2, courant.permission);
        }
        [TestMethod]
        public void TestChmod3()
        {
            newPermission = 3;
            courant.Chmod(newPermission);
            Assert.AreEqual(3, courant.permission);
        }
        [TestMethod]
        public void TestChmod4()
        {
            newPermission = 4;
            courant.Chmod(newPermission);
            Assert.AreEqual(4, courant.permission);
        }
        [TestMethod]
        public void TestChmod5()
        {
            newPermission = 5;
            courant.Chmod(newPermission);
            Assert.AreEqual(5, courant.permission);
        }
        [TestMethod]
        public void TestChmod6()
        {
            newPermission = 6;
            courant.Chmod(newPermission);
            Assert.AreEqual(6, courant.permission);
        }
        [TestMethod]
        public void TestChmod7()
        {
            newPermission = 7;
            courant.Chmod(newPermission);
            Assert.AreEqual(7, courant.permission);
        }
        [TestMethod]
        public void IsFile()
        {
            testFile = new File("testFile", courant);
            Assert.IsTrue(testFile.IsFile());
        }
        [TestMethod]
        public void IsNotFile()
        {
            testFile = new Directory("testFile", courant);
            Assert.IsFalse(testFile.IsFile());
        }
        [TestMethod]
        public void IsDirectory()
        {
            testDirectory = new Directory("testDirectory", courant);
            Assert.IsTrue(testDirectory.IsDirectory());
        }
        [TestMethod]
        public void IsNotDirectory()
        {
            testDirectory1 = new File("testDirectory", courant);
            Assert.IsFalse(testDirectory1.IsDirectory());
        }
        [TestMethod]
        public void TestLs()
        {
            courant.Mkdir("Test");
            courant.Mkdir("Test1");
            courant.Mkdir("Test2");
            Assert.IsTrue(courant.Ls().Count == 3);
        }
        [TestMethod]
        public void TestGetPath()
        {
            test = new Directory ("Test", courant);
            test1 = new Directory ("Test1", test);
            Assert.AreEqual(test.Nom + "/" + test1.Nom+"/", test1.GetPath());

        }
        [TestMethod]
        public void TestGetParent()
        {
            test = new Directory("Test", courant);
            Assert.AreEqual(test.Parent, test.GetParent());
        }
        [TestMethod]
        public void TestGetRoot()
        {
            test = new Directory("Test", courant);
            test1 = new Directory("Test1", test);
            test2 = new Directory("Test2", test1);
            Assert.AreEqual(test1, test2.GetRoot());
        }
        [TestMethod]
        public void TestDelete()
        {
            test = new Directory("Test", courant);
            fileTest = new File("FileTest", test);
            test.listeFiles.Add(fileTest);
            Assert.IsTrue(test.listeFiles.Count == 1);
            Assert.IsTrue(test.Delete("FileTest"));
            Assert.IsTrue(test.listeFiles.Count == 0);
        }
        [TestMethod]
        public void TestNotDelete()
        {
            //On teste de supprimer un fichier inexistant
            test = new Directory("Test", courant);
            fileTest = new File("FileTest", test);
            test.listeFiles.Add(fileTest);
            Assert.IsTrue(test.listeFiles.Count == 1);
            Assert.IsFalse(test.Delete("FileTest2"));
            Assert.IsTrue(test.listeFiles.Count == 1);
        }
        [TestMethod]
        public void TestGetName()
        {
            test = new Directory("Test", courant);
            fileTest = new File("FileTest", test);
            Assert.AreEqual("FileTest", fileTest.GetName());
        }
        [TestMethod]
        public void TestSearch()
        {
            courant.Mkdir("Test1");
            courant.Mkdir("Test2");
            courant.Mkdir("Test3");
            courant.Mkdir("Test3");
            Assert.AreEqual(2,courant.Search("Test3").Count);
        }
        [TestMethod]
        public void TestCanRead()
        {
            Assert.IsTrue(courant.permission == 4);
        }
        [TestMethod]
        public void TestCanExecute()
        {
            courant.Chmod(1); //car permission par défaut à 4
            Assert.IsTrue(courant.permission == 1);
        }
        [TestMethod]
        public void TestCanWrite()
        {
            courant.Chmod(2); //car permission par défaut à 4
            Assert.IsTrue(courant.permission == 2);
        }
        [TestMethod]
        public void TestCd()
        {
            courantReplace = new Directory("New", courant);
            courant.listeFiles.Add(courantReplace);
            Assert.AreEqual(courantReplace, courant.Cd(courantReplace.Nom));
        }
    }
}
