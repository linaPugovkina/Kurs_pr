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
    /// Логика взаимодействия для Rigistracia.xaml
    /// </summary>
    public partial class Rigistracia : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        public Rigistracia()
        {
            InitializeComponent();
            foreach (var role in entities.Role)
                cbrole.Items.Add(role);
        }

        private void backinput_Click(object sender, RoutedEventArgs e)
        {
            MainWindow Registr = new MainWindow();
            Registr.Show();
            this.Close();
        }

        private void zareg_Click(object sender, RoutedEventArgs e)
        {
            if (cbrole.SelectedIndex == -1 || tblogin.Text == "" || passbox.Password == "")
            {
                MessageBox.Show("Все поля должны быть заполнены! Попробуйте снова!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            users users = new users();

            users.Role1 = cbrole.SelectedItem as Role;
            users.login = tblogin.Text;
            users.password = passbox.Password;

            entities.users.Add(users);
            entities.SaveChanges();
            MessageBox.Show("Пользователь успешно зарегистрирован!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

            cbrole.SelectedIndex = -1;
            tblogin.Text = "";
            passbox.Password = "";
        }
    }
}
