using M01_Srv_Municipalite;

namespace M01_DAL_Municipalite_SQLServer
{
    public class DepotMunicipalitesSQLServer : IDepotMunicipalites
    {
        private MunicipaliteContexteSQLServer m_contexte;
        public DepotMunicipalitesSQLServer(MunicipaliteContexteSQLServer p_contexte)
        {
            m_contexte = p_contexte;
        }
        public M01_Srv_Municipalite.Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeographique)
        {
            if (p_codeGeographique == 0)
            {
                throw new ArgumentNullException(nameof(p_codeGeographique));
            }
            Municipalite municipalite = m_contexte.Municipalites.Where(m => m.MunicipaliteId == p_codeGeographique).FirstOrDefault();
            return municipalite.VersEntite();
        }
        public IEnumerable<M01_Srv_Municipalite.Municipalite> ListerMunicipalitesActives()
        {
            return m_contexte.Municipalites.Where(m => m.Actif == true).Select(m => m.VersEntite());
        }
        public void DesactiverMunicipalite(M01_Srv_Municipalite.Municipalite p_municipalite)
        {
            if (p_municipalite == null)
            {
                throw new ArgumentNullException(nameof(p_municipalite));
            }
            Municipalite municipalite = m_contexte.Municipalites.Where(m => m.MunicipaliteId == p_municipalite.CodeGeographique).FirstOrDefault() ?? throw new Exception("Municipalité non trouvée");
            municipalite.Actif = false;
        }
        public void AjouterMunicipalite(M01_Srv_Municipalite.Municipalite p_municipalite)
        {
            Municipalite municipaliteExistante = m_contexte.Municipalites.Where(m => m.MunicipaliteId == p_municipalite.CodeGeographique).FirstOrDefault();
            if (municipaliteExistante == null)
            {
                throw new Exception("Municipalité déjà existante");
            }
            else
            {
                Municipalite municipaliteAAjouter = new Municipalite(p_municipalite);
                m_contexte.Municipalites.Add(municipaliteAAjouter);
            }
        }
        public void MAJMunicipalite(M01_Srv_Municipalite.Municipalite p_municipalite)
        {
            Municipalite municipalite = m_contexte.Municipalites.Where(m => m.MunicipaliteId == p_municipalite.CodeGeographique).FirstOrDefault() ?? throw new Exception("Municipalité non trouvée");
            municipalite = new Municipalite(p_municipalite);
        }
    }
}