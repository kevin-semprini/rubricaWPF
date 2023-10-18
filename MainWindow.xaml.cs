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
           
            
            Contatto[] Contatti = new Contatto[100];
            for (int i = 0; i < Contatti.Length; i++)
            {
                Contatti[i] = new Contatto();
            }


            try
            {
                StreamReader fin = new StreamReader("Dati.csv"); //legge i dati dal file "Dati.csv"
                string riga;
                int idx = 0;
                while (!(fin.EndOfStream))
                {
                    riga = fin.ReadLine();
                    Contatto c = new Contatto(riga);
                    // l'indice "idx++" serve per far scrivere dentro il valore di idx per poi incrementarlo senza scrivere nel secondo valore
                    //si chiama "post-incremento"
                    Contatti[idx++] = c;
                }

            } catch (Exception err) 
            {
                MessageBox.Show("NUH HUH\n" + err.Message);
            }

            dgDati.ItemsSource = Contatti;

        }
    }
}