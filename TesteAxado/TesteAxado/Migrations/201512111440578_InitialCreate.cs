namespace TesteAxado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrier",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Identifier = c.String(nullable: false, maxLength: 50),
                        Phone = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 250),
                        Address = c.String(),
                        Number = c.Int(),
                        PostalCode = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.User",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Login = c.String(nullable: false, maxLength: 500),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.UserCarrier",
                c => new
                {
                    IdUser = c.Int(nullable: false),
                    IdCarrier = c.Int(nullable: false),
                    Rate = c.Int(nullable: false)
                })
                .ForeignKey("dbo.User", t => t.IdUser, cascadeDelete: true)
                .ForeignKey("dbo.Carrier", t => t.IdCarrier, cascadeDelete: true)
                .PrimaryKey(t => new { t.IdUser, t.IdCarrier });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserCarrier", "IdUser", "dbo.User");
            DropForeignKey("dbo.UserCarrier", "IdCarrier", "dbo.Carrier");
            DropTable("dbo.UserCarrier");
            DropTable("dbo.User");
            DropTable("dbo.Carrier");
        }
    }
}
