using ezBuy.Extensions.Constants;
using ezBuy.Providers.Interfaces;

namespace ezBuy.Providers
{
    public abstract class TenantProvider : ITenantProvider
    {
        public TenantProvider()
        {
                
        }

        public string GetCurrentTenantSchema()
        {
            return TenantsDescription.GetRootSchema();
        }
    }
}
