namespace Divinus.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ajusteNaColunaQuantidade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Food", "Quantity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Food", "Quantity", c => c.Int(nullable: false));
        }
    }
}
