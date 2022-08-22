namespace BusTicketReservationSystem.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class II : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PaymentInitiateModels", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.PaymentInitiateModels", "PhoneNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PaymentInitiateModels", "PhoneNumber", c => c.String());
            AlterColumn("dbo.PaymentInitiateModels", "Email", c => c.String());
        }
    }
}
