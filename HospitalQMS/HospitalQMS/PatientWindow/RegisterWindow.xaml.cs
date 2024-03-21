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
using System.Windows.Shapes;

namespace HospitalQMS.PatientWindow
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnGetTicket_Click(object sender, RoutedEventArgs e)
        {
            grFirst.Visibility = Visibility.Collapsed;
            grSecond.Visibility = Visibility.Visible;
        }

        private void btnGetBHYT_Click(object sender, RoutedEventArgs e)
        {
            grSecond.Visibility = Visibility.Collapsed;
            grFourth.Visibility = Visibility.Visible;
        }

        private void btnGetService_Click(object sender, RoutedEventArgs e)
        {
            grSecond.Visibility = Visibility.Collapsed;
            grThird.Visibility = Visibility.Visible;

            //Code of insert guest into register query can be implement here
        }

        private void btnReturnFirst_Click(object sender, RoutedEventArgs e)
        {
            grSecond.Visibility = Visibility.Collapsed;
            grFirst.Visibility = Visibility.Visible;
        }

        private void btnReturnSecond_Click(object sender, RoutedEventArgs e)
        {
            grFourth.Visibility = Visibility.Collapsed;
            grSecond.Visibility = Visibility.Visible;
        }

    }
}
