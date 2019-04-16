namespace Divinus.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250, unicode: false),
                        Description = c.String(nullable: false, maxLength: 250, unicode: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageName = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Food");
        }
    }
}
