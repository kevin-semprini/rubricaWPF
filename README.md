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

~~~
