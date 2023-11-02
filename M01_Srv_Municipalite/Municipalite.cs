namespace M01_Srv_Municipalite
{
    public class Municipalite
    {
        public int CodeGeographique { get; set; }
        public string NomMunicipalite { get; set; }
        public string? AdresseCourriel { get; set; }
        public string? AdresseWeb { get; set; }
        public DateTime DateProchaineElection { get; set; }

        public Municipalite(int p_codeGeographique, string p_nomMunicipalite, string? p_adresseCourriel, string? p_adresseWeb, DateTime p_dateProchaineElection)
        {
            CodeGeographique = p_codeGeographique;
            NomMunicipalite = p_nomMunicipalite;
            AdresseCourriel = p_adresseCourriel;
            AdresseWeb = p_adresseWeb;
            DateProchaineElection = p_dateProchaineElection;
        }
        public override bool Equals(object? p_municipalite)
        {
            return p_municipalite is Municipalite municipalite &&
                   CodeGeographique == municipalite.CodeGeographique &&
                   NomMunicipalite == municipalite.NomMunicipalite &&
                   AdresseCourriel == municipalite.AdresseCourriel &&
                   AdresseWeb == municipalite.AdresseWeb &&
                   DateProchaineElection == municipalite.DateProchaineElection;
        }
    }
}