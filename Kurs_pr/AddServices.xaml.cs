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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Kurs_pr
{
    /// <summary>
    /// Логика взаимодействия для AddServices.xaml
    /// </summary>
    public partial class AddServices : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        public AddServices()
        {
            InitializeComponent();
            foreach (var serv in entities.Service)
                LbServ.Items.Add(serv);
            foreach(var grServ in entities.GroupServices)
                cbGrServ.Items.Add(grServ);
        }

        private void butDelete_Click(object sender, RoutedEventArgs e)
        {
            
            var rez = MessageBox.Show("Вы действительно хотите удалить услугу?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rez == MessageBoxResult.No)
                return;
            var delete_serv = LbServ.SelectedItem as Service;

            bool isEmpty = false;
            try
            {
                var provserv = (from Service in entities.Service
                               where delete_serv.id == Service.id
                               select Service).First();
            }
            catch (Exception)
            {
                isEmpty = true;
            }
            if (!isEmpty)
            {
                MessageBox.Show("На удаляемую услугу записан клиент. Удаление невозможно!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (delete_serv != null)
                {
                    entities.Service.Remove(delete_serv);

                    entities.SaveChanges();
                    tbName.Clear();

                    LbServ.Items.Remove(delete_serv);

                }
                else
                {
                    MessageBox.Show("Нет удаляемых объектов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                MessageBox.Show("Запись удалена", "Успешно", MessageBoxButton.OK);
                LbServ.Items.Refresh();
            }
        }

        private void butSave_Click(object sender, RoutedEventArgs e)
        {
            var srv = LbServ.SelectedItem as Service;

            bool isOk = true;
            int costPrice = 0;
            int price = 0;

            if (!int.TryParse(tbCostPrice.Text, out costPrice) || !int.TryParse(tbPrice.Text, out price))
            {
                isOk = false;
                MessageBox.Show("Цена должна быть числом", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!isOk)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(tbName.Text) || string.IsNullOrWhiteSpace(tbCostPrice.Text) || string.IsNullOrWhiteSpace(tbPrice.Text) || cbGrServ.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (srv == null)
                {
                    srv = new Service();
                    entities.Service.Add(srv);
                    LbServ.Items.Add(srv);
                }

                srv.name = tbName.Text;
                srv.price = price;
                srv.costPrice = costPrice;

                entities.SaveChanges();

                MessageBox.Show("Услуга сохранена", "Успешно", MessageBoxButton.OK);
                LbServ.Items.Refresh();
            }
        }

        private void butClear_Click(object sender, RoutedEventArgs e)
        {
            tbName.Text = "";
            tbCostPrice.Text = "";
            tbPrice.Text = "";
            tbDescr.Text = "";
            cbGrServ.SelectedIndex = -1;
            LbServ.SelectedIndex = -1;
            tbName.Focus();
        }

        private void LbServ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        
        {
            Service selectedServ = LbServ.SelectedItem as Service;

            if (selectedServ != null)
            {
                tbName.Text = selectedServ.name;
                tbCostPrice.Text= selectedServ.costPrice.ToString();
                tbPrice.Text = selectedServ.price.ToString();
                cbGrServ.SelectedItem = (from GroupServices in entities.GroupServices
                                        where GroupServices.id ==
                                                       selectedServ.groupp
                                        select GroupServices).Single<GroupServices>();
                tbDescr.Text = selectedServ.description.ToString();
            }
            else
            {
                tbName.Text = " ";
                tbCostPrice.Text = " ";
                tbPrice.Text = " ";
                cbGrServ.SelectedIndex = -1;
                tbDescr.Text = " ";
            }

            LbServ.Items.Refresh();

        }

        private void cbServ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
