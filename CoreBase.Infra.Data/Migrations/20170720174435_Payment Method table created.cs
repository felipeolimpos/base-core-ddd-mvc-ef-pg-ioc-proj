using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreBase.Infra.Data.Migrations
{
    public partial class PaymentMethodtablecreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodID",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_PaymentMethodID",
                table: "Products",
                column: "PaymentMethodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_PaymentMethods_PaymentMethodID",
                table: "Products",
                column: "PaymentMethodID",
                principalTable: "PaymentMethods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_PaymentMethods_PaymentMethodID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_Products_PaymentMethodID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaymentMethodID",
                table: "Products");
        }
    }
}
