

using System;

namespace Plan360.Utilities
{
   public static class Calculation
    {

       public static  Int32 GetAdjTotal(int packSize, double total )
       {
           double objRet=  ((total%packSize > 0)
               ? total - (total%packSize) + packSize
               : total
               );

           return Convert.ToInt32(Math.Ceiling(objRet));

       }
    }
}
