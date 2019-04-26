using System.Collections.Generic;
using System.Linq;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;

namespace Plan360.Infra.Data.Repositories
{
    public class CalendarRepository : RepositoryBase<Calendar>, ICalendarRepository
    {
        
 
        public new IEnumerable<Calendar> DoSearch(string strSearch)
        {
            return Db.Calendars.Where(f => f.Name.Contains(strSearch));

        }
    }

}
