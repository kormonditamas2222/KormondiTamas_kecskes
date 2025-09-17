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

namespace kecske
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> balLista = ["kecske", "káposzta", "gazda", "farkas"];
        List<string> jobbLista = [];
        public MainWindow()
        {
            InitializeComponent();
            lb_bal.ItemsSource = balLista;
            lb_jobb.ItemsSource = jobbLista;
            Gombok();
        }

        private void btn_jobbra_Click(object sender, RoutedEventArgs e)
        {
            var kijelolt = lb_bal.SelectedItem.ToString();
            if (kijelolt != "gazda")
            {
                balLista.Remove(kijelolt);
                balLista.Remove("gazda");
                jobbLista.Add(kijelolt);
                jobbLista.Add("gazda");
            }
            else
            {
                balLista.Remove(kijelolt);
                jobbLista.Add(kijelolt);
            }
            lb_bal.Items.Refresh();
            lb_jobb.Items.Refresh();
            Gombok();
        }

        private void btn_balra_Click(object sender, RoutedEventArgs e)
        {
            Gombok();
        }
        private void Gombok()
        {
            btn_balra.IsEnabled = lb_jobb.Items.Contains("gazda");
            btn_jobbra.IsEnabled = lb_bal.Items.Contains("gazda");
        }
    }
}