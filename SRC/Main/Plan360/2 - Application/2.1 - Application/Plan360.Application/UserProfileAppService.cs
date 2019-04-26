using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class UserProfileAppService : AppServiceBase<UserProfile>, IUserProfileAppService
    {
        private readonly IUserProfileService _svc;

        public UserProfileAppService(IUserProfileService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }


    }
}
