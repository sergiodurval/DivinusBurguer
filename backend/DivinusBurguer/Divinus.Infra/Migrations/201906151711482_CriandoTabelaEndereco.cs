namespace Divinus.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriandoTabelaEndereco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ZipCode = c.String(maxLength: 250, unicode: false),
                        PublicPlace = c.String(maxLength: 250, unicode: false),
                        Neighborhood = c.String(maxLength: 250, unicode: false),
                        State = c.String(maxLength: 2, unicode: false),
                        Locality = c.String(maxLength: 250, unicode: false),
                        Gia = c.Long(nullable: false),
                        Ibge = c.Long(nullable: false),
                        Complement = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Address");
        }
    }
}
