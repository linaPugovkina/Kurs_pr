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
    /// Логика взаимодействия для ForAdmin.xaml
    /// </summary>
    public partial class ForAdmin : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        public ForAdmin(int users_id)
        {
            InitializeComponent();
        }

       

        private void butAddWork_Click(object sender, RoutedEventArgs e)
        {
            AddWorker addWorker = new AddWorker();
            addWorker.Show();
        }

        private void butAddServ_Click(object sender, RoutedEventArgs e)
        {
            AddServices addServices = new AddServices();
            addServices.Show();
        }

        private void butAddRole_Click(object sender, RoutedEventArgs e)
        {
            AddRole addRole = new AddRole();    
            addRole.Show();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ForAdmin = new MainWindow();
            ForAdmin.Show();
            this.Close();
        }
    }
}
