using System;

namespace Plan360.UI.ViewModels.Agent
{
    public class AgentRoleViewModel
    {
        public int IdAgentrole { get; set; } // id_agentrole (Primary key)
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public DateTime? Created { get; set; } // created
        public DateTime? Modified { get; set; } // modified

    }
}
