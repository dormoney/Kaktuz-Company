using Kaktuz_Company.bd;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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

namespace Kaktuz_Company.pages
{
    /// <summary>
    /// Логика взаимодействия для Kaktuz.xaml
    /// </summary>
    public partial class Kaktuz : Page
    {
        public Kaktuz(MainPage mainPage)
        {
            InitializeComponent();
            ListUsers.ItemsSource = Connect.db.Cactus.ToList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

  

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Create(this));
        }
        private void ListUsers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListUsers.SelectedItem != null)
            {
                Cactus selectedCactus = ListUsers.SelectedItem as Cactus;
                var isValiable = Connect.db.participant.FirstOrDefault(idex => idex.id_cactus == selectedCactus.id_cactus);
                if (isValiable != null)
                {
                    MessageBox.Show("Кактус является участником");
                }
                else
                {
                    Connect.db.Cactus.Remove(selectedCactus);
                    Connect.db.SaveChanges();
                    ListUsers.ItemsSource = Connect.db.Cactus.ToList();
                }
                return;
            }
            else
            {
                MessageBox.Show("Выбери кактус пж!");
            }

 
        }
    }
}
