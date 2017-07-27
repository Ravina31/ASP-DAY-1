namespace AZMVC_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeptsModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Depts",
                c => new
                    {
                        DeptNo = c.Int(nullable: false, identity: true),
                        SName = c.String(maxLength: 50),
                        Location = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.DeptNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Depts");
        }
    }
}
