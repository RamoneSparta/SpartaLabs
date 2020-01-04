namespace Lad_33_Helpdesk_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "NewField", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Users", "NewField");
        }
    }
}
