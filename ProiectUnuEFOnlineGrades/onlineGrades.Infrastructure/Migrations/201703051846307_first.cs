namespace onlineGrades.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategorieId = c.Guid(nullable: false),
                        Nume = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CategorieId);
            
            CreateTable(
                "dbo.Notas",
                c => new
                    {
                        NotaId = c.Guid(nullable: false),
                        Valoare = c.Single(nullable: false),
                        CursId = c.Guid(nullable: false),
                        StudentId = c.Guid(nullable: false),
                        CategorieId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.NotaId)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .ForeignKey("dbo.Curs", t => t.CursId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CursId)
                .Index(t => t.StudentId)
                .Index(t => t.CategorieId);
            
            CreateTable(
                "dbo.Curs",
                c => new
                    {
                        CursId = c.Guid(nullable: false),
                        Nume = c.String(nullable: false, maxLength: 50),
                        Credite = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CursId);
            
            CreateTable(
                "dbo.Profesors",
                c => new
                    {
                        ProfesorId = c.Guid(nullable: false),
                        Nume = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 64),
                        Prenume = c.String(nullable: false),
                        InitialaTata = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DataNasterii = c.DateTime(nullable: false),
                        Mama = c.String(nullable: false),
                        Tata = c.String(nullable: false),
                        Nationalitate = c.String(nullable: false),
                        Cetatenie = c.String(nullable: false),
                        RegisterUUID = c.Guid(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        ResetUUID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ProfesorId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Guid(nullable: false),
                        AnUniversitar = c.Int(nullable: false),
                        Nume = c.String(nullable: false),
                        Username = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 64),
                        Prenume = c.String(nullable: false),
                        InitialaTata = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        DataNasterii = c.DateTime(nullable: false),
                        Mama = c.String(nullable: false),
                        Tata = c.String(nullable: false),
                        Nationalitate = c.String(nullable: false),
                        Cetatenie = c.String(nullable: false),
                        RegisterUUID = c.Guid(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        ResetUUID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.ProfesorCurs",
                c => new
                    {
                        Profesor_ProfesorId = c.Guid(nullable: false),
                        Curs_CursId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profesor_ProfesorId, t.Curs_CursId })
                .ForeignKey("dbo.Profesors", t => t.Profesor_ProfesorId, cascadeDelete: true)
                .ForeignKey("dbo.Curs", t => t.Curs_CursId, cascadeDelete: true)
                .Index(t => t.Profesor_ProfesorId)
                .Index(t => t.Curs_CursId);
            
            CreateTable(
                "dbo.StudentCurs",
                c => new
                    {
                        Student_StudentId = c.Guid(nullable: false),
                        Curs_CursId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_StudentId, t.Curs_CursId })
                .ForeignKey("dbo.Students", t => t.Student_StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Curs", t => t.Curs_CursId, cascadeDelete: true)
                .Index(t => t.Student_StudentId)
                .Index(t => t.Curs_CursId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notas", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Notas", "CursId", "dbo.Curs");
            DropForeignKey("dbo.StudentCurs", "Curs_CursId", "dbo.Curs");
            DropForeignKey("dbo.StudentCurs", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.ProfesorCurs", "Curs_CursId", "dbo.Curs");
            DropForeignKey("dbo.ProfesorCurs", "Profesor_ProfesorId", "dbo.Profesors");
            DropForeignKey("dbo.Notas", "CategorieId", "dbo.Categories");
            DropIndex("dbo.StudentCurs", new[] { "Curs_CursId" });
            DropIndex("dbo.StudentCurs", new[] { "Student_StudentId" });
            DropIndex("dbo.ProfesorCurs", new[] { "Curs_CursId" });
            DropIndex("dbo.ProfesorCurs", new[] { "Profesor_ProfesorId" });
            DropIndex("dbo.Notas", new[] { "CategorieId" });
            DropIndex("dbo.Notas", new[] { "StudentId" });
            DropIndex("dbo.Notas", new[] { "CursId" });
            DropTable("dbo.StudentCurs");
            DropTable("dbo.ProfesorCurs");
            DropTable("dbo.Students");
            DropTable("dbo.Profesors");
            DropTable("dbo.Curs");
            DropTable("dbo.Notas");
            DropTable("dbo.Categories");
        }
    }
}
