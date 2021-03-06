using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week7.Day5.Rubrica.Core.Entities
{
    public class Contatto
    {
        
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }

        public List<Indirizzo> Indirizzi { get; set; } = new List<Indirizzo>();

        public override string ToString()
        {
            return $"Id: {ID} \t Nome: {Nome}\t Cognome: {Cognome} ";

        }

    }
}
