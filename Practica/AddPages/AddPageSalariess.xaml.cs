using System;
using System.Collections.Generic;
using System.IO;
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
using Practica.Appdata;

namespace Practica.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddPageSalariess.xaml
    /// </summary>
    public partial class AddPageSalariess : Page
    {
        Salariess sol;
        bool CheckNew;
        public AddPageSalariess(Salariess s)
        {
            InitializeComponent();
            if( s == null)
            {
                s = new Salariess();
                CheckNew = true;
            }
            else
            {
                CheckNew = false;
            }
            DataContext = sol = s;
            Comb.ItemsSource = Connect.Contex.Employers.ToList();
            comb2.ItemsSource = Connect.Contex.FinancialYears.ToList();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {

                Connect.Contex.Salariess.Add(sol);
            }
            try
            {
                Connect.Contex.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();

           
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

       
    }
}
