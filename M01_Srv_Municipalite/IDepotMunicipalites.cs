using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public interface IDepotMunicipalites
    {
        public Municipalite ChercherMunicipaliteParCodeGeographique(int p_codeGeographique);
        public IEnumerable<Municipalite> ListerMunicipalitesActives();
        public void DesactiverMunicipalite(Municipalite p_municipalite);
        public void AjouterMunicipalite(Municipalite p_municipalite);
        public void MAJMunicipalite(Municipalite p_municipalite);
    }
}
