using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Grocery.EFDataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroceryList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(5, 2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    IdentityMemberId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberGroceryList",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: false),
                    GroceryListId = table.Column<Guid>(nullable: false),
                    Access = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberGroceryList", x => new { x.MemberId, x.GroceryListId });
                    table.ForeignKey(
                        name: "FK_MemberGroceryList_GroceryList_GroceryListId",
                        column: x => x.GroceryListId,
                        principalTable: "GroceryList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MemberGroceryList_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UnitType = table.Column<int>(nullable: false),
                    DefaultUnits = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    DefaultPrice = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    CreatorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Member_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroceryItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    GroceryListId = table.Column<Guid>(nullable: false),
                    Priority = table.Column<int>(nullable: false),
                    Progress = table.Column<int>(nullable: false),
                    Units = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5, 2)", nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    IsBooked = table.Column<bool>(nullable: false),
                    MemberId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroceryItem_GroceryList_GroceryListId",
                        column: x => x.GroceryListId,
                        principalTable: "GroceryList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroceryItem_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GroceryItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroceryItem_GroceryListId",
                table: "GroceryItem",
                column: "GroceryListId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryItem_Id",
                table: "GroceryItem",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroceryItem_MemberId",
                table: "GroceryItem",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryItem_ProductId",
                table: "GroceryItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GroceryList_Id",
                table: "GroceryList",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Member_Id",
                table: "Member",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroceryList_GroceryListId",
                table: "MemberGroceryList",
                column: "GroceryListId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberGroceryList_Id",
                table: "MemberGroceryList",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatorId",
                table: "Product",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                table: "Product",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroceryItem");

            migrationBuilder.DropTable(
                name: "MemberGroceryList");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "GroceryList");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
