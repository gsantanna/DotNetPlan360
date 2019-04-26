
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

using System;
using System.Collections.Generic;

namespace Plan360.Domain.Entities
{


    public class UserProfile
    {
        public int IdUser { get; set; } // iduser (Primary key)
        public string Name { get; set; } // name
        public string Login { get; set; } // login
        public string Email { get; set; } // email
        public string Phone { get; set; } // phone
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public bool Active { get; set; } // Active

        // Reverse navigation
        public virtual ICollection<Plan> Plans_IdCreated { get; set; } // Plan.FK_Plan_UserProfileCreated
        public virtual ICollection<Plan> Plans_IdModified { get; set; } // Plan.FK_Plan_UserProfileModified
        public virtual ICollection<Plan> Plans_IdOwner { get; set; } // Plan.FK_Plan_UserProfileOwner
        public virtual ICollection<UserEnterpriseRole> UserEnterpriseRoles { get; set; } // Many to many mapping

        public UserProfile()
        {
            Plans_IdCreated = new List<Plan>();
            Plans_IdModified = new List<Plan>();
            Plans_IdOwner = new List<Plan>();
            UserEnterpriseRoles = new List<UserEnterpriseRole>();
        }
    }



}
