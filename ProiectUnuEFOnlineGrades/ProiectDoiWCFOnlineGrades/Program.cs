using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using onlineGrades.Infrastructure.WCF;
using onlineGrades.Infrastructure.WCF.impl;
using System.ServiceModel;
using System.ServiceModel.Description;
using onlineGrades.Core.Entity;

namespace ProiectDoiWCFOnlineGrades
{
    class Program
    {
        private static ServiceHost host;

        static void Main(string[] args)
        {   
            onlineGrades.Infrastructure.WCF.IOnlineGradesWCF ogWCF = new OnlineGradesWCF();
            host = new ServiceHost(ogWCF, new Uri("http://localhost:8733/onlineGrades/Interface"));

            try
            {
                host.Open();
                OnlineGradesWCF svp = (OnlineGradesWCF)host.SingletonInstance;
                System.Console.WriteLine("Server lansat in executie cu succes!Asteptare cereri de la clienti...");

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
                ciprian.isActive = false;

                registerStudent(ciprian);

                ActivateAccount(ciprian);

                LoginAUser(ciprian.Username, "ana");

                ciprian.Nume = "gabriel";
                editStudent(ciprian);

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

                registerProfesor(ciortuz);
                ActivateAccount(ciortuz);

                LoginAUser(ciortuz.Username, "ana");

                ciortuz.Nume = "andrei";
                editProfesor(ciortuz);

                Console.Read();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Serverul nu poate fi lansat in executie!");
            }
        }

        private static User LoginAUser(string username, string password)
        {

            OnlineGradesWCFClient client = new OnlineGradesWCFClient();

            User user = client.LoginUser(username, password);
            if (user == null)
            {
                System.Console.WriteLine("username and password invalid");
                return null;
            }
            else
            {
                System.Console.WriteLine(user.Nume + " " + user.Prenume + " authentificated");
                return user;
            }
        }

        private static bool ActivateAccount(User user)
        {

            OnlineGradesWCFClient client = new OnlineGradesWCFClient();
            return client.confirmUser(user.userId);
        }

        private static bool editProfesor(Profesor profesor)
        {
            OnlineGradesWCFClient client = new OnlineGradesWCFClient();

            return client.editProfesor(profesor);
        }
        private static bool editStudent(Student student)
        {
            OnlineGradesWCFClient client = new OnlineGradesWCFClient();

            return client.editStudent(student);
        }

        private static bool registerProfesor(Profesor profesor)
        {
            OnlineGradesWCFClient client = new OnlineGradesWCFClient();
            return client.registerProfesor(profesor);
        }

        private static bool registerStudent(Student student)
        {
            OnlineGradesWCFClient client = new OnlineGradesWCFClient();

            return client.registerStudent(student);
        }
    }
}
