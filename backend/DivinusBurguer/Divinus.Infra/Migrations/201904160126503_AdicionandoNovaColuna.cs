namespace Divinus.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionandoNovaColuna : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food", "Category", c => c.String(nullable: false, maxLength: 250, unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "Category");
        }
    }
}
