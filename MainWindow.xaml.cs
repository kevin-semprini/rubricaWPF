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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Kevin.Semprini._4i.Rubrica
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            int idx = 0;
            try
            {

                const int MAX = 100;
                Contatto[] Contatti = new Contatto[MAX];
                StreamReader fin = new StreamReader("Dati.csv"); //legge i dati dal file "Dati.csv"
                idx = 0;
                while (!fin.EndOfStream)
                {
                    if (idx < MAX)
                    {
                        string riga = fin.ReadLine();
                        Contatto c = new Contatto(riga);
                        Contatti[idx++] = c;
                    }
                    else
                        break;


                    // l'indice "idx++" serve per far scrivere dentro il valore di idx per poi incrementarlo senza scrivere nel secondo valore
                    //si chiama "post-incremento"

                }
                for (; idx < MAX; idx++)
                {
                    Contatto c = new Contatto();
                    c.Numero = idx;
                    Contatti[idx] = c;

                }
                dgDati.ItemsSource = Contatti;

            }
            catch (Exception err)
            {
                MessageBox.Show($" NUH UH\n + {err.Message} \n  alla riga {idx}");
            }



        }
        private void DgDati_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Contatto c = e.Row.Item as Contatto;
            if (c != null)
            {
                if (c.Numero == 0)
                {
                    e.Row.Foreground = Brushes.White;
                    e.Row.Background = Brushes.Red;
                }
            }
        }
    }
}
