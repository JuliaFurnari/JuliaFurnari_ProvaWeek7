using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using Week7.Day5.Rubrica.Core.BusinessLayer;
using Week7.Day5.Rubrica.Core.Entities;
using Week7.Day5.Rubrica.Core.InterfaceRepositories;
using Week7.Day5.Rubrica.RepositoryEF.RepositoryEF;
using Week7.Day5.Rubrica.RepositoryMock.RepositoryMock;
using Xunit;

namespace Week7.Day5.Rubrica.Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestAggiungiContatto()
        {
            // Arrange            
            MainBusinessLayer mb = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
         // MainBusinessLayer mb = new MainBusinessLayer(new ContattoRepositoryEF(), new IndirizzoRepositoryEF());
            //Inserimento di un nome non presente nel db
            Contatto contattoProva = new Contatto { Nome = "Clint", Cognome = "Barton" };

            // Act
            string esito = mb.InserisciNuovoContatto(contattoProva);

            // Assert           
            Assert.Equal("Nuovo contatto inserito correttamente", esito);
           
        }

    }
}
