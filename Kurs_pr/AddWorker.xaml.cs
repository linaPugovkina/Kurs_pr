using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Kurs_pr
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        public AddWorker()
        {
            InitializeComponent();
            foreach (var wrk in entities.Worker)
                Lbwork.Items.Add(wrk);

            foreach (var post in entities.Positions)
            {
                cbPosition.Items.Add(post);
            }
        }

        private void Lbwork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Worker selectedWrk = Lbwork.SelectedItem as Worker;

            if (selectedWrk != null)
            {
                tbSurname.Text = selectedWrk.FCs;
                cbPosition.SelectedItem = (from Positions in entities.Positions where Positions.id == selectedWrk.positions select Positions).Single<Positions>();
                tbAdress.Text = selectedWrk.adress;
                tbtelephone.Text = selectedWrk.Telephone.ToString();
            }
            else
            {
                tbSurname.Text = " ";
                cbPosition.SelectedIndex = -1;
                tbAdress.Text = " ";
                tbtelephone.Text = " ";
            }

            Lbwork.Items.Refresh();

        }

        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            var rez = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rez == MessageBoxResult.No)
                return;

            var delete_wrk = Lbwork.SelectedItem as Worker;

            bool isEmpty = false;
            try
            {
                var provserv = (from Worker in entities.Worker
                                where delete_wrk.id == Worker.id
                                select Worker).First();
            }
            catch (Exception)
            {
                isEmpty = true;
            }
            if (!isEmpty)
            {
                MessageBox.Show("У удаляемого специалиста есть запись. Удаление невозможно!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {

                if (delete_wrk != null)
                {
                    entities.Worker.Remove(delete_wrk);

                    entities.SaveChanges();
                    tbSurname.Clear();
                    tbAdress.Clear();
                    tbtelephone.Clear();

                    Lbwork.Items.Remove(delete_wrk);

                    cbPosition.SelectedIndex = -1;

                }
                else
                {
                    MessageBox.Show("Нет удаляемых объектов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                MessageBox.Show("Запись удалена", "Успешно", MessageBoxButton.OK);
                Lbwork.Items.Refresh();
            }
        }

        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            var worker = Lbwork.SelectedItem as Worker;

            bool isOk = int.TryParse(tbtelephone.Text, out int Telephone);
            if (!isOk)
            {
                MessageBox.Show("Убедитесь, что вы верно ввели номер телефона", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbSurname.Text == "" || tbAdress.Text == "" || cbPosition.SelectedIndex == -1 || tbtelephone.Text==" ")
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {

                if (worker == null)
                {
                    worker = new Worker();
                    entities.Worker.Add(worker);
                    Lbwork.Items.Add(worker);
                }
                worker.FCs = tbSurname.Text;
                worker.Telephone = tbtelephone.Text.ToString();
                worker.adress = tbAdress.Text;
                worker.positions = (int)(cbPosition.SelectedItem as Positions)?.id;
                

                entities.SaveChanges();

                MessageBox.Show("Запись сохранена", "Успешно", MessageBoxButton.OK);
                Lbwork.Items.Refresh();
            }
        }

        private void butClear_Click(object sender, RoutedEventArgs e)
        {
            tbSurname.Text = " ";
            cbPosition.SelectedIndex = -1;
            tbAdress.Text = " ";
            tbtelephone.Text = " ";
            tbSurname.Focus();
        }

        private void cbPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbtelephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                int maxLength = 10;
                if ((sender as TextBox).Text.Length > maxLength)
                {
                    (sender as TextBox).Text = (sender as TextBox).Text.Substring(0, maxLength);
                    (sender as TextBox).CaretIndex = maxLength;
                }
            
        }
    }
}
