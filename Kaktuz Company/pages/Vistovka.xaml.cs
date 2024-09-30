using Kaktuz_Company.bd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Vistovka.xaml
    /// </summary>
    public partial class Vistovka : Page
    {
        public Vistovka(MainPage mainPage)
        {
            InitializeComponent();
            ListEx.ItemsSource = Connect.db.Exhibition.ToList();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateV(this));
        }

        private void ListEx_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListEx.SelectedItem != null)
            {
                Exhibition selectedEx = ListEx.SelectedItem as Exhibition;
                var isValiable = Connect.db.Exhibition.FirstOrDefault(idex => idex.id_exhibition == selectedEx.id_exhibition);
                if (isValiable != null)
                {
                    MessageBox.Show("Виставка используется в таблице участников");
                }
                else
                {
                    Connect.db.Exhibition.Remove(selectedEx);
                    Connect.db.SaveChanges();
                    ListEx.ItemsSource = Connect.db.Exhibition.ToList();
                }
                return;
            }
            else
            {
                MessageBox.Show("Выбери виставка пж!");
            }
        }
    }
}
