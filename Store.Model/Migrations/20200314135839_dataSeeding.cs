using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreEFtest.Model.Migrations
{
    public partial class dataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "store_id",
                schema: "sales",
                table: "orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                schema: "production",
                table: "brands",
                columns: new[] { "brand_id", "brand_name" },
                values: new object[,]
                {
                    { 1, "brand 1" },
                    { 2, "brand 2" }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { 1, "cat 1" },
                    { 2, "cat 2" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "customers",
                columns: new[] { "customer_id", "city", "email", "first_name", "last_name", "phone", "state", "street", "zip_code" },
                values: new object[,]
                {
                    { 1, "kh", "bla@bla.com", "Bob", "Blob", "0572", "KhObl", "Nauki 43a", "61111" },
                    { 2, "khar", "blabla@bla.com", "Bobik", "Blobik", "057", "KhO", "Nauki 43b", "61111" }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "stores",
                columns: new[] { "store_id", "city", "email", "store_name", "phone", "state", "street", "zip_codee" },
                values: new object[] { 1, "bla city", "store@mail.com", "The Store", "057", "KH", "bla bla street", "61" });

            migrationBuilder.InsertData(
                schema: "production",
                table: "products",
                columns: new[] { "product_id", "brand_id", "category_id", "model_year", "product_name", "list_price" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(1982, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "product 1", 1000000m },
                    { 2, 2, 2, new DateTime(2017, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "product 2", 1000000000m }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "staffs",
                columns: new[] { "staff_id", "email", "first_name", "active", "last_name", "manager_id", "phone", "store_id" },
                values: new object[,]
                {
                    { 1, "walk@com", "Walk", true, "Walker", null, "555", 1 },
                    { 2, "megan@com", "Megan", true, "Fox", 1, "777", 1 }
                });

            migrationBuilder.InsertData(
                schema: "production",
                table: "stocks",
                columns: new[] { "store_name", "product_name", "quantity" },
                values: new object[,]
                {
                    { 1, 1, 300 },
                    { 1, 2, 200 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "orders",
                columns: new[] { "order_id", "customer_id", "order_date", "order_status", "required_date", "shipped_date", "staff_id", "store_id" },
                values: new object[,]
                {
                    { 2, 1, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), 1, new DateTime(2020, 3, 17, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), 1, 1 },
                    { 1, 1, new DateTime(2020, 3, 14, 0, 0, 0, 0, DateTimeKind.Local), 0, new DateTime(2020, 3, 16, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 3, 15, 0, 0, 0, 0, DateTimeKind.Local), 2, 1 }
                });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "order_items",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "quantity" },
                values: new object[] { 2, 2, 30m, 200m, 17 });

            migrationBuilder.InsertData(
                schema: "sales",
                table: "order_items",
                columns: new[] { "order_id", "product_id", "discount", "list_price", "quantity" },
                values: new object[] { 1, 1, 20m, 100m, 7 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "store_name", "product_name" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "production",
                table: "stocks",
                keyColumns: new[] { "store_name", "product_name" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "order_id", "product_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "order_items",
                keyColumns: new[] { "order_id", "product_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "products",
                keyColumn: "product_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "orders",
                keyColumn: "order_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "brands",
                keyColumn: "brand_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "production",
                table: "categories",
                keyColumn: "category_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "customers",
                keyColumn: "customer_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "staffs",
                keyColumn: "staff_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "sales",
                table: "stores",
                keyColumn: "store_id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "store_id",
                schema: "sales",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
