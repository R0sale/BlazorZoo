using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addedphinenumberandaddresstouser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "52df3dcf-3a4a-4f4b-b1c0-2f4c00caf4de");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "99029d4a-874e-43d1-9117-41fddb992283");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address_City", "Address_Country", "Address_PostalCode", "Address_State", "Address_Street", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "PhoneNumber", "Username" },
                values: new object[] { "b8dd6cb1-d02c-440d-828b-3056017e4390", "Minsk", "Belarus", "222435", "No state", "Kastrychnickaya", "email@mail.ru", "John", "/koala.webp", "Black", "System.Byte[]", "+375299998493", "JoeBlack" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "PhoneNumber", "Username" },
                values: new object[] { "cd244cd6-239f-49c7-9532-7dbd95e4a156", "myEmail@mail.ru", "Kirill", "/koala.webp", "Bush", "System.Byte[]", "+375299998493", "Baiden" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "b8dd6cb1-d02c-440d-828b-3056017e4390");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "cd244cd6-239f-49c7-9532-7dbd95e4a156");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { "52df3dcf-3a4a-4f4b-b1c0-2f4c00caf4de", "myEmail@mail.ru", "Kirill", "/koala.webp", "Bush", "System.Byte[]", "Baiden" },
                    { "99029d4a-874e-43d1-9117-41fddb992283", "email@mail.ru", "John", "/koala.webp", "Black", "System.Byte[]", "JoeBlack" }
                });
        }
    }
}
