using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class BrandAppService : AppServiceBase<Brand>, IBrandAppService
    {
        private readonly IBrandService _svc;

        public BrandAppService(IBrandService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
