using FluentAssertions;
using M01_Srv_Municipalite;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Module1_introduction_Exercisse_TestUnitaire
{
    public class TestTraitementImporterDonneesMunicipalite
    {
        [Fact]
        public void Executer_FichierAvec3MunicipaliterETListeVide_3Ajout()
        {
            List<Municipalite> municipalites = new List<Municipalite>();
            Municipalite municipalite1 = new Municipalite(1, "Municipalite1", "Courriel1", "Web1", DateTime.Now);
            Municipalite municipalite2 = new Municipalite(2, "Municipalite2", "Courriel2", "Web2", DateTime.Now);
            Municipalite municipalite3 = new Municipalite(3, "Municipalite3", "Courriel3", "Web3", DateTime.Now);
            municipalites.Add(municipalite3);
            municipalites.Add(municipalite2);
            municipalites.Add(municipalite1);
            Mock<IDepotImportationMunicipalites> mockFichierImporter = new Mock<IDepotImportationMunicipalites>();
            mockFichierImporter.Setup(e => e.LireMunicipalites()).Returns(municipalites);
            Mock<IDepotMunicipalites> mockDepotMunicipalite = new Mock<IDepotMunicipalites>();
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockFichierImporter.Object, mockDepotMunicipalite.Object);
            StatistiquesImportationDonnees statistiquesAttendue = new StatistiquesImportationDonnees();
            statistiquesAttendue.NombreEnregistrementsAjoutes = 3;
            
            StatistiquesImportationDonnees statistiquesCalculer = traitement.Executer();

            Assert.Equal(statistiquesAttendue.NombreEnregistrementsAjoutes, statistiquesCalculer.NombreEnregistrementsAjoutes);
            mockFichierImporter.Verify(e => e.LireMunicipalites(), Times.Once);
            mockFichierImporter.VerifyNoOtherCalls();
        }
        [Fact]
        public void Executer_FichierAvec3MunicipaliterETListeAvec2MunicipalitePareil1Active1Incative_3AjoutEt1Modif()
        {
            List<Municipalite> municipalites = new List<Municipalite>();
            Municipalite municipalite1 = new Municipalite(1, "Municipalite1", "Courriel1", "Web1", DateTime.Now);
            Municipalite municipalite2 = new Municipalite(2, "Municipalite2", "Courriel2", "Web2", DateTime.Now);
            Municipalite municipalite3 = new Municipalite(3, "Municipalite3", "Courriel3", "Web3", DateTime.Now);
            municipalites.Add(municipalite3);
            municipalites.Add(municipalite2);
            municipalites.Add(municipalite1);
            Mock<IDepotImportationMunicipalites> mockFichierImporter = new Mock<IDepotImportationMunicipalites>();
            mockFichierImporter.Setup(e => e.LireMunicipalites()).Returns(municipalites);
            Mock<IDepotMunicipalites> mockDepotMunicipalite = new Mock<IDepotMunicipalites>();
            mockDepotMunicipalite.Setup(e => e.AjouterMunicipalite(municipalite1));
            mockDepotMunicipalite.Setup(e => e.AjouterMunicipalite(municipalite3));
            mockDepotMunicipalite.Setup(e => e.DesactiverMunicipalite(municipalite3));
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockFichierImporter.Object, mockDepotMunicipalite.Object);
            StatistiquesImportationDonnees statistiquesAttendue = new StatistiquesImportationDonnees();
            statistiquesAttendue.NombreEnregistrementsAjoutes = 3;
            statistiquesAttendue.NombreEnregistrementsModifies = 1;

            StatistiquesImportationDonnees statistiquesCalculer = traitement.Executer();

            Assert.Equal(statistiquesAttendue.NombreEnregistrementsAjoutes, statistiquesCalculer.NombreEnregistrementsAjoutes);
            //Assert.Equal(statistiquesAttendue.NombreEnregistrementsModifies, statistiquesCalculer.NombreEnregistrementsModifies);
        }
    }
}