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
    /// Логика взаимодействия для Create.xaml
    /// </summary>
    public partial class Create : Page
    {
        public Create(Kaktuz kaktuz)
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string Vid = vid.Text;
            string Origin = origin.Text;
            int Age = int.Parse(age.Text);
            int Value = int.Parse(value.Text);
            string CareInstuctions = care_instuctions.Text;
            var CactuzTemp = new Cactus { vid = Vid, origin = Origin, age = Age, value = Value, care_instuctions = CareInstuctions };
            Connect.db.Cactus.Add(CactuzTemp);
            Connect.db.SaveChanges();
            vid.Clear();
            origin.Clear();
            age.Clear();
            value.Clear();
            care_instuctions.Clear();
        }
    }
}
