using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaPractica.Server.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcatenateID",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ConcatenateName",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdType",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNumber",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcatenateID",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ConcatenateName",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IdType",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IdentificationNumber",
                table: "Person");
        }
    }
}
