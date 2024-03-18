using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataRepository.Migrations
{
    /// <inheritdoc />
    public partial class AddFKShoppingCartToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdShoppingCart",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdShoppingCart",
                table: "Items");
        }
    }
}
