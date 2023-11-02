using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_DAL_Municipalite_SQLServer
{
    public class DALDbContextGeneration
    {
        private static DbContextOptions<MunicipaliteContexteSQLServer> m_dbContextOptions;
        private static PooledDbContextFactory<MunicipaliteContexteSQLServer> m_pooledDbContextFactory;
        static DALDbContextGeneration()
        {
            IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName).AddJsonFile("appsetting.json", false).Build();

            m_dbContextOptions = new DbContextOptionsBuilder<MunicipaliteContexteSQLServer>().UseSqlServer(config.GetConnectionString("connectionReservationVoiture")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .Options;
            m_pooledDbContextFactory = new PooledDbContextFactory<MunicipaliteContexteSQLServer>(m_dbContextOptions);
        }

        public static MunicipaliteContexteSQLServer ObtenirApplicationDBContext()
        {
            return m_pooledDbContextFactory.CreateDbContext();
        }
    }
}
