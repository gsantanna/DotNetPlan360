using System.Collections.Generic;

namespace Plan360.UI.JsModels
{

    public class JsPlanProductUsage
    {
        

        public IEnumerable<JsPlanProductDetail> Details { get; set; }

        public JsPlanProductUsage()
        {
            this.Details = new List<JsPlanProductDetail>();
        }

        public class JsPlanProductDetail
        {
   
        }


    }
}
