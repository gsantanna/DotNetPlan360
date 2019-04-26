
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System.Collections.Generic;

namespace Plan360.Domain.Entities
{
    // Role
    public class Role
    {
        public int IdRole { get; set; } // id_role (Primary key)
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        

        //Todo Create a lot of permission masks
        public bool IsAdmin { get; set; } // IsAdmin
        public bool IsGlobalAdmin { get; set; }
        public bool CanParametrize { get; set; }


        // Reverse navigation
        public virtual ICollection<UserEnterpriseRole> UserEnterpriseRoles { get; set; } // Many to many mapping

        public Role()
        {
            IsAdmin = false;
            IsGlobalAdmin = false;

            
            UserEnterpriseRoles = new List<UserEnterpriseRole>();
        }
    }

}
