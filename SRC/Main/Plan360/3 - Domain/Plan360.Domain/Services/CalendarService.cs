using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Domain.Services
{

    public class CalendarService : ServiceBase<Calendar>, ICalendarService
    {
        
        //declare the Repository
         private readonly ICalendarRepository _Repo;

        public CalendarService(ICalendarRepository Repo)
            : base(Repo)
        {
            _Repo = Repo;
        }

       


    }

}
