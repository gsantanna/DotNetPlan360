using System;
namespace Plan360.UI.ViewModels.Entity

{
    // Entity
    public class EntityViewModel
    {
        public int IdEntity { get; set; } // id_entity (Primary key)
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public bool Active { get; set; } // active
        public int IdEnterprise { get; set; } // id_enterprise

        // Foreign keys
        public virtual EnterpriseViewModel Enterprise { get; set; } // FK_Entity_Enterprise

     
    }

}
