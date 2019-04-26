  using Plan360.Domain.Entities;

namespace Plan360.Infra.Data.Migrations
{
    using System;
     using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Plan360.Infra.Data.Context.Plan360DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context.Plan360DataContext context)
        {

            return;

            context.Enterprises.AddOrUpdate(
                p => p.Name,
                new Enterprise { Active = true, Name = "Empresa teste #1" },
                new Enterprise { Active = true, Name = "Empresa teste #2" },
                new Enterprise { Active = true, Name = "Empresa teste #3" },
                new Enterprise { Active = true, Name = "Empresa teste #4" },
                new Enterprise { Active = false, Name = "Empresa teste #5" },
                new Enterprise { Active = true, Name = "Empresa teste #6" }
                );

            context.SaveChanges();

            context.Calendars.AddOrUpdate(
                p => p.Name,
                new Calendar
                {
                    Name = "Ciclo 1/2015",
                    IdEnterprise = 1,
                    Sartdate = new DateTime(2015, 1, 1),
                    Enddate = new DateTime(2015, 1, 30),
                    Active = true
                },
                 new Calendar
                 {
                     Name = "Ciclo 2/2015",
                     IdEnterprise = 1,
                     Sartdate = new DateTime(2015, 2, 1),
                     Enddate = new DateTime(2015, 2, 28),
                     Active = true
                 },
                new Calendar
                {
                    Name = "Ciclo 1/2015 outra empresa",
                    IdEnterprise = 2,
                    Sartdate = new DateTime(2015, 1, 1),
                    Enddate = new DateTime(2015, 1, 30),
                    Active = true
                }
                );



            context.SaveChanges();



            context.Roles.AddOrUpdate(
                    p => p.Name,
                    new Role
                    {
                        IdRole = 1,
                        Name = "Gerente de Produto",
                        Description = "Gerente de Produto é o responsável por parametrizar os planos",
                        CanParametrize = true
                    }
                    );

            context.Roles.AddOrUpdate(
              p => p.Name,
              new Role
              {
                  IdRole = 2,
                  Name = "Administrador Global",
                  Description = "O administrador pode fazer qualquer operação no sistema",
                  IsGlobalAdmin = true


              }
              );


            context.UserProfiles.AddOrUpdate(
                p => p.Login, new[]
                {
                    new UserProfile
                    {
                        IdUser = 1,
                        Email = "pxavier@herbarium.net",
                        Active = true,
                        Name = "Pedro Xavier",
                        Login = "HERBARIUM\\pxavier"
                    },
                    new UserProfile
                    {
                        IdUser = 2,
                        Email = "fabiog@herbarium.net",
                        Active = true,
                        Name = "Fabio Gazé",
                        Login = "HERBARIUM\\fabiog"
                    },
                    new UserProfile
                    {
                        IdUser = 3,
                        Email = "adm@herbarium.net",
                        Active = true,
                        Name = "adm",
                        Login = "HERBARIUM\\administrador"
                    },
                    new UserProfile
                    {
                        IdUser = 4,
                        Email = "desativado@herbarium.net",
                        Active = false,
                        Name = "Teste desativado",
                        Login = "HERBARIUM\\desativado"
                    }

                });

            context.SaveChanges();

            context.UserEnterpriseRoles.AddOrUpdate(p => new { p.IdUser, p.IdEnterprise },
                new[]
                {
                    new UserEnterpriseRole
                    {
                        IdEnterprise = 1,
                        IdUser = 1,
                        IdRole = 2
                    }, 
                    new UserEnterpriseRole
                    {
                        IdEnterprise = 2,
                        IdUser = 2,
                        IdRole = 1
                    }


                });



            context.SaveChanges();


            context.SalesForces.AddOrUpdate(s => s.Name,
                new SalesForce { IdSalesforce = 1, IdEnterprise = 1, Name = "HLB FV #1" },
                new SalesForce { IdSalesforce = 2, IdEnterprise = 1, Name = "HLB FV #2" },
                new SalesForce { IdSalesforce = 3, IdEnterprise = 2, Name = "Outra Emp #2" }

                );

            context.SaveChanges();

            context.AgentRoles.AddOrUpdate(s => s.Name,
                new AgentRole { Name = "REP", Description = "Representantes" },
                new AgentRole { Name = "GD", Description = "Gerente distrital" },
                new AgentRole { Name = "GR", Description = "Gerente regional" },
                new AgentRole { Name = "GNV", Description = "Gerente Nacional de Vendas" },
                new AgentRole { Name = "Outros", Description = "Outros funcionarios não agentes" }

                );

            context.SaveChanges();



            context.Entities.AddOrUpdate(e => new { e.Name, e.IdEnterprise },
                new Entity { Name = "Médico", IdEnterprise = 1, Active = true, Description = "Painel médico" },
                new Entity { Name = "Farmacia", IdEnterprise = 1, Active = true, Description = "Painel de farmácias" },
                new Entity { Name = "Médico", IdEnterprise = 2, Active = true, Description = "Painel médico segunda empresa" },
                 new Entity { Name = "TEste Desativado", IdEnterprise = 3, Active = true, Description = "Painel médico segunda empresa" }

                );

            context.SaveChanges();

            
            context.EntityMetadatas.AddOrUpdate(em => new { em.Name, em.IdEntity },
                new EntityMetadata { IdEntity = context.Entities.First(f => f.Name == "Médico" && f.IdEnterprise == 1).IdEntity, Name = "Nome", Active = true, Description = "Nome do médico" },
                new EntityMetadata { IdEntity = context.Entities.First(f => f.Name == "Médico" && f.IdEnterprise == 1).IdEntity, Name = "Especialidade", Active = true, Description = "Especialidade do médico" },
                new EntityMetadata { IdEntity = context.Entities.First(f => f.Name == "Médico" && f.IdEnterprise == 1).IdEntity, Name = "Produto Alvo", Active = true, Description = "Produto Alvo do médico" },
                new EntityMetadata { IdEntity = context.Entities.First(f => f.Name == "Médico" && f.IdEnterprise == 1).IdEntity, Name = "Time de Futebol", Active = true, Description = "Time de futebol do médico" }
                );

            context.SaveChanges();



            context.Brands.AddOrUpdate(b => new {b.Name, b.IdEnterprise},
                new Brand { Active = true, Name = "GAMMALINE", IdEnterprise = 1},
                new Brand { Active = true, Name = "ANDROSTEIN", IdEnterprise = 1 },
                new Brand { Active = true, Name = "BIOSLIN", IdEnterprise = 1 },
                new Brand { Active = true, Name = "HERBAGE", IdEnterprise = 1 },
                new Brand { Active = true,  Name = "POLIXITRIVIM", IdEnterprise = 2 });

            context.SaveChanges();


          context.ProductCategories.AddOrUpdate(pc => pc.Name ,
              new ProductCategory {  Name = "AG", Description = "Amostra Grátis", InvoiceConfig = "AG"},
              new ProductCategory { Name = "MP", Description = "Material Promocional", InvoiceConfig = "MP"},
              new ProductCategory {   Name = "OR", Description = "Produtos Originais", InvoiceConfig = "OR"},
              new ProductCategory {  Name = "AGR", Description = "Amostra Grátis Restrita", InvoiceConfig = "OR"}
              );

            context.SaveChanges();




        }
    }
}
