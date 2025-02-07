﻿using System;
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
    /// Логика взаимодействия для AddPageEmployes.xaml
    /// </summary>
    public partial class AddPageEmployes : Page
    {
        Employers em;
        bool CheckNew;
        public AddPageEmployes(Employers e)
        {
            InitializeComponent();
            if (e == null) { 
                e = new Employers();
            CheckNew = true; }
            else CheckNew = false;
            DataContext = em = e;
   


        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CheckNew) 
            {
                Connect.Contex.Employers.Add(em);
            }
            try
            {
                Connect.Contex.SaveChanges();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Nav.MainFrame.GoBack();
        }

        private void BckBtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MainFrame.GoBack();
        }

    }
}
