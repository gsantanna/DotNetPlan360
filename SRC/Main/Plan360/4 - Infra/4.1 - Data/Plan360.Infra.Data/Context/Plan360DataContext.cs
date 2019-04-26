using Plan360.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Plan360.Infra.Data.EntityConfig;
using System;

namespace Plan360.Infra.Data.Context
{
    public class Plan360DataContext : DbContext
    {


       public Plan360DataContext()
           : base("Plan360ConnectionString")
        {
           //TODO : Veriry why we need this horrible hack to ensure Entities SQL dll is loaded.
            //source: http://robsneuron.blogspot.in/2013/11/entity-framework-upgrade-to-6.html
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            //    context.Database.Log = Console.Write; 

            this.Database.Log = Console.Write;


        }


        //TODO Add all entities dbsets here


        public IDbSet<Agent> Agents { get; set; } // Agent
        public IDbSet<AgentRole> AgentRoles { get; set; } // AgentRole
        public IDbSet<Brand> Brands { get; set; } // Brand
        public IDbSet<Calendar> Calendars { get; set; } // Calendar
        public IDbSet<Enterprise> Enterprises { get; set; } // Enterprise
        public IDbSet<Entity> Entities { get; set; } // Entity
        public IDbSet<EntityData> EntityDatas { get; set; } // EntityData
        public IDbSet<EntityMetadata> EntityMetadatas { get; set; } // EntityMetadata
        public IDbSet<EntityRecord> EntityRecords { get; set; } // EntityRecord
        public IDbSet<Invoice> Invoices { get; set; } // Invoice
        public IDbSet<InvoiceProduct> InvoiceProducts { get; set; } // InvoiceProduct
        public IDbSet<InvoiceProductSource> InvoiceProductSources { get; set; } // InvoiceProductSource

        public IDbSet<Plan> Plans { get; set; } // Plan
        public IDbSet<PlanEntity> PlanEntities { get; set; }//Plan Entity 
        public IDbSet<PlanProduct> PlanProducts { get; set; } //PlanProducts 
        public IDbSet<PlanParameter> PlanParameters { get; set; } //PlanParameter
 
        

       public IDbSet<Product> Products { get; set; } // Product
        public IDbSet<ProductCategory> ProductCategories { get; set; } // ProductCategory
        public IDbSet<Role> Roles { get; set; } // Role
        public IDbSet<SalesForce> SalesForces { get; set; } // SalesForce
        public IDbSet<UserEnterpriseRole> UserEnterpriseRoles { get; set; } // UserEnterpriseRole
        public IDbSet<UserProfile> UserProfiles { get; set; } // UserProfile
        public IDbSet<Stock> Stocks { get; set; } //Stock


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();




            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure( p=> p.IsRequired());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));



            //TODO Add here all entities configurations
            modelBuilder.Configurations.Add(new AgentConfiguration());
            modelBuilder.Configurations.Add(new AgentRoleConfiguration());
            modelBuilder.Configurations.Add(new BrandConfiguration());
            modelBuilder.Configurations.Add(new CalendarConfiguration());
            modelBuilder.Configurations.Add(new EnterpriseConfiguration());
            modelBuilder.Configurations.Add(new EntityConfiguration());
            modelBuilder.Configurations.Add(new EntityDataConfiguration());
            modelBuilder.Configurations.Add(new EntityMetadataConfiguration());
            modelBuilder.Configurations.Add(new EntityRecordConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceProductConfiguration());
            modelBuilder.Configurations.Add(new InvoiceProductSourceConfiguration());
          
            
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new PlanEntityConfiguration());         
            modelBuilder.Configurations.Add(new PlanEntityCountConfiguration());

            modelBuilder.Configurations.Add(new PlanProductConfiguration());

            modelBuilder.Configurations.Add(new PlanParameterConfiguration());

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ProductCategoryConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SalesForceConfiguration());
            modelBuilder.Configurations.Add(new UserEnterpriseRoleConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());

           



        }






    }
}
