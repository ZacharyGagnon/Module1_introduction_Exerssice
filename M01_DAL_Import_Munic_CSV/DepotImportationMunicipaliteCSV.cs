using M01_Srv_Municipalite;
using System.Text;

namespace M01_DAL_Import_Munic_CSV
{
    public class DepotImportationMunicipaliteCSV : IDepotImportationMunicipalites
    {
        private string m_pathCSV = @"C:\DEV_Session_4\Module1_introduction_Exerssice\MUN.csv";
        public IEnumerable<Municipalite> LireMunicipalites()
        {
            List<Municipalite> listeMunicipalite = new List<Municipalite>();
            using (StreamReader sr = new StreamReader(m_pathCSV))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string ligneActuelleDuFichier = sr.ReadLine();
                    string[] subString = ligneActuelleDuFichier.Split(',');
                    int codeGeo = int.Parse(subString[0]);
                    DateTime dateElection = DateTime.Parse(subString[20]);
                    Municipalite municipalite = new Municipalite(codeGeo, subString[1], subString[7], subString[8], dateElection);
                    listeMunicipalite.Add(municipalite);
                }
            }
            return listeMunicipalite;
        }
    }
}