using System;

namespace Plan360.Domain.Entities
{
    public class Stock
    {
        public Product Product { get; set; }
        public Calendar Calendar { get; set; }
        public int idProduct { get; set; }
        public int idCalendar { get; set; }
        public Int64 BaseQuantity { get; set; }


    }

}
