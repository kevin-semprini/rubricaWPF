# rubricaWPF
questo file permette di creare una  rubrica ordinata mettendo i dati del singolo contatto dentro un file .csv e seguendo i punti di separazione (;)
## ecco un esempio
PK;Nome;Cognome;Telefono;EMail;CAP <br>
1;Kevin;Semprini;1234567891;nome.cognome@gmail.com;47924

in questo esempio "pk" è il numero corrispondente al numero del contatto, se pk è 1 allora quello sarà il primo contatto

## Come riempo la rubrica
~~~C#
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
~~~

questo codice prende mano a mano ogni parte della stringa del file csv e ci crea un oggetto della classe Contatto con un costruttore apposisto <br>
fatto cio li mette tutti in un altro array di 100 elementi (massimo di elementi che la rubrica può contenere) e se trova un errore lo segna in rosso senza chiudere il programma <br>
l'array viene visualuzzato tramite una tabella che si genera nel file XAML, il quale permette anche la colorazione delle righe errate

### colorazione in rosso
~~~C#
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
~~~

il metodo qui sopra riportato viene chiamato nel file XAML, il suo scopo è quello di colorare di rosso tutti i contatti senza numero o con numero 0 <br>
(se non viene messo un numero nel file csv viene messo un null e poi uno zero)  

per colorare va a modificare i parametri della singola riga dell griglia nello XAML "Row.Foreground" è il colore del testo, "Row.Background" è il colore dello sfondo 

## Classe Contatto

~~~C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kevin.Semprini._4i.Rubrica
{
    internal class Contatto
    {
        private int _numero;
        private string nome;
        private string _cognome;

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    _numero = value;
                }
            }
        }

        public string Nome { get; set; }
        public string EMail { get; set; }
        public string Telefono { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }

        public string Cognome { get => _cognome; set => _cognome = value; }

        public Contatto() { }

        //COSTRUISCE IL CONTATTO PARTENDO DA UNA RIGA DEL FILE CSV
        public Contatto(string riga) 
        {
            // ".split()" crea una vettore di elemnti stringa
            string[] campi = riga.Split(';');
            if (campi.Length >= 5)
            {
                this.Nome = campi[1];
                this.Cognome = campi[2];
                this.Telefono = campi[3];
                this.EMail = campi[4];
                this.CAP = campi[5];

                int PK = 0;
                int.TryParse(campi[0], out PK);
                this.Numero = PK;
                this.Numero = 0;



                //tryParse serve a convertire il valore dato come primo paramentro in un valore di tipo "int"
                //in questoc caso, e metterlo nella variabile PK che è di tipo int, è sempre stringa > var
                //in pratica lui controlla la stringa e prende  il valore richiesto dalla variabile messa

            }
        }
    }
}
~~~

qui la proprety numero ha subito delle modifiche interne ai metodi get e set per assicurarsi che il valore massimo accettabile fosse <br>
minore o uguale a 100 (massimo di contatti per la rubrica)

il costruttore personalizzato serve appunto al main per poter creare oggetti di tipo contatto già con i valore presi dal file csv <br> 
senza dover fare poi un assegnazione nel main  

