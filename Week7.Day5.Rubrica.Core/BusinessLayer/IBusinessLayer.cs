using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Day5.Rubrica.Core.Entities;

namespace Week7.Day5.Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        List<Contatto> GetAllContatti();
        string InserisciNuovoContatto(Contatto nuovoContatto);
        object InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo);
        string EliminaContatto(int sceltaId);
    }
}
