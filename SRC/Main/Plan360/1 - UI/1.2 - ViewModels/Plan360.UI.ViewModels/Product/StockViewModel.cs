namespace Plan360.UI.ViewModels
{
    public class StockViewModel
    {
        public int idProduct { get; set; }
        public int idCalendar { get; set; }

        public int Used { get; set; }
        public int Quantity { get; set; }

        public int Avaliable()
        {
            return Quantity - Used;
        }


    }
}
