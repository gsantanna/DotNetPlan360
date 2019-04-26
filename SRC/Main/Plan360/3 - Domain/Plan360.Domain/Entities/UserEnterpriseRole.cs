
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier

namespace Plan360.Domain.Entities
{
    // UserEnterpriseRole
    public class UserEnterpriseRole
    {
        public int IdUser { get; set; } // id_user (Primary key)
        public int IdEnterprise { get; set; } // id_enterprise (Primary key)
        public int IdRole { get; set; } // id_role (Primary key)

        // Foreign keys
        public virtual Enterprise Enterprise { get; set; } // FK_UserEnterpriseRole_Enterprise
        public virtual Role Role { get; set; } // FK_UserEnterpriseRole_Role
        public virtual UserProfile UserProfile { get; set; } // FK_UserEnterpriseRole_UserProfile
    }

}
