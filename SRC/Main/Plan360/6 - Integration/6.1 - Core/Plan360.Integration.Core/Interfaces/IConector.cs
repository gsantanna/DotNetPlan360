
using Plan360.Integration.Core.Entities;
using System.Collections.Generic;
namespace Plan360.Integration.Core.Interfaces
{
    public interface IConector
    {
         IEnumerable<Column> Columns();
         int ColumnCount();

         int RowCount();



        
    }
}
