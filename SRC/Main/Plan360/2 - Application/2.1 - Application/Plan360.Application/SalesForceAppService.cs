using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class SalesForceAppService : AppServiceBase<SalesForce>, ISalesForceAppService
    {
        private readonly ISalesForceService _svc;

        public SalesForceAppService(ISalesForceService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
