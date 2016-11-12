using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ConsoleLayer
{
    public partial class Migrare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descriere",
                table: "TestTable",
                nullable: true);
                        }
        /*
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn<string>(
                name:"Descriere",
                table:"TestTable");
        }
        */
    }
}
