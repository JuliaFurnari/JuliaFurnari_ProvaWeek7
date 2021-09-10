using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Day5.Rubrica.Core.InterfaceRepositories;
using Week7.Day5.Rubrica.Core.Entities;

namespace Week7.Day5.Rubrica.RepositoryMock.RepositoryMock
{
    public class RepositoryContattiMock : IRepositoryContatto
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto{ID=1, Nome="Tony", Cognome="Stark"},
            new Contatto{ID=2, Nome="Pepper", Cognome="Potts"}
        };
        public Contatto Add(Contatto item)
        {
            if (Contatti.Count == 0)
            {
                item.ID = 1;
            }
            else
            {
                item.ID = Contatti.Max(d => d.ID) + 1;
            }

            Contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            Contatti.Remove(item);
            return true;
        }

        public List<Contatto> GetAll()
        {
            return Contatti;
        }

        public Contatto Update(Contatto item)
        {
            throw new NotImplementedException();
        }
    }
}

