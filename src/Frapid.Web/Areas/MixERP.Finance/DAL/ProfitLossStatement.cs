using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Frapid.Configuration.Db;
using Frapid.Mapper.Database;
using MixERP.Finance.DAL.ProfitLoss;
using MixERP.Finance.QueryModels;

namespace MixERP.Finance.DAL
{
    public static class ProfitLossStatement
    {
        private static IProfitLoss GetService(string tenant)
        {
            string providerName = DbProvider.GetProviderName(tenant);
            var type = DbProvider.GetDbType(providerName);

            if (type == DatabaseType.PostgreSQL)
            {
                return new PostgreSQL();
            }

            if (type == DatabaseType.SqlServer)
            {
                return new SqlServer();
            }

            throw new NotImplementedException();
        }


        public static async Task<IEnumerable<dynamic>> GetAsync(string tenant, PlAccountQueryModel query)
        {
            var service = GetService(tenant);
            return await service.GetAsync(tenant, query).ConfigureAwait(false);
        }
    }
}