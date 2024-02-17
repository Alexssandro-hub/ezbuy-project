using ezBuy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MySql.Data.MySqlClient;

namespace ezBuy.Infrastructure.DAO_Layer
{
    public class RepositoryFactory
    {
        public static IDbConnection GetConnection(string connectionString) => new MySqlConnection(connectionString);

        public static TransactionScope CreateAsyncTransactionScope(System.Transactions.IsolationLevel isolationLevel = System.Transactions.IsolationLevel.ReadCommitted)
        {
            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = isolationLevel,
                Timeout = TransactionManager.MaximumTimeout
            };
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
        }

        public static string TenantConnectionString(Tenant tenant)
        {
            if (String.IsNullOrEmpty(tenant.Server) || String.IsNullOrEmpty(tenant.Port) || String.IsNullOrEmpty(tenant.UserAccess) || String.IsNullOrEmpty(tenant.Password))
                return null;

            return $"Server={tenant.Server};Port={tenant.Port};Database={tenant.Database};Uid={tenant.UserAccess};Pwd={tenant.Password}";

        }

        public static string NormalizedTableName(string tableName) => tableName;

        public static string GetTenantConnectionString(Tenant tenant, string defaultConn)
        {
            var tenantConnectionString = RepositoryFactory.TenantConnectionString(tenant);

            if (String.IsNullOrEmpty(tenantConnectionString))
            {
                var builder = new MySqlConnectionStringBuilder(defaultConn);
                builder.Database = tenant.Database;
                tenantConnectionString = builder.ConnectionString;
            }

            return tenantConnectionString;

        }
    }
}
