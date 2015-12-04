using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


//EF-configuration klasse zodat de configuratie via code kan gebeuren ipv via de application
//configuration file

namespace SC.DAL.EF
{
  internal class SupportCenterDbConfiguration : DbConfiguration
  {
    public SupportCenterDbConfiguration()
    {
      this.SetDefaultConnectionFactory(new System.Data.Entity.Infrastructure.SqlConnectionFactory());
      this.SetProviderServices("System.Data.SqlClient",System.Data.Entity.SqlServer.SqlProviderServices.Instance);
      this.SetDatabaseInitializer<SupportCenterDbContext>(new SupportCenterDbInitializer());
    }
  }
}
