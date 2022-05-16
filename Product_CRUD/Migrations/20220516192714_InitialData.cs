using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Product_CRUD.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (short)1, "Drzewka owocowe" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (short)2, "Kwiaty" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { (short)3, "Nasiona warzyw" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("d61a7e77-5e74-4c2b-8c00-af3ddb381415"), (short)1, "Wiśnia", 45.7806m },
                    { new Guid("d8450d7f-4c25-4ada-87b6-4eeb70a96ca6"), (short)1, "Jabłoń", 16.6911m },
                    { new Guid("7d8af9fc-a577-4ffa-bed6-b0dbb53ea08c"), (short)1, "Śliwka", 43.3329m },
                    { new Guid("67f36f59-e8d8-41ed-923e-2e23f1ded25d"), (short)2, "Mak", 45.7806m },
                    { new Guid("f6877b87-e139-403d-948e-10031ed670ad"), (short)3, "Rzodkiewka", 8.8806m },
                    { new Guid("d7b52148-9fe0-4fb2-88d5-82e6212b0584"), (short)3, "Marchew", 1.5129m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: (short)3);
        }
    }
}
