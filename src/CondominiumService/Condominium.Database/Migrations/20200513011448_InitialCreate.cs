using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Condominium.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Block = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "varchar(20)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dweller",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(40)", nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Telephone = table.Column<string>(type: "varchar(15)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(40)", nullable: true),
                    Email = table.Column<string>(type: "varchar(40)", nullable: true),
                    ApartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dweller", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dweller_Apartment_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "password", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Dweller_ApartmentId",
                table: "Dweller",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dweller");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Apartment");
        }
    }
}
