using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using System.Data.Entity;
using Plan360.Infra.Data.Context;

namespace Plan360.Infra.Data.Repositories
{
    public class EntityDataRepository : RepositoryBase<EntityData>, IEntityDataRepository
    {

        //TODO: Arrancar isso daqui e criar um método!!!
        public new IEnumerable<EntityData>  DoSearch(string strSearch)
        {

            using (Plan360DataContext Dbx = new Plan360DataContext())
            {
                Dbx.Configuration.AutoDetectChangesEnabled = false;
                Dbx.Configuration.LazyLoadingEnabled = false;
                Dbx.Configuration.ProxyCreationEnabled = false;
                //     return Db.EntityDatas.Where(f => f.IdEntitymetadata.ToString() ==  strSearch  );// f.Value.Contains(strSearch));

                var ret = Dbx.EntityDatas.Include(f => f.EntityRecord).Where(f => f.IdEntitymetadata.ToString() == strSearch);
                return ret.ToList();
            }




            //TODO: Verify if that is realy necessary 

        }




        public new IEnumerable<EntityData> GetAll()
        {
            using (Plan360DataContext Dbx = new Plan360DataContext())
            {
                Dbx.Configuration.AutoDetectChangesEnabled = false;
                Dbx.Configuration.LazyLoadingEnabled = false;
                Dbx.Configuration.ProxyCreationEnabled = false;

                var ret = Dbx.EntityDatas.Include(f => f.EntityRecord);
                return ret.ToList();
            }


        }

       
 



    }

}
