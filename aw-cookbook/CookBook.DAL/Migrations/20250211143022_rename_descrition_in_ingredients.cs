using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookBook.DAL.Migrations
{
    /// <inheritdoc />
    public partial class rename_descrition_in_ingredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decriptor",
                table: "Ingredients",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Ingredients",
                newName: "Decriptor");
        }
    }
}
