
using AutoMapper;
using Plan360.Domain.Entities;
using Plan360.UI.JsModels;
using Plan360.UI.ViewModels.Agent;
using Plan360.UI.ViewModels.Plan;
using Plan360.UI.ViewModels.Product;

namespace Plan360.UI.MVC.AutoMapper
{
    public class JsModelsMappingProfile : Profile
    {
        //public override string ProfileName
        //{
        //    get { return "JsModelsMapping"; }
        //}

        protected override void Configure()
        {  

            //JsProduct
            Mapper.CreateMap<Brand, JsBrand>();
            Mapper.CreateMap<Product, JsProduct>();//.ForMember(dest=> dest.Brand, opt => opt.MapFrom(src=> src.Brand.Name));

            Mapper.CreateMap<JsProduct, ProductViewModel>();
            Mapper.CreateMap<JsProduct, Product>();

            Mapper.CreateMap<JsProduct, PlanProduct>();

            Mapper.CreateMap<PlanProduct, JsProduct>()
                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Product.Brand.Name))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Product.Code))
                .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.Product.IdProduct));








            //JsAgent
            Mapper.CreateMap<Agent, JsAgent>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.AgentRole.Name));

           
            Mapper.CreateMap<JsAgent, AgentViewModel>();
            Mapper.CreateMap<JsAgent, Agent>();
            

            //JsEntity
            Mapper.CreateMap<JsEntity, PlanEntityViewModel>();
            Mapper.CreateMap<JsEntity, PlanEntity>();
            Mapper.CreateMap<PlanEntity, JsEntity>().ForMember(dest => dest.Field, opt => opt.MapFrom(src => src.EntityMetadata.Name));



        }


    }
}