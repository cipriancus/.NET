using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onlineGrades.Infrastructure.Repository;
using onlineGrades.Core.Repository_Interfaces;
using onlineGrades.Core.Entity;
using onlineGrades.Infrastructure.Business;
using onlineGrades.Infrastructure.Business.impl;

namespace ProiectUnuEFOnlineGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository studrepo = new StudentRepository();
            IProfesorRepository profrepo = new ProfesorRepository();
            CategorieRepository categrepo = new CategorieRepository();

            IRegisterBusiness register = new RegisterBusiness(studrepo, profrepo);
            ILoginBusiness loginbusiness = new LoginBusiness(studrepo,profrepo);

            ICursRepository cursRepository = new CursRepository();

            Student ciprian = new Student();
            ciprian.Nume = "Cusmuliuc";
            ciprian.Prenume = "Ciprian-Gabriel";
            ciprian.InitialaTata = "C.C.";
            ciprian.Email = "ciprian.cusmuliuc@info.uaic.ro";
            ciprian.DataNasterii = DateTime.Now;
            ciprian.Mama = "Gabriela";
            ciprian.Tata = "Constantin";
            ciprian.Nationalitate = "Romana";
            ciprian.Cetatenie = "Roman";
            ciprian.AnUniversitar = 3;
            ciprian.Username = "cipriancus";
            ciprian.Password = "ana";
            ciprian.isActive = true;

            Student stefan = new Student();
            stefan.Nume = "Cernescu";
            stefan.Prenume = "Stefan";
            stefan.InitialaTata = "C.C.";
            stefan.Email = "stefan.cernescu@info.uaic.ro";
            stefan.DataNasterii = DateTime.Now;
            stefan.Mama = "Maria";
            stefan.Tata = "Ion";
            stefan.Nationalitate = "Romana";
            stefan.Cetatenie = "Roman";
            stefan.AnUniversitar = 3;
            stefan.Username = "stefan.cernescu";
            stefan.Password = "ana";
            stefan.isActive = true;

            Student sebastian = new Student();
            sebastian.Nume = "Popovici";
            sebastian.Prenume = "Cosmin Sebastian";
            sebastian.InitialaTata = "C.C.";
            sebastian.Email = "cosmin.popovici@info.uaic.ro";
            sebastian.DataNasterii = DateTime.Now;
            sebastian.Mama = "Maria";
            sebastian.Tata = "Ion";
            sebastian.Nationalitate = "Romana";
            sebastian.Cetatenie = "Roman";
            sebastian.AnUniversitar = 3;
            sebastian.Username = "cosmin.popovici";
            sebastian.Password = "ana";
            sebastian.isActive = true;

            register.registerStudent(sebastian);
            register.registerStudent(stefan);
            register.registerStudent(ciprian);

            ciprian = null;
            sebastian = null;
            stefan = null;

            Console.WriteLine("---------------REGISTER STUDENTI----------------");
            ciprian = (Student)loginbusiness.verifyLogin("cipriancus", "ana");
            Console.WriteLine("Login Ciprian Cusmuliuc ");Console.WriteLine(ciprian.Username+" "+ciprian.Password);

            stefan = (Student)loginbusiness.verifyLogin("stefan.cernescu", "ana");
            Console.WriteLine("Login Stefan Cernescu "); Console.WriteLine(stefan.Username + " " + stefan.Password);


            sebastian = (Student)loginbusiness.verifyLogin("cosmin.popovici", "ana");
            Console.WriteLine("Login Cosmin Popovici "); Console.WriteLine(sebastian.Username + " " + sebastian.Password);


            Profesor ciortuz = new Profesor();
            ciortuz.Nume = "Ciortuz";
            ciortuz.Prenume = "Liviu";
            ciortuz.InitialaTata = "C.L";
            ciortuz.Email = "ciortuz@info.uaic.ro";
            ciortuz.DataNasterii = DateTime.Now;
            ciortuz.Mama = "Maria";
            ciortuz.Tata = "Ion";
            ciortuz.Nationalitate = "Romana";
            ciortuz.Cetatenie = "Roman";
            ciortuz.Username = "ciortuz.liviu";
            ciortuz.Password = "ana";
            ciortuz.isActive = true;

            register.registerProfesor(ciortuz);
            ciortuz = null;

            Console.WriteLine("---------------REGISTER PROFESORI----------------");
            ciortuz = (Profesor)loginbusiness.verifyLogin("ciortuz.liviu", "ana");
            Console.WriteLine("Login Liviu Ciortuz "); Console.WriteLine(ciortuz.Username + " " + ciortuz.Password);

            //-----------------------------------------CREARE CURS ---------------------------------------------------
            Curs machineLearning = new Curs();
            machineLearning.Nume = "Machine Learning";
            machineLearning.Credite = 5;

            cursRepository.Add(machineLearning);
            cursRepository.Save();

            machineLearning.Student.Add(ciprian);
            machineLearning.Student.Add(stefan);
            machineLearning.Student.Add(sebastian);
            machineLearning.Profesor.Add(ciortuz);
            cursRepository.Edit(machineLearning);
            cursRepository.Save();

            Curs ai = new Curs();
            ai.Nume = "Inteligent artificiala";
            ai.Credite = 5;

            cursRepository.Add(ai);
            cursRepository.Save();

            ai.Student.Add(ciprian);
            ai.Student.Add(stefan);
            ai.Student.Add(sebastian);
            ai.Profesor.Add(ciortuz);
            cursRepository.Edit(ai);
            cursRepository.Save();
            //--------------------------------------------------------------------------------------------------------



            //-------------------------------CREARE CATEGORIE-------------------------------------------------------------

            Categorie examen = new Categorie();
            examen.Nume = "Examen";
            categrepo.Add(examen);
            categrepo.Save();

            //---------------------------------------------------------------------------------------------------------


            //-------------------------------CREARE NOTE-------------------------------------------------------------
            Nota MLPopovici = new Nota();
            Nota MLCusmuliuc = new Nota();
            Nota MLCernescu = new Nota();


            Nota AIPopovici = new Nota();
            Nota AICusmuliuc = new Nota();
            Nota AICernescu = new Nota();

            MLCusmuliuc.Categorie = examen;
            MLCusmuliuc.Curs = machineLearning;
            MLCusmuliuc.Student = ciprian;

            MLCernescu.Curs = machineLearning;
            MLCernescu.Student = stefan;
            MLCernescu.Valoare = 2;
            MLCernescu.Categorie = examen;

            MLPopovici.Curs = machineLearning;
            MLPopovici.Student = sebastian;
            MLPopovici.Valoare = 2;
            MLPopovici.Categorie = examen;

            AICusmuliuc.Categorie = examen;
            AICusmuliuc.Curs = machineLearning;
            AICusmuliuc.Student = ciprian;

            AICernescu.Curs = machineLearning;
            AICernescu.Student = stefan;
            AICernescu.Valoare = 2;
            AICernescu.Categorie = examen;

            AIPopovici.Curs = machineLearning;
            AIPopovici.Student = sebastian;
            AIPopovici.Valoare = 2;
            AIPopovici.Categorie = examen;

            examen.Note.Add(MLCusmuliuc);
            examen.Note.Add(MLCernescu);
            examen.Note.Add(MLPopovici);

            examen.Note.Add(AIPopovici);
            examen.Note.Add(AICernescu);
            examen.Note.Add(AICusmuliuc);
            categrepo.Edit(examen);
            categrepo.Save();

            Console.ReadKey();
        }
    }
}
