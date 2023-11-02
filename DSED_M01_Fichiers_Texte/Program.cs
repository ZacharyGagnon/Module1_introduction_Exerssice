using M01_DAL_Import_Munic_CSV;
using M01_DAL_Municipalite_SQLServer;
using M01_Srv_Municipalite;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace DSED_M01_Fichiers_Texte
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDepotImportationMunicipalites depotImportation = new DepotImportationMunicipaliteCSV();
            MunicipaliteContexteSQLServer contexteSQLServer = DALDbContextGeneration.ObtenirApplicationDBContext();
            IDepotMunicipalites municipalites = new DepotMunicipalitesSQLServer(contexteSQLServer);
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(depotImportation, municipalites);
            Console.WriteLine(traitement.Executer());
        }
    }
}