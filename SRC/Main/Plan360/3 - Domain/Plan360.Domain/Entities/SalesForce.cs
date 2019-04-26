
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // SalesForce
    public class SalesForce
    {
        public int IdSalesforce { get; set; } // id_salesforce (Primary key)
        public int IdEnterprise { get; set; } // id_enterprise
        public string Name { get; set; } // name

        // Reverse navigation
        public virtual ICollection<Agent> Agents { get; set; } // Agent.FK_Agent_SalesForce

        // Foreign keys
        public virtual Enterprise Enterprise { get; set; } // FK_SalesForce_Enterprise

        public SalesForce()
        {
            Agents = new List<Agent>();
        }
    }

}
