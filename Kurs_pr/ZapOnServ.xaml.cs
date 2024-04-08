using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для ZapOnServ.xaml
    /// </summary>
    public partial class ZapOnServ : Window
    {
        NailRaiEntities entities=new NailRaiEntities();
        public ZapOnServ()
        {
            InitializeComponent();
            foreach (var srv in entities.Service)
                cbServ.Items.Add(srv);
            foreach (var worker in entities.Worker)
                cbWork.Items.Add(worker);
        }

        private void Zap_Click(object sender, RoutedEventArgs e)
        {
            Visits vist =new Visits();
            if (tb2.Text == "" || cbServ.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Client client = entities.Client.Where(cl=>cl.id==1).FirstOrDefault();
                

                DateTime? datime = date.SelectedDate;
                string formate = null;
                if (datime.HasValue)
                {
                    formate=datime.Value.ToString("dd.MM.yyyy",System.Globalization.CultureInfo.InvariantCulture);
                }

                vist.Service1 = (cbServ.SelectedItem as Service);
                vist.client = client.id;
                vist.Worker1=cbWork.SelectedItem as Worker;
                vist.data=DateTime.Parse(formate);
                entities.Visits.Add(vist);
                entities.SaveChanges();

                MessageBox.Show("Заказ сохранен!", "Успешно", MessageBoxButton.OK);

            }
        }
        private void cbServ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Service service = cbServ.SelectedItem as Service;   
            
             if (service != null)
            {
                
                cbServ.SelectedItem = (from Service in entities.Service
                                     where Service.id ==
                                                    service.id
                                     select Service).Single<Service>();
                tb2.Text = service.price.ToString();
            }
            else
            {
                cbServ.SelectedIndex = -1;
                tb2.Text = "";
            }

        }

        private void cbWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Worker wrk = cbWork.SelectedItem as Worker;

            if (wrk != null)
            {
                
                cbWork.SelectedItem = (from Worker in entities.Worker
                                       where Worker.id ==
                                                      wrk.id
                                       select Worker).Single<Worker>();
                
            }
            else
            {
                cbServ.SelectedIndex = -1;
                
            }
        }
    }
}
