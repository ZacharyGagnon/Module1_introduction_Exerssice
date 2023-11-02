using M01_Srv_Municipalite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_DAL_Municipalite_SQLServer
{
    public class MunicipaliteContexteSQLServer : DbContext
    {
        public DbSet<Municipalite> Municipalites => base.Set<Municipalite>();
        public MunicipaliteContexteSQLServer(DbContextOptions p_options) : base(p_options)
        {
            ;
        }
    }
}
