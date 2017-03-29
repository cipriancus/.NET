namespace onlineGrades.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notas", "StudentId", "dbo.Students");
            DropForeignKey("dbo.ProfesorCurs", "Profesor_ProfesorId", "dbo.Profesors");
            DropForeignKey("dbo.StudentCurs", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Notas", new[] { "StudentId" });
            RenameColumn(table: "dbo.ProfesorCurs", name: "Profesor_ProfesorId", newName: "Profesor_userId");
            RenameColumn(table: "dbo.StudentCurs", name: "Student_StudentId", newName: "Student_userId");
            RenameIndex(table: "dbo.ProfesorCurs", name: "IX_Profesor_ProfesorId", newName: "IX_Profesor_userId");
            RenameIndex(table: "dbo.StudentCurs", name: "IX_Student_StudentId", newName: "IX_Student_userId");
            DropPrimaryKey("dbo.Profesors");
            DropPrimaryKey("dbo.Students");
            AddColumn("dbo.Notas", "Student_userId", c => c.Guid(nullable: false));
            AddColumn("dbo.Profesors", "userId", c => c.Guid(nullable: false));
            AddColumn("dbo.Students", "userId", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Profesors", "userId");
            AddPrimaryKey("dbo.Students", "userId");
            CreateIndex("dbo.Notas", "Student_userId");
            AddForeignKey("dbo.Notas", "Student_userId", "dbo.Students", "userId", cascadeDelete: true);
            AddForeignKey("dbo.ProfesorCurs", "Profesor_userId", "dbo.Profesors", "userId", cascadeDelete: true);
            AddForeignKey("dbo.StudentCurs", "Student_userId", "dbo.Students", "userId", cascadeDelete: true);
            DropColumn("dbo.Profesors", "ProfesorId");
            DropColumn("dbo.Students", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "StudentId", c => c.Guid(nullable: false));
            AddColumn("dbo.Profesors", "ProfesorId", c => c.Guid(nullable: false));
            DropForeignKey("dbo.StudentCurs", "Student_userId", "dbo.Students");
            DropForeignKey("dbo.ProfesorCurs", "Profesor_userId", "dbo.Profesors");
            DropForeignKey("dbo.Notas", "Student_userId", "dbo.Students");
            DropIndex("dbo.Notas", new[] { "Student_userId" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.Profesors");
            DropColumn("dbo.Students", "userId");
            DropColumn("dbo.Profesors", "userId");
            DropColumn("dbo.Notas", "Student_userId");
            AddPrimaryKey("dbo.Students", "StudentId");
            AddPrimaryKey("dbo.Profesors", "ProfesorId");
            RenameIndex(table: "dbo.StudentCurs", name: "IX_Student_userId", newName: "IX_Student_StudentId");
            RenameIndex(table: "dbo.ProfesorCurs", name: "IX_Profesor_userId", newName: "IX_Profesor_ProfesorId");
            RenameColumn(table: "dbo.StudentCurs", name: "Student_userId", newName: "Student_StudentId");
            RenameColumn(table: "dbo.ProfesorCurs", name: "Profesor_userId", newName: "Profesor_ProfesorId");
            CreateIndex("dbo.Notas", "StudentId");
            AddForeignKey("dbo.StudentCurs", "Student_StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
            AddForeignKey("dbo.ProfesorCurs", "Profesor_ProfesorId", "dbo.Profesors", "ProfesorId", cascadeDelete: true);
            AddForeignKey("dbo.Notas", "StudentId", "dbo.Students", "StudentId", cascadeDelete: true);
        }
    }
}
