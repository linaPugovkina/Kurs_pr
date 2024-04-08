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
using System.Windows.Shapes;

namespace Kurs_pr
{
    /// <summary>
    /// Логика взаимодействия для ForClient.xaml
    /// </summary>
    public partial class ForClient : Window
    {
        NailRaiEntities entities=new NailRaiEntities();
        public ForClient(int users_id)
        {
            InitializeComponent(); List<Service> selectedServices = entities.Service.ToList();
            dGridService.ItemsSource = selectedServices;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ForClient = new MainWindow();
            ForClient.Show();
            this.Close();
        }

        private void BtnZapisOnServ_Click(object sender, RoutedEventArgs e)
        {
            ZapOnServ windowZap = new ZapOnServ();
            windowZap.Show();
            
        }
    }
}
