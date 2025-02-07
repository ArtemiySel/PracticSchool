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
    /// Логика взаимодействия для EmployersPage.xaml
    /// </summary>
    public partial class EmployersPage : Page
    {
        public EmployersPage()
        {
            InitializeComponent();
            EmployersLV.ItemsSource = Connect.Contex.Employers.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddPageEmployes(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            EmployersLV.ItemsSource = Connect.Contex.Employers.ToList();

        }
      

       

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delresult = EmployersLV.SelectedItems.Cast<Employers>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.Contex.Employers.RemoveRange(delresult);
            try
            {
                Connect.Contex.SaveChanges();
                EmployersLV.ItemsSource = Connect.Contex.Employers.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddPageEmployes((sender as Button).DataContext as Employers));
        }
    }
}
