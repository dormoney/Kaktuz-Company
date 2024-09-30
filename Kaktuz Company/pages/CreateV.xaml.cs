using Kaktuz_Company.bd;
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

namespace Kaktuz_Company.pages
{
    /// <summary>
    /// Логика взаимодействия для CreateV.xaml
    /// </summary>
    public partial class CreateV : Page
    {
        public CreateV(Vistovka vistovka)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DateTime? ExDate = exhibition_date.SelectedDate;
            string Location = location.Text;
            string Award = award.Text;
            string Comment = comment.Text;
            var VistTemp = new Exhibition { exhibition_date = ExDate, location = Location, award = Award, comment = Comment};
            Connect.db.Exhibition.Add(VistTemp);
            Connect.db.SaveChanges();
            location.Clear();
            award.Clear();
            comment.Clear();
        }
    }
}
