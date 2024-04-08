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

namespace Kurs_pr
{
    /// <summary>
    /// Логика взаимодействия для userWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void input_Click(object sender, RoutedEventArgs e)
        {
            string login = tblog.Text.Trim();
            string password = passb.Password.Trim();

            users users = new users();

            users = entities.users.Where(user => user.login == login && user.password == password).FirstOrDefault();

            if (users != null)
            {
                MessageBox.Show("Вы вошли в систему", "Успех!");
                switch (users.Role1.Id)
                {
                    case 1:
                        ForAdmin adm = new ForAdmin(users.Id);
                        adm.Show();
                        this.Close();
                        break;
                    case 2:
                        ForWorker wrk = new ForWorker(users.Id);
                        wrk.Show();
                        this.Close();
                        break;
                    case 3:
                        ForClient cln = new ForClient(users.Id);
                        cln.Show();
                        this.Close();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Введенной пары логин:пароль не найдено! Попробуйте снова!", "Ошибка!",
                    MessageBoxButton.OK, MessageBoxImage.Error);

                passb.Clear();
                tblog.Focus();
            }
        }

        private void regisr_Click(object sender, RoutedEventArgs e)
        {
            Rigistracia MainWindow = new Rigistracia();
            MainWindow.Show();
            this.Close();
        }
    }
}
