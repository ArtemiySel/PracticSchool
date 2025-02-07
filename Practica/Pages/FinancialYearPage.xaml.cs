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
    /// Логика взаимодействия для FinancialYearPage.xaml
    /// </summary>
    public partial class FinancialYearPage : Page
    {
        public FinancialYearPage()
        {
            InitializeComponent();
            FinancialYearLV.ItemsSource = Connect.Contex.FinancialYears.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddFinancialYearPage(null));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            FinancialYearLV.ItemsSource = Connect.Contex.FinancialYears.ToList();
        }

    

       

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delresult = FinancialYearLV.SelectedItems.Cast<FinancialYears>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.Contex.FinancialYears.RemoveRange(delresult);
            try
            {
                Connect.Contex.SaveChanges();
                FinancialYearLV.ItemsSource = Connect.Contex.FinancialYears.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

       

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.frame.Navigate(new AddPages.AddFinancialYearPage((sender as Button).DataContext as FinancialYears));
        }
    }
}
