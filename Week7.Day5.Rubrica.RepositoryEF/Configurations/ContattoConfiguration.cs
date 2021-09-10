using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Day5.Rubrica.Core.Entities;

namespace Week7.Day5.Rubrica.RepositoryEF
{
    internal class ContattoConfiguration : IEntityTypeConfiguration<Contatto>
    {
     

        public void Configure(EntityTypeBuilder<Contatto> modelBuilder)
        {
            modelBuilder.ToTable("Contatto");//Specifico il nome della tabella
            modelBuilder.HasKey(c => c.ID); //specifico la PK
            modelBuilder.Property(c => c.Nome).IsRequired();//not null
            modelBuilder.Property(c => c.Cognome).IsRequired();//not null

            //Relazione Corso 1 -> Studenti n (uno a molti)
            modelBuilder.HasMany(c => c.Indirizzi).WithOne(i => i.Contatto).HasForeignKey(i => i.ContattoId);
            
        }
    }
}