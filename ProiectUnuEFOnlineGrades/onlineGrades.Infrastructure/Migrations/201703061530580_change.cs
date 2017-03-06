namespace onlineGrades.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profesors", "Nume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Prenume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "InitialaTata", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Profesors", "Mama", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Tata", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Nationalitate", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Cetatenie", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Nume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Prenume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "InitialaTata", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Students", "Mama", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Tata", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Nationalitate", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Cetatenie", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Cetatenie", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Nationalitate", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Tata", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Mama", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "InitialaTata", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Prenume", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "Nume", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "Cetatenie", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "Nationalitate", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "Tata", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "Mama", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "InitialaTata", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "Prenume", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "Nume", c => c.String(nullable: false));
        }
    }
}
