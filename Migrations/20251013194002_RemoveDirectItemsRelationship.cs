using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTFusionZ_BE.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDirectItemsRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_OptionGroups_OptionGroupId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_OptionGroupId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OptionGroupId",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "OptionGroupId1",
                table: "ItemOptionGroup",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemOptionGroup_OptionGroupId1",
                table: "ItemOptionGroup",
                column: "OptionGroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOptionGroup_OptionGroups_OptionGroupId1",
                table: "ItemOptionGroup",
                column: "OptionGroupId1",
                principalTable: "OptionGroups",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOptionGroup_OptionGroups_OptionGroupId1",
                table: "ItemOptionGroup");

            migrationBuilder.DropIndex(
                name: "IX_ItemOptionGroup_OptionGroupId1",
                table: "ItemOptionGroup");

            migrationBuilder.DropColumn(
                name: "OptionGroupId1",
                table: "ItemOptionGroup");

            migrationBuilder.AddColumn<int>(
                name: "OptionGroupId",
                table: "Items",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_OptionGroupId",
                table: "Items",
                column: "OptionGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_OptionGroups_OptionGroupId",
                table: "Items",
                column: "OptionGroupId",
                principalTable: "OptionGroups",
                principalColumn: "Id");
        }
    }
}
