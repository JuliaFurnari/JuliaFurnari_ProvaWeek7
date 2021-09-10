using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week7.Day5.Rubrica.Core.Entities;

namespace Week7.Day5.Rubrica.RepositoryEF
{
    internal class IndirizzoConfiguration : IEntityTypeConfiguration<Indirizzo>
    {
        public void Configure(EntityTypeBuilder<Indirizzo> modelBuilder)
        {
            modelBuilder.ToTable("Indirizzo");//Specifico il nome della tabella
            modelBuilder.HasKey(i => i.ID); //specifico la PK
            modelBuilder.Property(i => i.Tipologia).IsRequired();//not null
            modelBuilder.Property(i => i.Via).IsRequired();//not null
            modelBuilder.Property(i => i.Città).IsRequired();//not null
            modelBuilder.Property(i => i.Cap).IsRequired();//not null
            modelBuilder.Property(i => i.Provincia).IsRequired();//not null
            modelBuilder.Property(i => i.Nazione).IsRequired();//not null

            //Relazione Corso 1 -> Studenti n (uno a molti)
            modelBuilder.HasOne(i => i.Contatto).WithMany(c => c.Indirizzi).HasForeignKey(i => i.ContattoId);
        }
    }
}