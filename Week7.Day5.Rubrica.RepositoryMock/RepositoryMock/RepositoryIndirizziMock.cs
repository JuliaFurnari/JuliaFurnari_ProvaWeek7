using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Day5.Rubrica.Core.Entities;
using Week7.Day5.Rubrica.Core.InterfaceRepositories;

namespace Week7.Day5.Rubrica.RepositoryMock.RepositoryMock
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzo
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>();
        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = Indirizzi.Max(s => s.ID) + 1;
            }
            var contatto = RepositoryContattiMock.Contatti.FirstOrDefault(c => c.ID == item.ContattoId);
            item.Contatto = contatto;
            contatto.Indirizzi.Add(item);

            Indirizzi.Add(item);
            return item;
        }

        public bool Delete(Indirizzo item)
        {
            throw new NotImplementedException();
        }

        public List<Indirizzo> GetAll()
        {
            throw new NotImplementedException();
        }

        public Indirizzo Update(Indirizzo item)
        {
            throw new NotImplementedException();
        }
    }
}
