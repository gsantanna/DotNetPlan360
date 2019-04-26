using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class UserProfileRepository : RepositoryBase<UserProfile>, IUserProfileRepository
    {
        
 
        public new  IEnumerable<UserProfile> DoSearch(string strSearch)
        {
            return Db.UserProfiles.Where(f => f.Name.Contains(strSearch) || f.Login.Contains(strSearch)         );

        }
    }

}
