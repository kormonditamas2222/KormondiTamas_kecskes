using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Converters;
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
            Ellenorzes();
        }

        private void btn_balra_Click(object sender, RoutedEventArgs e)
        {
            var kijelolt = lb_jobb.SelectedItem.ToString();
            if (kijelolt != "gazda")
            {
                jobbLista.Remove(kijelolt);
                jobbLista.Remove("gazda");
                balLista.Add(kijelolt);
                balLista.Add("gazda");
            }
            else
            {
                jobbLista.Remove(kijelolt);
                balLista.Add(kijelolt);
            }
            lb_bal.Items.Refresh();
            lb_jobb.Items.Refresh();
            Gombok();
            Ellenorzes();
        }
        private void Gombok()
        {
            btn_balra.IsEnabled = lb_jobb.Items.Contains("gazda");
            btn_jobbra.IsEnabled = lb_bal.Items.Contains("gazda");
        }
        private void Ellenorzes()
        {
            bool elsoAllapot = !balLista.Contains("gazda") && balLista.Contains("kecske") && balLista.Contains("káposzta");
            bool masodikAllapot = !jobbLista.Contains("gazda") && jobbLista.Contains("kecske") && jobbLista.Contains("káposzta");
            bool harmadikAllapot = !balLista.Contains("gazda") && balLista.Contains("kecske") && balLista.Contains("farkas");
            bool negyedikAllapot = !jobbLista.Contains("gazda") && jobbLista.Contains("kecske") && jobbLista.Contains("farkas");
            if (elsoAllapot || masodikAllapot)
            {
                MessageBox.Show(this, "A kecske megette a káposztát. Próbáld újra.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                btn_balra.IsEnabled = false;
                btn_jobbra.IsEnabled = false;
                return;
            }
            else if (harmadikAllapot || negyedikAllapot) 
            {
                MessageBox.Show(this, "A farkas megette a kecskét. Próbáld újra.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                btn_balra.IsEnabled = false;
                btn_jobbra.IsEnabled = false;
                return;
            }
            if (jobbLista.Count == 4)
            {
                MessageBox.Show(this, "Megoldottad a feladatot!", "Győzelem", MessageBoxButton.OK, MessageBoxImage.Information);
                btn_balra.IsEnabled = false;
                btn_jobbra.IsEnabled = false;
            }
        }
    }
}