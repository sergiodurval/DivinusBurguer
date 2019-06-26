namespace Divinus.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjusteTamanhoSenha : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 100, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Password", c => c.String(nullable: false, maxLength: 12, unicode: false));
        }
    }
}
