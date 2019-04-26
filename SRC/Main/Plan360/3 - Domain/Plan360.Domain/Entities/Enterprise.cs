
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Enterprise
    public class Enterprise
    {
        public int IdEnterprise { get; set; } // id_enterprise (Primary key)
        public string Name { get; set; } // Name
        public bool Active { get; set; } // active

        // Reverse navigation
        public virtual ICollection<Brand> Brands { get; set; } // Brand.FK_Brand_Enterprise
        public virtual ICollection<Calendar> Calendars { get; set; } // Calendar.FK_Calendar_Enterprise
        public virtual ICollection<Entity> Entities { get; set; } // Entity.FK_Entity_Enterprise
        public virtual ICollection<Plan> Plans { get; set; } // Plan.FK_Plan_Enterprise
        public virtual ICollection<SalesForce> SalesForces { get; set; } // SalesForce.FK_SalesForce_Enterprise
        public virtual ICollection<UserEnterpriseRole> UserEnterpriseRoles { get; set; } // Many to many mapping

        public Enterprise()
        {
            Active = true;
            Brands = new List<Brand>();
            Calendars = new List<Calendar>();
            Entities = new List<Entity>();
            Plans = new List<Plan>();
            SalesForces = new List<SalesForce>();
            UserEnterpriseRoles = new List<UserEnterpriseRole>();
        }
    }

}
