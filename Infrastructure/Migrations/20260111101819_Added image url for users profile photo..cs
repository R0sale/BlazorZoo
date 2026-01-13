using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addedimageurlforusersprofilephoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "08647fef-c2dc-4c73-834f-c336c326d77b");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "d3dacbbb-14f9-4412-8bd5-de7b0543e194");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageUrl", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { "52df3dcf-3a4a-4f4b-b1c0-2f4c00caf4de", "myEmail@mail.ru", "Kirill", "/koala.webp", "Bush", "System.Byte[]", "Baiden" },
                    { "99029d4a-874e-43d1-9117-41fddb992283", "email@mail.ru", "John", "/koala.webp", "Black", "System.Byte[]", "JoeBlack" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "52df3dcf-3a4a-4f4b-b1c0-2f4c00caf4de");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "99029d4a-874e-43d1-9117-41fddb992283");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "Username" },
                values: new object[,]
                {
                    { "08647fef-c2dc-4c73-834f-c336c326d77b", "myEmail@mail.ru", "Kirill", "Bush", "System.Byte[]", "Baiden" },
                    { "d3dacbbb-14f9-4412-8bd5-de7b0543e194", "email@mail.ru", "John", "Black", "System.Byte[]", "JoeBlack" }
                });
        }
    }
}
