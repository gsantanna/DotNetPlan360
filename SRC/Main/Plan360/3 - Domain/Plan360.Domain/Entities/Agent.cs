
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Agent
    public class Agent
    {
        public int IdAgent { get; set; } // id_agent (Primary key)
        public int IdSalesforce { get; set; } // id_salesforce
        public string Code { get; set; } // code
        public string Name { get; set; } // name
        public int? Parent { get; set; } // parent
        public string Street { get; set; } // street
        public string Number { get; set; } // number
        public long? Zipcode { get; set; } // zipcode
        public string City { get; set; } // city
        public string State { get; set; } // state
        public string Country { get; set; } // country
        public int IdAgentrole { get; set; } // id_agentrole
        public string Email { get; set; } // email
        public string Phone { get; set; } // phone
        public string IdErp { get; set; } // id_erp. Code of Agent as custommer in ERP
        public string Document { get; set; } //doc number of agent (person)

        // Reverse navigation
        public virtual ICollection<Agent> Agents { get; set; } // Agent.FK_Agent_Agent
        public virtual ICollection<EntityRecord> EntityRecords { get; set; } // EntityRecord.FK_EntityRecord_Agent
        public virtual ICollection<Invoice> Invoices { get; set; } // Invoice.FK_Invoice_Agent
        public virtual ICollection<Plan> Plans { get; set; } // Many to many mapping

        // Foreign keys
        public virtual Agent Agent_Parent { get; set; } // FK_Agent_Agent
        public virtual AgentRole AgentRole { get; set; } // FK_Agent_AgentRole
        public virtual SalesForce SalesForce { get; set; } // FK_Agent_SalesForce

        public Agent()
        {
            Agents = new List<Agent>();
            EntityRecords = new List<EntityRecord>();
            Invoices = new List<Invoice>();
            Plans = new List<Plan>();
        }
    }

}
