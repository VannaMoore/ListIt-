using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDeleteBehaviorRestrictions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_ListItems_ParentItemId",
                table: "ListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItemTags_ListItems_ListItemId",
                table: "ListItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItemTags_Tags_TagId",
                table: "ListItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ListUsers_Lists_ListId",
                table: "ListUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_ListItems_ParentItemId",
                table: "ListItems",
                column: "ParentItemId",
                principalTable: "ListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItemTags_ListItems_ListItemId",
                table: "ListItemTags",
                column: "ListItemId",
                principalTable: "ListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItemTags_Tags_TagId",
                table: "ListItemTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListUsers_Lists_ListId",
                table: "ListUsers",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_ListItems_ParentItemId",
                table: "ListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItemTags_ListItems_ListItemId",
                table: "ListItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ListItemTags_Tags_TagId",
                table: "ListItemTags");

            migrationBuilder.DropForeignKey(
                name: "FK_ListUsers_Lists_ListId",
                table: "ListUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_ListItems_ParentItemId",
                table: "ListItems",
                column: "ParentItemId",
                principalTable: "ListItems",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ListItems_Lists_ListId",
                table: "ListItems",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItemTags_ListItems_ListItemId",
                table: "ListItemTags",
                column: "ListItemId",
                principalTable: "ListItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListItemTags_Tags_TagId",
                table: "ListItemTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListUsers_Lists_ListId",
                table: "ListUsers",
                column: "ListId",
                principalTable: "Lists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
