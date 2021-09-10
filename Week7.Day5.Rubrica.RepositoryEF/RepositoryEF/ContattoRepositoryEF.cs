using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week7.Day5.Rubrica.Core.Entities;
using Week7.Day5.Rubrica.Core.InterfaceRepositories;

namespace Week7.Day5.Rubrica.RepositoryEF.RepositoryEF
{
    public class ContattoRepositoryEF : IRepositoryContatto
    {
        public Contatto Add(Contatto item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Contatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Contatto item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Contatti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Contatto> GetAll()
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Contatti.Include(c => c.Indirizzi).ToList();
            }
        }

        public Contatto Update(Contatto item)
        {
            throw new NotImplementedException();
        }
    }
}
