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
    /// Interaction logic for autentificare.xaml
    /// </summary>
    public partial class autentificare : Page
    {
        public autentificare()
        {
            InitializeComponent();
        }

        private void autentificare_click(object sender, RoutedEventArgs e)
        {

        }

        private void reset_click(object sender, RoutedEventArgs e)
        {
            resetare res = new resetare();
            this.NavigationService.Navigate(res);
        }

        private void register_click(object sender, RoutedEventArgs e)
        {
            inregistrare reg = new inregistrare();
            this.NavigationService.Navigate(reg);
        }

        private void login_click(object sender, RoutedEventArgs e)
        {
            ILoginBusiness LoginBusiness = new LoginBusiness(new StudentRepository(), new ProfesorRepository());

            string email = email_field.Text;
            string password = password_field.Password.ToString();

            object user = LoginBusiness.verifyLogin(email, password);

            if (user != null)
            {
                if (user is Student)
                {
                    login_message.Content = "Login successful for Student";
                }
                else if (user is Profesor)
                {
                    login_message.Content = "Login successful for Profesor";
                }
            }
            else
            {
                login_message.Content = "Login error";
            }
        }
    }
}
