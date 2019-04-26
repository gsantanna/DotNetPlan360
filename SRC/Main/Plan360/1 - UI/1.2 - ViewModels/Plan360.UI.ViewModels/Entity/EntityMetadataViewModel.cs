

namespace  Plan360.UI.ViewModels.Entity

{
    // EntityMetadata
    public class EntityMetadataViewModel
    {
        public int IdEntitymetadata { get; set; } // id_entitymetadata (Primary key)
        public int IdEntity { get; set; } // id_entity
        public string Name { get; set; } // name
        public string Description { get; set; } // description
        public bool Active { get; set; } // active

        
        // Foreign keys
        public virtual EntityViewModel Entity { get; set; } // FK_EntityMetadata_Entity

    }

}
