
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class UserProfileService : ServiceBase<UserProfile>, IUserProfileService
    {
        
        //declare the Repository
         private readonly IUserProfileRepository _Repo;

        public UserProfileService(IUserProfileRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

     


    }

}
