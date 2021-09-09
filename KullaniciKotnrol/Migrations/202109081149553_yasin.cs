namespace KullaniciKotnrol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class yasin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SurName = c.String(),
                        FirstEntry = c.DateTime(nullable: false),
                        LastEntry = c.DateTime(nullable: false),
                        IsAcvtive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
