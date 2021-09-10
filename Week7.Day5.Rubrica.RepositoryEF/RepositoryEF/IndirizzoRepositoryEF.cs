using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Day5.Rubrica.Core.Entities;
using Week7.Day5.Rubrica.Core.InterfaceRepositories;

namespace Week7.Day5.Rubrica.RepositoryEF.RepositoryEF
{
    public class IndirizzoRepositoryEF : IRepositoryIndirizzo
    {
        public Indirizzo Add(Indirizzo item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Indirizzi.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Indirizzo item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Indirizzi.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Indirizzo> GetAll()
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Indirizzi.ToList();
            }
        }

        public Indirizzo Update(Indirizzo item)
        {
            throw new NotImplementedException();
        }
    }
}
