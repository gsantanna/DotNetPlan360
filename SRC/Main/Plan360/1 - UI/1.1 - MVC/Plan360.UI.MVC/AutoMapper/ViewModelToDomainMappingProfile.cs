
using AutoMapper;
using Plan360.Domain.Entities;
using Plan360.UI.ViewModels;
using Plan360.UI.ViewModels.Agent;
using Plan360.UI.ViewModels.Entity;
using Plan360.UI.ViewModels.Plan;
using Plan360.UI.ViewModels.Product;

namespace Plan360.UI.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        //public override string ProfileName
        //{
        //    get { return "ViewModelToDomainMapping"; }
        //}

       
        protected override void Configure()
        {
            Mapper.CreateMap<EnterpriseViewModel, Enterprise>();
            Mapper.CreateMap<CalendarViewModel, Calendar>();
            Mapper.CreateMap<UserProfileViewModel, UserProfile>();
            Mapper.CreateMap<AgentViewModel, Agent>();
            Mapper.CreateMap<ProductViewModel, Product>();
            Mapper.CreateMap<BrandViewModel, Brand>();
            Mapper.CreateMap<ProductCategoryViewModel, ProductCategory>();
            Mapper.CreateMap<SalesForceViewModel, SalesForce>();
            Mapper.CreateMap<AgentRoleViewModel, AgentRole>();
            Mapper.CreateMap<EntityViewModel, Entity>();
            Mapper.CreateMap<EntityDataViewModel, EntityData>();
            Mapper.CreateMap<EntityRecordViewModel, EntityRecord>();
            Mapper.CreateMap<EntityMetadataViewModel, EntityMetadata>();


            Mapper.CreateMap<PlanViewModel, Plan>();
            Mapper.CreateMap<PlanEntityViewModel, PlanEntity>();
            Mapper.CreateMap<PlanEntityCountViewModel, PlanEntityCount>();
            Mapper.CreateMap<PlanProductViewModel, PlanProduct>();
            Mapper.CreateMap<PlanParameterViewModel, PlanParameter>();

        }


    }
}