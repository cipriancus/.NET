using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using onlineGrades.Infrastructure.Business.impl;
using onlineGrades.Infrastructure.Business;
using onlineGrades.Infrastructure.Repository;
using onlineGrades.Core.Entity;

namespace onlineGrades.WPF
{
    /// <summary>
    /// Interaction logic for inregistrare.xaml
    /// </summary>
    public partial class inregistrare : Page
    {
        public inregistrare()
        {
            InitializeComponent();
        }


        private void autentificare_click(object sender, RoutedEventArgs e)
        {
            autentificare auth = new WPF.autentificare();
            this.NavigationService.Navigate(auth);
        }

        private void register_send(object sender, RoutedEventArgs e)
        {
            IRegisterBusiness RegisterBusiness = new RegisterBusiness(new StudentRepository(), new ProfesorRepository());
            User user = new User();
            user.Nume = nume.Text;
            user.Prenume = prenume.Text;
            user.Email = email.Text;
            user.Username = username.Text;
            user.Password = Cryptography.Sha256Password(password_field.Password.ToString());
            user.RegisterUUID = Guid.NewGuid();

            Student student = new Student(user);
            student.AnUniversitar = 0;
            RegisterBusiness.registerStudent(student);
            
        }

        private void register_click(object sender, RoutedEventArgs e)
        {
            inregistrare reg = new inregistrare();
            this.NavigationService.Navigate(reg);
        }
    }
}
