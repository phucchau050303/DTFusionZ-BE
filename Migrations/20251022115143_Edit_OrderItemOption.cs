using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTFusionZ_BE.Migrations
{
    /// <inheritdoc />
    public partial class Edit_OrderItemOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOptionGroup_Items_ItemId",
                table: "ItemOptionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOptionGroup_OptionGroups_OptionGroupId",
                table: "ItemOptionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemOption_OrderItem_OrderItemId",
                table: "OrderItemOption");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "OrderItemOption",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "OrderItemOption",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "OrderItemOption",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOptionGroup_Items_ItemId",
                table: "ItemOptionGroup",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOptionGroup_OptionGroups_OptionGroupId",
                table: "ItemOptionGroup",
                column: "OptionGroupId",
                principalTable: "OptionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemOption_OrderItem_OrderItemId",
                table: "OrderItemOption",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemOptionGroup_Items_ItemId",
                table: "ItemOptionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemOptionGroup_OptionGroups_OptionGroupId",
                table: "ItemOptionGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItemOption_OrderItem_OrderItemId",
                table: "OrderItemOption");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "OrderItemOption");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "OrderItemOption");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "OrderItemOption");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOptionGroup_Items_ItemId",
                table: "ItemOptionGroup",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemOptionGroup_OptionGroups_OptionGroupId",
                table: "ItemOptionGroup",
                column: "OptionGroupId",
                principalTable: "OptionGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Orders_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItemOption_OrderItem_OrderItemId",
                table: "OrderItemOption",
                column: "OrderItemId",
                principalTable: "OrderItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
