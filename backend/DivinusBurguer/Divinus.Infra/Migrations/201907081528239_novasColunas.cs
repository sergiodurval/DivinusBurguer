namespace Divinus.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class novasColunas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Address", "Number", c => c.Long());
            AddColumn("dbo.Address", "Reference", c => c.String(maxLength: 250, unicode: false));
            AddColumn("dbo.Food", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "Quantity");
            DropColumn("dbo.Address", "Reference");
            DropColumn("dbo.Address", "Number");
        }
    }
}
