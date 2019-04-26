using Plan360.Application.Interfaces;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Services;

namespace Plan360.Application
{
    public class CalendarAppService : AppServiceBase<Calendar>, ICalendarAppService
    {
        private readonly ICalendarService _svc;

        public CalendarAppService(ICalendarService Svc)
            : base(Svc)
        {
            _svc = Svc;

        }

        

    }
}
