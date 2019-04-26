using System;
using System.ComponentModel.DataAnnotations;

namespace Plan360.UI.ViewModels
{
    public class UserProfileViewModel
    {
        [Key]
        public string IdUser { get; set; }

        public string Name { get; set; } // name
        public string Login { get; set; } // login
        public string Email { get; set; } // email
        public string Phone { get; set; } // phone
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified
        public bool Active { get; set; } // active

      





    }
}
