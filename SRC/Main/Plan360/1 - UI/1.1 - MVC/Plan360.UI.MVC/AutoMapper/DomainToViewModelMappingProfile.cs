
using AutoMapper;
using Plan360.Domain.Entities;
using Plan360.UI.ViewModels;
using Plan360.UI.ViewModels.Agent;
using Plan360.UI.ViewModels.Entity;
using Plan360.UI.ViewModels.Plan;
using Plan360.UI.ViewModels.Product;

namespace Plan360.UI.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
     

        protected override void Configure()
        {
            Mapper.CreateMap<Enterprise, EnterpriseViewModel>();
            Mapper.CreateMap<Calendar, CalendarViewModel>();
            Mapper.CreateMap<UserProfile, UserProfileViewModel>();
            Mapper.CreateMap<Agent, AgentViewModel>();
            Mapper.CreateMap<Product, ProductViewModel>();
            Mapper.CreateMap<Brand, BrandViewModel>();
            Mapper.CreateMap<ProductCategory, ProductCategoryViewModel>();

            Mapper.CreateMap<SalesForce, SalesForceViewModel>();
            Mapper.CreateMap<AgentRole, AgentRoleViewModel>();
            Mapper.CreateMap<Entity, EntityViewModel>();
            Mapper.CreateMap<EntityRecord, EntityRecordViewModel>();
            Mapper.CreateMap<EntityMetadata, EntityMetadataViewModel>();
            Mapper.CreateMap<EntityData, EntityDataViewModel>();

            Mapper.CreateMap<Plan, PlanViewModel>();
            Mapper.CreateMap<PlanEntity, PlanEntityViewModel>();
            Mapper.CreateMap<PlanEntityCount, PlanEntityCountViewModel>();

            Mapper.CreateMap<PlanProduct, PlanProductViewModel>();
            Mapper.CreateMap<PlanParameter, PlanParameterViewModel>();
            




        }




    }
}