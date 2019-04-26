
namespace Plan360.UI.JsModels
{
    public class JsBrand
    {
        public string Name { get; set; }
        public int IdBrand { get; set; }

        public string PhotoUrl
        {
            get { return string.Format("/photo/brand/{0}", IdBrand); }
        }

    }
}
