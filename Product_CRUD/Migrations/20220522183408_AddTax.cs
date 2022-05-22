﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Product_CRUD.Migrations
{
    public partial class AddTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("67f36f59-e8d8-41ed-923e-2e23f1ded25d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("7d8af9fc-a577-4ffa-bed6-b0dbb53ea08c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d61a7e77-5e74-4c2b-8c00-af3ddb381415"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d7b52148-9fe0-4fb2-88d5-82e6212b0584"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d8450d7f-4c25-4ada-87b6-4eeb70a96ca6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("f6877b87-e139-403d-948e-10031ed670ad"));

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    TaxId = table.Column<byte>(type: "tinyint", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.TaxId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("417597a7-369b-4456-9137-32cee1486003"), (short)1, "Wiśnia", 45.7806m },
                    { new Guid("117c5513-5181-4d1b-bc31-f21969075d9d"), (short)1, "Jabłoń", 16.6911m },
                    { new Guid("1b2f4fee-05da-4d4a-acb5-67f486001501"), (short)3, "Rzodkiewka", 8.8806m },
                    { new Guid("34010c87-c339-4f72-85e5-09382369b443"), (short)3, "Marchew", 1.5129m },
                    { new Guid("3a18b1d3-54c8-470f-b35d-9fcb73a3f296"), (short)2, "Mak", 45.7806m },
                    { new Guid("6dd95a03-6eb4-42e9-bd46-d4858dc55825"), (short)1, "Śliwka", 43.3329m }
                });

            migrationBuilder.InsertData(
                table: "Taxes",
                columns: new[] { "TaxId", "Value" },
                values: new object[,]
                {
                    { (byte)1, 1.23m },
                    { (byte)2, 1.08m },
                    { (byte)3, 1.05m },
                    { (byte)4, 1.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("117c5513-5181-4d1b-bc31-f21969075d9d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("1b2f4fee-05da-4d4a-acb5-67f486001501"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("34010c87-c339-4f72-85e5-09382369b443"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("3a18b1d3-54c8-470f-b35d-9fcb73a3f296"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("417597a7-369b-4456-9137-32cee1486003"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("6dd95a03-6eb4-42e9-bd46-d4858dc55825"));

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("d61a7e77-5e74-4c2b-8c00-af3ddb381415"), (short)1, "Wiśnia", 45.7806m },
                    { new Guid("d8450d7f-4c25-4ada-87b6-4eeb70a96ca6"), (short)1, "Jabłoń", 16.6911m },
                    { new Guid("f6877b87-e139-403d-948e-10031ed670ad"), (short)3, "Rzodkiewka", 8.8806m },
                    { new Guid("d7b52148-9fe0-4fb2-88d5-82e6212b0584"), (short)3, "Marchew", 1.5129m },
                    { new Guid("67f36f59-e8d8-41ed-923e-2e23f1ded25d"), (short)2, "Mak", 45.7806m },
                    { new Guid("7d8af9fc-a577-4ffa-bed6-b0dbb53ea08c"), (short)1, "Śliwka", 43.3329m }
                });
        }
    }
}
