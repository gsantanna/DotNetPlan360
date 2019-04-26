using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class BrandRepository : RepositoryBase<Brand>, IBrandRepository
    { 
        public new  IEnumerable<Brand> DoSearch(string strSearch)
        {
            return Db.Brands.Where(f => f.Name.Contains(strSearch)         );

        }
    }

}
