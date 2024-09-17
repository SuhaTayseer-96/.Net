namespace school_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateofBirthToStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "DateOfBirth", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DateOfBirth");
        }
    }
}
