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
    /// Interaction logic for resetare.xaml
    /// </summary>
    public partial class resetare : Page
    {
        public resetare()
        {
            InitializeComponent();
        }

        private void autentificare_click(object sender, RoutedEventArgs e)
        {
            autentificare auth = new WPF.autentificare();
            this.NavigationService.Navigate(auth);
        }

        private void register_click(object sender, RoutedEventArgs e)
        {
            inregistrare auth = new WPF.inregistrare();
            this.NavigationService.Navigate(auth);
        }

        private void reset_click(object sender, RoutedEventArgs e)
        {
            string useremail = email.Text;
            IResetPassworBusiness ResetBusiness = new ResetPasswordBusiness(new StudentRepository(), new ProfesorRepository());
            User user = ResetBusiness.getUser(useremail, "student");

            Student student = (Student)user;
            student.ResetUUID = Guid.NewGuid();
            user = student;
            IRegisterBusiness regBusiness = new RegisterBusiness(new StudentRepository(), new ProfesorRepository());
            regBusiness.editStudent(student);
        }

    }
}
