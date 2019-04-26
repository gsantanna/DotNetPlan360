namespace Plan360.UI.JsModels
{
    public class JsProduct
    {
        public string Name { get; set; }
        public string IdProduct { get; set; }
        public string Code { get; set; }
        public string BrandName { get; set; }
        public int PackSize { get; set; }

        public string PhotoUrl
        {
            get
            {
                return string.Format("/photo/product/{0}", IdProduct);
                
            }
        }     


    }
}