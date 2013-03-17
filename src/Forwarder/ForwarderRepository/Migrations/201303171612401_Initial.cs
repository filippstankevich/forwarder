namespace ForwarderDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ETSNGs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transportations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RegNumber = c.String(nullable: false),
                        Comment = c.String(),
                        Volume = c.Int(nullable: false),
                        TransportCount = c.Int(nullable: false),
                        EtsngId = c.Int(nullable: false),
                        GngId = c.Int(nullable: false),
                        SourceStationId = c.Int(nullable: false),
                        DestinationStationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ETSNGs", t => t.EtsngId, cascadeDelete: true)
                .ForeignKey("dbo.GNGs", t => t.GngId, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.SourceStationId)
                .ForeignKey("dbo.Stations", t => t.DestinationStationId)
                .Index(t => t.EtsngId)
                .Index(t => t.GngId)
                .Index(t => t.SourceStationId)
                .Index(t => t.DestinationStationId);
            
            CreateTable(
                "dbo.GNGs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transportations", new[] { "DestinationStationId" });
            DropIndex("dbo.Transportations", new[] { "SourceStationId" });
            DropIndex("dbo.Transportations", new[] { "GngId" });
            DropIndex("dbo.Transportations", new[] { "EtsngId" });
            DropForeignKey("dbo.Transportations", "DestinationStationId", "dbo.Stations");
            DropForeignKey("dbo.Transportations", "SourceStationId", "dbo.Stations");
            DropForeignKey("dbo.Transportations", "GngId", "dbo.GNGs");
            DropForeignKey("dbo.Transportations", "EtsngId", "dbo.ETSNGs");
            DropTable("dbo.Stations");
            DropTable("dbo.GNGs");
            DropTable("dbo.Transportations");
            DropTable("dbo.ETSNGs");
        }
    }
}
