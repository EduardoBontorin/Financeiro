using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dima.Api.Migrations
{
    /// <inheritdoc />
    public partial class ajustadoTabelaCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Categoy_CategoryId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoy",
                table: "Categoy");

            migrationBuilder.RenameTable(
                name: "Categoy",
                newName: "Category");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Category_CategoryId",
                table: "Transaction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categoy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoy",
                table: "Categoy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Categoy_CategoryId",
                table: "Transaction",
                column: "CategoryId",
                principalTable: "Categoy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
