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
using System.IO;

namespace GestioneMagazzino
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string file = "Magazzino.txt";

        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter w= new StreamWriter(file, true))
                {
                    string testo;
                    string prodotto = txtNomeProdotto.Text;
                    double prezzo = double.Parse(txtPrezzoProdotto.Text);
                    testo = $"{prodotto}: {prezzo} €";
                    w.WriteLine(testo);
                    w.Flush();
                }
                txtNomeProdotto.Clear();
                txtPrezzoProdotto.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtNomeProdotto.Clear();
                txtPrezzoProdotto.Clear();
            }
        }
        private void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(file))
                try
                {
                    txtCercato.Clear();
                    string nome = txtCerca.Text;
                    using (StreamReader r= new StreamReader(file))
                    {
                        string line;
                        while ((line = r.ReadLine()) != null)
                        {
                            if (line.Contains(nome))
                                txtCercato.Text += $"{line}\n";
                        }
                    }
                }
                catch { }

        }
    }
}

        
    


