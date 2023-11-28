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

