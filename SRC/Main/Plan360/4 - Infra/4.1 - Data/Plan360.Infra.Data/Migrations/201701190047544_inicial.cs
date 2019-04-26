namespace Plan360.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.PlanParameter", "idplanproduct", "dbo.PlanProduct");
            //DropForeignKey("dbo.PlanParameter", "idplanentity", "dbo.PlanEntity");
            //AddForeignKey("dbo.PlanParameter", "idplanproduct", "dbo.PlanProduct", "idplanproduct", cascadeDelete: true);
            //AddForeignKey("dbo.PlanParameter", "idplanentity", "dbo.PlanEntity", "idplanentity", cascadeDelete: true);
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.PlanParameter", "idplanentity", "dbo.PlanEntity");
            //DropForeignKey("dbo.PlanParameter", "idplanproduct", "dbo.PlanProduct");
            //AddForeignKey("dbo.PlanParameter", "idplanentity", "dbo.PlanEntity", "idplanentity");
            //AddForeignKey("dbo.PlanParameter", "idplanproduct", "dbo.PlanProduct", "idplanproduct");
        }
    }
}
