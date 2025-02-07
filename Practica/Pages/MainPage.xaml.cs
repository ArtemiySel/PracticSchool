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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practica.Appdata;

namespace Practica.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
     
       

        public MainPage()
        {
            
            InitializeComponent();
            Nav.frame = frame; 
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new EmployersPage());
        }
    

        private void but_Click_1(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new SalariessPage());
            
        }

        private void but2_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new FinancialYearPage());

        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new SuppliersPage());
        }

        private void but4_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new BudgetCategoriesPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0)
 ;       }
    }
}
