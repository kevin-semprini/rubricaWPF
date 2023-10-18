using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kevin.Semprini._4i.Rubrica
{
    internal class Contatto
    {
        private int _numero = 0;
        private string _cognome = "";

        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException();

                _numero = value;
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
                this.Nome = campi[0];
                this.Cognome = campi[1];
                this.Telefono = campi[2];
                this.EMail = campi[3];
                this.CAP = campi[4];
            }

             
            

            if (this.Telefono == " ")
            {
                throw new ArgumentException();
            }



        }
        public Contatto(int numero, string nome, string cognome)
        {
            Numero = numero;
            Nome = nome;
            Cognome = cognome;
        }
    }
}

