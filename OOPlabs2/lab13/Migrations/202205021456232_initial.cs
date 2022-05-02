namespace lab13.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Speciality = c.String(),
                        Categories = c.String(),
                        Department = c.String(),
                        Photo = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DoctorID = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctors", t => t.DoctorID, cascadeDelete: true)
                .Index(t => t.DoctorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "DoctorID", "dbo.Doctors");
            DropIndex("dbo.Tickets", new[] { "DoctorID" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Doctors");
        }
    }
}
