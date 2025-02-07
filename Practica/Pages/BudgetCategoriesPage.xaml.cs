using Practica.Appdata;
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

namespace Practica.Pages
{
    /// <summary>
    /// Логика взаимодействия для BudgetCategoriesPage.xaml
    /// </summary>
    public partial class BudgetCategoriesPage : Page
    {
        public BudgetCategoriesPage()
        {
            InitializeComponent();
            BudgetCategoriesLV.ItemsSource = Connect.Contex.BudgetCategories.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
           Nav.frame.Navigate(new AddPages.AddBudgetCategoriesPage(null));
        }

      

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            BudgetCategoriesLV.ItemsSource = Connect.Contex.BudgetCategories.ToList();
        }

       

        private void delBtn_Click(object sender, RoutedEventArgs e)
        {
            var delresult = BudgetCategoriesLV.SelectedItems.Cast<BudgetCategories>().ToList();

            if (MessageBox.Show($"Вы точно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                Connect.Contex.BudgetCategories.RemoveRange(delresult);
            try
            {
                Connect.Contex.SaveChanges();
                BudgetCategoriesLV.ItemsSource = Connect.Contex.BudgetCategories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
           
            Nav.frame.Navigate(new AddPages.AddBudgetCategoriesPage((sender as Button).DataContext as BudgetCategories));
        }
    }
}
