namespace BusTicketReservationSystem.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInPaymentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookedSeats", "PaymentId", "dbo.PaymentInitiateModels");
            DropIndex("dbo.BookedSeats", new[] { "PaymentId" });
            DropColumn("dbo.BookedSeats", "PaymentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookedSeats", "PaymentId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookedSeats", "PaymentId");
            AddForeignKey("dbo.BookedSeats", "PaymentId", "dbo.PaymentInitiateModels", "Id", cascadeDelete: true);
        }
    }
}
