namespace BusTicketReservationSystem.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookedSeats",
                c => new
                    {
                        SeatId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                        BusId = c.Int(nullable: false),
                        PaymentId = c.Int(nullable: false),
                        A1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        A10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        B10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C4 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C5 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C6 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C7 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C8 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C9 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        C10 = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.SeatId)
                .ForeignKey("dbo.BusDetails", t => t.BusId, cascadeDelete: true)
                .ForeignKey("dbo.PaymentInitiateModels", t => t.PaymentId, cascadeDelete: false)
                .Index(t => t.BusId)
                .Index(t => t.PaymentId);
            
            CreateTable(
                "dbo.BusDetails",
                c => new
                    {
                        BusId = c.Int(nullable: false, identity: true),
                        BusName = c.String(nullable: false),
                        Category = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        RouteId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TripId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusId)
                .ForeignKey("dbo.Routes", t => t.RouteId, cascadeDelete: false)
                .ForeignKey("dbo.Trips", t => t.TripId, cascadeDelete: false)
                .Index(t => t.RouteId)
                .Index(t => t.TripId);
            
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        RouteId = c.Int(nullable: false, identity: true),
                        FromLocation = c.String(nullable: false),
                        ToLocation = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RouteId);
            
            CreateTable(
                "dbo.Trips",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        JourneyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.PaymentInitiateModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderId = c.String(),
                        RazorpayKey = c.String(),
                        Currency = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Amount = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookedSeats", "PaymentId", "dbo.PaymentInitiateModels");
            DropForeignKey("dbo.BookedSeats", "BusId", "dbo.BusDetails");
            DropForeignKey("dbo.BusDetails", "TripId", "dbo.Trips");
            DropForeignKey("dbo.BusDetails", "RouteId", "dbo.Routes");
            DropIndex("dbo.BusDetails", new[] { "TripId" });
            DropIndex("dbo.BusDetails", new[] { "RouteId" });
            DropIndex("dbo.BookedSeats", new[] { "PaymentId" });
            DropIndex("dbo.BookedSeats", new[] { "BusId" });
            DropTable("dbo.PaymentInitiateModels");
            DropTable("dbo.Trips");
            DropTable("dbo.Routes");
            DropTable("dbo.BusDetails");
            DropTable("dbo.BookedSeats");
        }
    }
}
