using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public class TraitementImporterDonneesMunicipalite
    {
        private IDepotImportationMunicipalites m_depotImportationMunicipalistes;
        private IDepotMunicipalites m_depotMunicipalistes;
        public TraitementImporterDonneesMunicipalite(IDepotImportationMunicipalites p_depotImportationMunicipalites, IDepotMunicipalites p_depotMunicipalites)
        {
            m_depotImportationMunicipalistes = p_depotImportationMunicipalites;
            m_depotMunicipalistes = p_depotMunicipalites;
        }
        public StatistiquesImportationDonnees Executer()
        {
            StatistiquesImportationDonnees statistiques = new StatistiquesImportationDonnees();
            foreach (Municipalite municipalite in m_depotImportationMunicipalistes.LireMunicipalites())
            {
                if(m_depotMunicipalistes.ChercherMunicipaliteParCodeGeographique(municipalite.CodeGeographique) == null)
                {
                    m_depotMunicipalistes.AjouterMunicipalite(municipalite);
                    statistiques.NombreEnregistrementsAjoutes++;
                }
                else if(m_depotMunicipalistes.ChercherMunicipaliteParCodeGeographique(municipalite.CodeGeographique) == municipalite && m_depotMunicipalistes.ListerMunicipalitesActives().Where(m => m.CodeGeographique == municipalite.CodeGeographique) == null)
                {
                    m_depotMunicipalistes.MAJMunicipalite(municipalite);
                    statistiques.NombreEnregistrementsModifies++;
                }
                else if(municipalite != m_depotMunicipalistes.ChercherMunicipaliteParCodeGeographique(municipalite.CodeGeographique))
                {
                    m_depotMunicipalistes.DesactiverMunicipalite(municipalite);
                    statistiques.NombreEnregistrementsDesactives++;
                }
            }
            return statistiques;
        }
    }
}
