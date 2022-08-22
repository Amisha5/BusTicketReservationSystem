namespace BusTicketReservationSystem.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Feedbackformadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FeedBacks",
                c => new
                    {
                        FeedBackId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        HowSatisfied = c.String(),
                        IsLiked = c.String(),
                        Rating = c.Double(nullable: false),
                        BusId = c.Int(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.FeedBackId)
                .ForeignKey("dbo.BusDetails", t => t.BusId, cascadeDelete: false)
                .Index(t => t.BusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeedBacks", "BusId", "dbo.BusDetails");
            DropIndex("dbo.FeedBacks", new[] { "BusId" });
            DropTable("dbo.FeedBacks");
        }
    }
}
