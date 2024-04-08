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
    /// Логика взаимодействия для AddRole.xaml
    /// </summary>
    public partial class AddRole : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        public AddRole()
        {
            InitializeComponent();
        }

        private void backinput_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void zareg_Click(object sender, RoutedEventArgs e)
        {
            if (tbrole.Text == "")
            {
                MessageBox.Show("Поле должно быть заполнено! Попробуйте снова!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Role role = new Role();

            role.name = tbrole.Text;

            entities.Role.Add(role);
            entities.SaveChanges();
            MessageBox.Show("Роль успешно добавлена!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);

            tbrole.Text = "";
        }
    }
}
