using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class EnterpriseAppService : AppServiceBase<Enterprise>, IEnterpriseAppService
    {
        private readonly IEnterpriseService _svc;

        public EnterpriseAppService(IEnterpriseService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }


    }
}
