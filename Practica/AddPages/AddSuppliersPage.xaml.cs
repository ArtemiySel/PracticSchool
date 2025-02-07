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
using Practica.Appdata;

namespace Practica.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddSuppliersPage.xaml
    /// </summary>
    public partial class AddSuppliersPage : Page
    {
        Suppliers sup;
        bool CheckNew;
        public AddSuppliersPage( Suppliers s)
        {
            InitializeComponent();
            if (s == null)
            {
                s = new Suppliers();
                CheckNew = true;
            }
            else CheckNew = false;
            DataContext = sup = s;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                Connect.Contex.Suppliers.Add(sup);
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
