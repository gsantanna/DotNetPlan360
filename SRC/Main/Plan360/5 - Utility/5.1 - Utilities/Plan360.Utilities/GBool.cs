using System;

namespace Plan360.Utilities
{


    /// <summary>
    /// Representes a Twitter Bootstrap icon column value using Glyphs.
    /// </summary>
    public class GBool
    {
        public bool Value { get; set; }
        public GBool(bool? _value)
        {
            Value = Convert.ToBoolean(_value);
        }
    }


}
