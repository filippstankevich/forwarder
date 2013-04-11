namespace ForwarderDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Destination_Station_Add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transportations", "DestinationStationId", c => c.Int(nullable: false));
            AddForeignKey("dbo.Transportations", "DestinationStationId", "dbo.Stations", "ID");
            CreateIndex("dbo.Transportations", "DestinationStationId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Transportations", new[] { "DestinationStationId" });
            DropForeignKey("dbo.Transportations", "DestinationStationId", "dbo.Stations");
            DropColumn("dbo.Transportations", "DestinationStationId");
        }
    }
}
