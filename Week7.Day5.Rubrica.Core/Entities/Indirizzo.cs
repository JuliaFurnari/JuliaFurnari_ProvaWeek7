using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Day5.Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int ID { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Città { get; set; }
        public int Cap { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        //FK
        public int ContattoId { get; set; }
        public Contatto Contatto { get; set; }

        public override string ToString()
        {
            return $"Tipologia:{Tipologia} \tIndirizzo: {Via}, {Città}, {Cap}, {Provincia}, {Nazione} ";
        }
    }
}
