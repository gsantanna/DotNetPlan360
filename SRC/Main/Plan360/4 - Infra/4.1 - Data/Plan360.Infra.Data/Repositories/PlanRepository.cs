using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Xml;
using Plan360.Domain.Entities;
using Plan360.Domain.Interfaces.Repositories;
using Plan360.UI.Resources;

namespace Plan360.Infra.Data.Repositories
{
    public class PlanRepository : RepositoryBase<Plan>, IPlanRepository
    {


        public IEnumerable<Plan> DoSearch(string strSearch, int? idEnterprise, int? idCalendar)
        {
            return Db.Plans.Where(f => f.Name.Contains(strSearch) && f.Enterprise.Active && f.Calendar.Active);

        }         

        public IEnumerable<Plan> GetByName(int idCalendar, string strName)
        {
            return Db.Plans.Where(f => f.IdCalendar == idCalendar && f.Name == strName);
        }

        public new void Add(Plan plan)
        {
            //Create the parameters 
            CreatePlanParameters(plan);

            //Create the entityMetadataCount Item
            CreatePlanEntityMetadataCount(plan);




            var agents = plan.Agents.Select(age => Db.Agents.Find(age.IdAgent)).ToList();

            foreach (var pp in plan.PlanProducts)
            {
                pp.Packsize = Db.Products.First(f => f.IdProduct == pp.IdProduct).Packsize;
            }

            plan.Agents = agents;
            Db.Plans.Add(plan);
            Db.SaveChanges();
        }

        public new void Update(Plan plan)
        {
            //adjust FKS
            plan.PlanEntities.ToList().ForEach(f => f.IdPlan = plan.IdPlan);

            var previosPlan =
               Db.Plans.Where(p => p.IdPlan == plan.IdPlan)
                   .Include(p => p.PlanProducts)
                   .Include(p => p.Agents)
                   .Include(p => p.PlanEntities)
                   .Include(p => p.PlanParameters)
                   .Single();

            //remove all old plan data
            //Parameters
            previosPlan.PlanParameters.ToList().ForEach(x => Db.PlanParameters.Remove(x));

            //EntityMetadata
            ClearEntityMetadataCount(previosPlan);

            //Agents
            previosPlan.Agents.Clear();

            //Products
            previosPlan.PlanProducts.ToList().ForEach(x => Db.PlanProducts.Remove(x));

            //Entities
            previosPlan.PlanEntities.ToList().ForEach(x => Db.PlanEntities.Remove(x));

           
            #region Added Itens

            //initialize the collections
            previosPlan.PlanProducts = new List<PlanProduct>();
            previosPlan.PlanEntities = new List<PlanEntity>();



            foreach (var item in plan.Agents.ToList())
            {
                previosPlan.Agents.Add(Db.Agents.First(f => f.IdAgent == item.IdAgent));
            }

            foreach (var item in plan.PlanProducts.ToList())
            {

                previosPlan.PlanProducts.Add(new PlanProduct
                {
                    IdPlan = previosPlan.IdPlan,
                    IdProduct = item.IdProduct,
                    Packsize = Db.Products.First(f => f.IdProduct == item.IdProduct).Packsize //item.Product.Packsize

                });


            }

            foreach (var item in plan.PlanEntities)
            {
                previosPlan.PlanEntities.Add(new PlanEntity
                {
                    IdPlan = item.IdPlan,
                    IdEntitymetadata = item.IdEntitymetadata,
                    Value = item.Value
                });

            }


            #endregion

            //set the main fields
            previosPlan.Name = plan.Name;
            previosPlan.IdOwner = plan.IdOwner;
            previosPlan.Modified = plan.Modified;
            previosPlan.IdModified = plan.IdModified;
            previosPlan.IdCalendar = plan.IdCalendar;
            previosPlan.IdEnterprise = plan.IdEnterprise;


            Db.Entry(previosPlan).State = EntityState.Modified;
            Db.SaveChanges();

            //create the plan entity metadata count
            CreatePlanEntityMetadataCount(previosPlan);

            //create the empty parameters
            CreatePlanParameters(previosPlan);


            Db.SaveChanges();

        }
        
        



        #region PrivateHelperMethods

        private void CreatePlanEntityMetadataCount(Plan plan)
        {

            var agentList = (from a in plan.Agents
                             select a.IdAgent).ToArray();

            foreach (var ent in plan.PlanEntities)
            {
                ent.PlanEntityCounts = new List<PlanEntityCount>();




                (from ev in
                     Db.EntityDatas.Where(
                     f =>
                         f.Value == ent.Value &&
                         f.IdEntitymetadata == ent.IdEntitymetadata &&
                         agentList.Contains(f.EntityRecord.IdAgent)
                     )
                 group ev by new { ev.EntityRecord.IdAgent }
                     into grouped
                     select new
                     {
                         grouped.Key.IdAgent,
                         Count = grouped.Count()
                     }).ToList().ForEach(
                   f => ent.PlanEntityCounts.Add(new PlanEntityCount
                   {
                       IdAgent = f.IdAgent,
                       Count = f.Count,
                       IdPlanEntity = ent.IdPlanEntity,
                       PlanEntity = ent
                   })
                   );






            }
        }

        private void ClearEntityMetadataCount(Plan plan)
        {
            foreach (var ent in plan.PlanEntities)
            {
                ent.PlanEntityCounts.Clear();
            }

            Db.SaveChanges();
            //ent.PlanEntityCounts.ToList().ForEach(f=> Db.Entry(f).State = EntityState.Deleted );


        }

        private void CreatePlanParameters(Plan plan)
        {
            //Create the plan parameters 
            plan.PlanParameters = new List<PlanParameter>();

            foreach (var prd in plan.PlanProducts)
            {
                foreach (var ent in plan.PlanEntities)
                {
                    plan.PlanParameters.Add(new PlanParameter
                    {
                        Count = 0,
                        PlanProduct = prd,
                        PlanEntity = ent,
                        Total = 0,
                        TotalA = 0,
                        IdPlan = plan.IdPlan,
                        IdPlanEntity = ent.IdPlanEntity,
                        IdPlanProduct = prd.IdPlanProduct,
                        Plan = plan,
                        Percent = 0
                    });
                }
            }

        }

        #endregion

        #region Plan Parameter


        public PlanParameter GetPlanParameter(int idPlanParameter)
        {
            return Db.PlanParameters.Find(idPlanParameter);
        }

        public void UpdateParameters(Plan plan)
        {

            //attach the plan 
            Db.Plans.Attach(plan);
            Db.Entry(plan).State = EntityState.Modified;
            Db.SaveChanges();
            //update 
           

        }


        #endregion





    }

}
