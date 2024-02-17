using ezBuy.Extensions.Constants;
using ezBuy.Providers.Interfaces;

namespace ezBuy.Providers
{
    public interface TenantProvider : ITenantProvider
    {
        public string GetCurrentTenantSchema()
        {
            return TenantsDescription.GetRootSchema();
        }
    }
}
