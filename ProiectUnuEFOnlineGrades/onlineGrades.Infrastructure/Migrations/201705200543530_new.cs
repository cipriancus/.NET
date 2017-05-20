namespace onlineGrades.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profesors", "Nume", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profesors", "Username", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profesors", "Password", c => c.String(maxLength: 64));
            AlterColumn("dbo.Profesors", "Prenume", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profesors", "InitialaTata", c => c.String(maxLength: 5));
            AlterColumn("dbo.Profesors", "Email", c => c.String());
            AlterColumn("dbo.Profesors", "Mama", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profesors", "Tata", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profesors", "Nationalitate", c => c.String(maxLength: 20));
            AlterColumn("dbo.Profesors", "Cetatenie", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Nume", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Username", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Password", c => c.String(maxLength: 64));
            AlterColumn("dbo.Students", "Prenume", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "InitialaTata", c => c.String(maxLength: 5));
            AlterColumn("dbo.Students", "Email", c => c.String());
            AlterColumn("dbo.Students", "Mama", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Tata", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Nationalitate", c => c.String(maxLength: 20));
            AlterColumn("dbo.Students", "Cetatenie", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Cetatenie", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Nationalitate", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Tata", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Mama", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Students", "InitialaTata", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Students", "Prenume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Password", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Students", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Nume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Cetatenie", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Nationalitate", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Tata", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Mama", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Profesors", "InitialaTata", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.Profesors", "Prenume", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Password", c => c.String(nullable: false, maxLength: 64));
            AlterColumn("dbo.Profesors", "Username", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Profesors", "Nume", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
