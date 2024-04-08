using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Kurs_pr
{
    /// <summary>
    /// Логика взаимодействия для ForWorker.xaml
    /// </summary>
    public partial class ForWorker : Window
    {
        NailRaiEntities entities = new NailRaiEntities();
        List<ClientVisits> itemsInList = new List<ClientVisits>();
        public ForWorker(int users_id)
        {
            InitializeComponent();
            var combinate = from vist in entities.Visits
                            join client in entities.Client on vist.client equals client.id
                            join service in entities.Service on vist.service equals service.id
                            select new
                            {
                                VisClient = client.FCs,
                                VisServ = service.name,
                                date = vist.data
                            };
           

            foreach(var entity in combinate)
            {
                LbVisits.Items.Add(new ClientVisits(entity.VisClient, entity.VisServ, entity.date));
                itemsInList.Add(new ClientVisits(entity.VisClient, entity.VisServ, entity.date));
            }

            count.Content = itemsInList.Count;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ForWorker = new MainWindow();
            ForWorker.Show();
            this.Close();
        }

       
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchWord = search.Text;
            if (!string.IsNullOrEmpty(searchWord) || searchWord.Length > 0)
            {
                LbVisits.Items.Clear();

                var foundDet = itemsInList.Where(item => item.VisServ.Contains(searchWord));

                foreach (var det in foundDet)
                {
                    LbVisits.Items.Add(det);
                }

            }
            else
            {
                LbVisits.Items.Clear();
                foreach (var det in itemsInList)
                {
                    LbVisits.Items.Add(det);
                }
            }
        }

        private void cbWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void LbVisits_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ClientVisits selectedVst = LbVisits.SelectedItem as ClientVisits;
     
            if (selectedVst != null)
            {
                tbServ.Text = selectedVst.VisServ;
                date.Text = selectedVst.VisDate.ToShortDateString();
            }
            else
            {
                tbServ.Text = " ";
                date.Text = " ";
            }

            LbVisits.Items.Refresh();

        }
    }
}
