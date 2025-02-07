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
    /// Логика взаимодействия для AddBudgetCategoriesPage.xaml
    /// </summary>
    public partial class AddBudgetCategoriesPage : Page
    {
        BudgetCategories bc;
        bool CheckNew;
        public AddBudgetCategoriesPage(BudgetCategories b)
        {
            InitializeComponent();
            if (b == null)
            {
                b = new BudgetCategories();
                CheckNew = true;
            }
            else CheckNew = false;
            DataContext = bc = b;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew)
            {
                Connect.Contex.BudgetCategories.Add(bc);
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
    }
}
