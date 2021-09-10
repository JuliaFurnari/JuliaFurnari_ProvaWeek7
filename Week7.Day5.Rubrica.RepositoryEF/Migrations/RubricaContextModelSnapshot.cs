﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Week7.Day5.Rubrica.RepositoryEF;

namespace Week7.Day5.Rubrica.RepositoryEF.Migrations
{
    [DbContext(typeof(RubricaContext))]
    partial class RubricaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Week7.Day5.Rubrica.Core.Entities.Contatto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Contatto");
                });

            modelBuilder.Entity("Week7.Day5.Rubrica.Core.Entities.Indirizzo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cap")
                        .HasColumnType("int");

                    b.Property<string>("Città")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContattoId")
                        .HasColumnType("int");

                    b.Property<string>("Nazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Via")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ContattoId");

                    b.ToTable("Indirizzo");
                });

            modelBuilder.Entity("Week7.Day5.Rubrica.Core.Entities.Indirizzo", b =>
                {
                    b.HasOne("Week7.Day5.Rubrica.Core.Entities.Contatto", "Contatto")
                        .WithMany("Indirizzi")
                        .HasForeignKey("ContattoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contatto");
                });

            modelBuilder.Entity("Week7.Day5.Rubrica.Core.Entities.Contatto", b =>
                {
                    b.Navigation("Indirizzi");
                });
#pragma warning restore 612, 618
        }
    }
}
