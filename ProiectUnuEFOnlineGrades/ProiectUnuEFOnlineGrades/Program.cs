﻿using System;
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
            //-----------------------------------------------------------------------------------------------------------



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

            MLCusmuliuc.Categorie = categrepo.getCategoryById(examen.CategorieId);
            MLCusmuliuc.Curs = cursRepository.getCursById(machineLearning.CursId);
            MLCusmuliuc.Student = studrepo.getStudentById(ciprian.userId);
            MLCusmuliuc.Valoare = 2;

            MLCernescu.Curs = cursRepository.getCursById(machineLearning.CursId);
            MLCernescu.Student = studrepo.getStudentById(stefan.userId);
            MLCernescu.Valoare = 2;
            MLCernescu.Categorie = categrepo.getCategoryById(examen.CategorieId);

            MLPopovici.Curs = cursRepository.getCursById(machineLearning.CursId);
            MLPopovici.Student = studrepo.getStudentById(sebastian.userId);
            MLPopovici.Valoare = 2;
            MLPopovici.Categorie = categrepo.getCategoryById(examen.CategorieId);

            AICusmuliuc.Categorie = categrepo.getCategoryById(examen.CategorieId);
            AICusmuliuc.Curs = cursRepository.getCursById(ai.CursId);
            AICusmuliuc.Valoare = 2;
            AICusmuliuc.Student = studrepo.getStudentById(ciprian.userId);

            AICernescu.Curs = cursRepository.getCursById(ai.CursId);
            AICernescu.Student = studrepo.getStudentById(stefan.userId);
            AICernescu.Valoare = 2;
            AICernescu.Categorie = categrepo.getCategoryById(examen.CategorieId);

            AIPopovici.Curs = cursRepository.getCursById(ai.CursId);
            AIPopovici.Student = studrepo.getStudentById(sebastian.userId);
            AIPopovici.Valoare = 2;
            AIPopovici.Categorie = categrepo.getCategoryById(examen.CategorieId);

            machineLearning.Note.Add(MLCusmuliuc);
            machineLearning.Note.Add(MLCernescu);
            machineLearning.Note.Add(MLPopovici);

            ai.Note.Add(AIPopovici);
            ai.Note.Add(AICernescu);
            ai.Note.Add(AICusmuliuc);

            cursRepository.Edit(machineLearning);
            cursRepository.Save();

            cursRepository.Edit(ai);
            cursRepository.Save();

            //-----------------------------------------------------------------------
            Console.WriteLine("--------------CATEGORIE----------------");
            examen = categrepo.getCategoryById(examen.CategorieId);
            Console.WriteLine(examen.Nume);
            foreach(Nota iterator in examen.Note)
            {
                Console.WriteLine(iterator.Curs.Nume);
                Console.WriteLine(iterator.Student.Nume + " " + iterator.Student.Prenume);
                Console.WriteLine(iterator.Valoare);
            }
            Console.ReadKey();
        }
    }
}
