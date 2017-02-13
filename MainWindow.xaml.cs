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
using AdvWorksObjects;

namespace ListenMitDerEITEinstieg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            #region Produkte
            {

            }
            #endregion

        }

        private void listBoxResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void buttonProdukte_Click(object sender, RoutedEventArgs e)
        {
            int i = 0;
            while (i < AdvWorks.Products.Count)
            {
                Product p = AdvWorks.Products[i];
                listBoxResults.Items.Add(p.Name + "\t" + p.ListPrice);
                i++;
            }
        }

        private void buttonAnzahlTeureProdukte_Click(object sender, RoutedEventArgs e)
        {
            int value = 180;
            listBoxResults.Items.Clear();
            for(int i = 0; i < AdvWorks.Products.Count; i++)
            {
                if(AdvWorks.Products[i].ListPrice > value)
                    listBoxResults.Items.Add(AdvWorks.Products[i]);
            }
        }

        private void buttonMaximalerPreis_Click(object sender, RoutedEventArgs e)
        {
            List<Product> max = new List<Product>();
            double maxValue = 0;


            listBoxResults.Items.Clear();

            for (int i = 0; i < AdvWorks.Products.Count; i++)
            {
                if (AdvWorks.Products[i].ListPrice > maxValue)
                {
                    maxValue = AdvWorks.Products[i].ListPrice;
                }
            }
            for (int i = 0; i < AdvWorks.Products.Count; i++)
            {
                if (AdvWorks.Products[i].ListPrice == maxValue)
                {
                    max.Add(AdvWorks.Products[i]);
                    listBoxResults.Items.Add(AdvWorks.Products[i]);

                }
            }
        }

        private void buttonAboveAverage_Click(object sender, RoutedEventArgs e)
        {
            /**

            foreach (Product product in AdvWorks.Products)
            {
                if (product.ListPrice > avg)
                    listBoxResults.Items.Add(product);
            }

            */


            double sum = 0;
            double avg = 0;
            int count = 0;

            listBoxResults.Items.Clear();
            foreach (Product product in AdvWorks.Products)
            {
                sum += product.ListPrice;
                count++;
            }

            avg = sum / count;

            // linq
            var queryProducts = from prod in AdvWorks.Products
                                where prod.ListPrice > avg
                                select prod.Name;

            foreach (var prod in queryProducts)
            {
                listBoxResults.Items.Add(prod);
            }
        }
    }
}
