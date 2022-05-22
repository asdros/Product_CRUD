using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Product_CRUD.Migrations
{
    public partial class IntegrationProductWithTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "NetPrice");

            migrationBuilder.AddColumn<string>(
                name: "DisplayValue",
                table: "Taxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TaxId",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Name", "NetPrice", "TaxId" },
                values: new object[,]
                {
                    { new Guid("24a60996-2b6c-446c-855f-2bf882cf52e4"), (short)1, "Wiśnia", 37.22m, (byte)4 },
                    { new Guid("d757b920-4105-489c-9d09-53cf55a0cff5"), (short)1, "Jabłoń", 13.57m, (byte)4 },
                    { new Guid("c84e03b1-f997-4693-83c3-99935cd96df2"), (short)3, "Rzodkiewka", 7.22m, (byte)4 },
                    { new Guid("0776955f-87b7-46f8-838a-f8d61cc2d343"), (short)3, "Marchew", 1.23m, (byte)4 },
                    { new Guid("360940e7-aafc-4f27-9984-1b136c9fa016"), (short)2, "Mak", 37.22m, (byte)4 },
                    { new Guid("19ff2003-0eb9-48d7-a248-95920b8f63c6"), (short)1, "Śliwka", 35.23m, (byte)4 }
                });

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: (byte)1,
                column: "DisplayValue",
                value: "23%");

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: (byte)2,
                column: "DisplayValue",
                value: "8%");

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: (byte)3,
                column: "DisplayValue",
                value: "5%");

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxId",
                keyValue: (byte)4,
                column: "DisplayValue",
                value: "0%");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TaxId",
                table: "Products",
                column: "TaxId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Taxes_TaxId",
                table: "Products",
                column: "TaxId",
                principalTable: "Taxes",
                principalColumn: "TaxId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Taxes_TaxId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_TaxId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("0776955f-87b7-46f8-838a-f8d61cc2d343"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("19ff2003-0eb9-48d7-a248-95920b8f63c6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("24a60996-2b6c-446c-855f-2bf882cf52e4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("360940e7-aafc-4f27-9984-1b136c9fa016"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("c84e03b1-f997-4693-83c3-99935cd96df2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: new Guid("d757b920-4105-489c-9d09-53cf55a0cff5"));

            migrationBuilder.DropColumn(
                name: "DisplayValue",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "NetPrice",
                table: "Products",
                newName: "Price");

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
        }
    }
}
