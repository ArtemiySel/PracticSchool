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
    /// Логика взаимодействия для SalariessPage.xaml
    /// </summary>
    public partial class SalariessPage : Page
    {
        public SalariessPage()
        {
            InitializeComponent();
            SalariessLV.ItemsSource = Connect.Contex.Salariess.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddPageSalariess(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SalariessLV.ItemsSource = Connect.Contex.Salariess.ToList();
        }

       

       

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delresult = SalariessLV.SelectedItems.Cast<Salariess>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.Contex.Salariess.RemoveRange(delresult);
            try
            {
                Connect.Contex.SaveChanges();
                SalariessLV.ItemsSource = Connect.Contex.Salariess.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddPageSalariess((sender as Button).DataContext as Salariess));
        }
    }
}
