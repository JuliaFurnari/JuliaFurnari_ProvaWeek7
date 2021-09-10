using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Day5.Rubrica.Core.Entities;
using Week7.Day5.Rubrica.Core.InterfaceRepositories;

namespace Week7.Day5.Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer:IBusinessLayer
    {
        //Dichiaro quali sono i repository che ho a disposizione.
        private readonly IRepositoryContatto contattoRepo;
        private readonly IRepositoryIndirizzo indirizzoRepo;
   

        public MainBusinessLayer(IRepositoryContatto contatti, IRepositoryIndirizzo indirizzi)
        {
            contattoRepo = contatti;
            indirizzoRepo = indirizzi;
        }

        public string EliminaContatto(int sceltaId)
        {
            Contatto contattoEsistente = contattoRepo.GetAll().FirstOrDefault(c => c.ID==sceltaId);
            
                if (contattoEsistente.Indirizzi.ToList().Count == 0)
                {
                    contattoRepo.Delete(contattoEsistente);
                    return "Contatto eliminato correttamente";
                }
                return "Errore. Non è possibile cancellare un contatto a cui è associato un'indirizzo.";
            

        }

        public List<Contatto> GetAllContatti()
        {
             return contattoRepo.GetAll();
        }

        public string InserisciNuovoContatto(Contatto nuovoContatto)
        {
           
                contattoRepo.Add(nuovoContatto);
                return "Nuovo contatto inserito correttamente";
            
        }

        public object InserisciNuovoIndirizzo(Indirizzo nuovoIndirizzo)
        {
         
                indirizzoRepo.Add(nuovoIndirizzo);
                return "Indirizzo inserito correttament";
            
        }
    }
}
