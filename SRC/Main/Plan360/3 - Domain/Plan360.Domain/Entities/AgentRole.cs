
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // AgentRole
    public class AgentRole
    {
        public int IdAgentrole { get; set; } // id_agentrole (Primary key)
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified

        // Reverse navigation
        public virtual ICollection<Agent> Agents { get; set; } // Agent.FK_Agent_AgentRole

        public AgentRole()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
            Agents = new List<Agent>();
        }
    }

}
