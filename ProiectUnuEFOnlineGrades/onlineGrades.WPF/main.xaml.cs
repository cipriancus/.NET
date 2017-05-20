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

namespace onlineGrades.WPF
{
    /// <summary>
    /// Interaction logic for main.xaml
    /// </summary>
    public partial class main : Page
    {
        public main()
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

        }

    }
}
