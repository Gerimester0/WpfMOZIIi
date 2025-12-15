using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMOZIIi
{
    public class Mozi 
    {
        public string cím { get; set; }

        public DateTime időpont { get; set; }

        public string Terem { get; set; }

        public int Szabadhelyek { get; set; }
        public bool _3D { get; set; }

        public Mozi(string cím, DateTime időpont, string terem, int szabadhelyek, bool _3D)
        {
            this.cím = cím;
            this.időpont = időpont;
            Terem = terem;
            Szabadhelyek = szabadhelyek;
            this._3D = _3D;
        }
    }

    public partial class MainWindow : Window
    {
        public List<Mozi> mozifilmek = new List<Mozi>();
        public MainWindow()
        {
            InitializeComponent();
            mozifilmek.Add(new Mozi("Gyűrűk ura", new DateTime(2025, 12, 15, 19 , 30 ,0), "1-es terem",12,true));

            mozifilmek.Add(new Mozi("Venom", new DateTime(2025, 12, 10,20,25,0), "2-es terem", 30, false));

            mozifilmek.Add(new Mozi("Up", new DateTime(2025, 12, 15,14,0,0), "4-es terem", 10, true));

            mozifilmek.Add(new Mozi("Step Up", new DateTime(2025, 12, 15,19,50,0), "3-as terem", 0, false));

            mozifilmek.Add(new Mozi("FNAF 2", new DateTime(2025, 12, 15, 23, 0 , 0), "1-es terem", 2, true));

            mozifilmek.Add(new Mozi("IT", new DateTime(2025, 12, 15,23 ,0,0), "2-es terem", 2, false));

            
        }

        private void adatokbetoltese(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = mozifilmek;
        }
        private void foglalas(object sender, RoutedEventArgs e)
        {
            if(dataGrid.SelectedItem is Mozi) {
            
            ((Mozi)dataGrid.SelectedItem).Szabadhelyek = ((Mozi)dataGrid.SelectedItem).Szabadhelyek - 1;
                dataGrid.Items.Refresh();
            }

        }

        private void vanhely(object sender, RoutedEventArgs e) 
        {
            List<Mozi> csakaholvanhely = new List<Mozi>();
            foreach (var mozi in mozifilmek)
            {
                if(mozi.Szabadhelyek>0)csakaholvanhely.Add(mozi);
            }
            dataGrid.ItemsSource = csakaholvanhely;
            dataGrid.Items.Refresh();

            
        }
        private void legnepszerubb(object sender, RoutedEventArgs e)
        {
            var legnepszerubb = mozifilmek.OrderByDescending(m => m.Szabadhelyek).FirstOrDefault();
            if (legnepszerubb != null)
            {
                dataGrid.ItemsSource = new List<Mozi> { legnepszerubb };
            }
        }
        private void atlagosszabad(object sender, RoutedEventArgs e)
        {
            double atlag = mozifilmek.Average(m => m.Szabadhelyek);
            MessageBox.Show($"Átlagos szabad helyek száma: {atlag:F1}");
        }

    }
}