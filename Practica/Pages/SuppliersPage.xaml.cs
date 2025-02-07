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

namespace Practica.Pages
{
    /// <summary>
    /// Логика взаимодействия для SuppliersPage.xaml
    /// </summary>
    public partial class SuppliersPage : Page
    {
        public SuppliersPage()
        {
            InitializeComponent();
            SuppliersLV.ItemsSource = Connect.Contex.Suppliers.ToList();

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddSuppliersPage(null));
        }

       

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SuppliersLV.ItemsSource = Connect.Contex.Suppliers.ToList();
        }

       

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delresult = SuppliersLV.SelectedItems.Cast<Suppliers>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            Connect.Contex.Suppliers.RemoveRange(delresult);
            try
            {
                Connect.Contex.SaveChanges();
                SuppliersLV.ItemsSource = Connect.Contex.Suppliers.ToList();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddSuppliersPage((sender as Button).DataContext as Suppliers));
        }
    }
}
