using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    public partial class baza2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorFullname", "BookCount", "CategoryId", "CreatedOn", "Isbn", "PageCount", "PublishDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("583c89ce-688c-4fec-8846-dcc2a62be7b4"), "Nota Duck, PH.D.", 1, new Guid("a9e344f0-9275-43c9-a2d2-06c30c47e318"), new DateTime(2023, 12, 7, 1, 13, 31, 617, DateTimeKind.Local).AddTicks(2341), "7777777777777", 50000, new DateTime(2007, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Quack Quack" },
                    { new Guid("7860e1fa-d69c-4471-909d-575895caa888"), "Iaman Alien", 5, new Guid("2b64b94c-ab89-49cb-8a6c-2fd7f577b510"), new DateTime(2023, 12, 7, 1, 13, 32, 617, DateTimeKind.Local).AddTicks(2291), "4685948576945", 300, new DateTime(2022, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Aliens" },
                    { new Guid("7c4ab0d3-9fee-4b22-bce3-419b2607ce10"), "Dog", 7, new Guid("88c25e8f-70b6-46fc-9f94-7bfbcb671bd3"), new DateTime(2023, 12, 7, 1, 13, 33, 617, DateTimeKind.Local).AddTicks(2267), "7615948576945", 235, new DateTime(2015, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Dog vs Human" },
                    { new Guid("b06036c4-5320-4263-926d-86b537a32386"), "Król Edward", 0, new Guid("ee8d72c8-13b0-4d49-8a97-4d9e62920fa4"), new DateTime(2023, 12, 7, 1, 13, 34, 617, DateTimeKind.Local).AddTicks(2239), "7685948556945", 200, new DateTime(2009, 9, 9, 1, 1, 1, 0, DateTimeKind.Unspecified), 0, "Im The Best" },
                    { new Guid("b2c0a923-fee6-468b-a1fa-3ae5a563460a"), "Dr. Akula", 5, new Guid("2b64b94c-ab89-49cb-8a6c-2fd7f577b510"), new DateTime(2023, 12, 7, 1, 13, 35, 617, DateTimeKind.Local).AddTicks(2144), "7685948576945", 300, new DateTime(2007, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "Drakoola" },
                    { new Guid("fa846053-4113-4e50-93c4-d91fa64fb845"), "Adolfo Hilter", 2, new Guid("dde93c20-6ff3-448c-ba62-90ee8c235cfd"), new DateTime(2023, 12, 7, 1, 13, 36, 617, DateTimeKind.Local).AddTicks(2315), "7685948576945", 1200, new DateTime(1949, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "A Very Argentine Mustachy Artist" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "46c16260-3e9a-490e-b1fa-b9adc40a482c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5bf1cf7c-e156-4696-81fc-4fed8e19e710");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a41d6452-3896-4c04-93d2-3ec249e69895");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("583c89ce-688c-4fec-8846-dcc2a62be7b4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("7860e1fa-d69c-4471-909d-575895caa888"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("7c4ab0d3-9fee-4b22-bce3-419b2607ce10"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b06036c4-5320-4263-926d-86b537a32386"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("b2c0a923-fee6-468b-a1fa-3ae5a563460a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: new Guid("fa846053-4113-4e50-93c4-d91fa64fb845"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("0e3e02b1-a767-49ae-bc81-3d68ef98e8b9"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("210bfd87-4651-4257-96ab-2877e5052d21"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("2cb154d4-0275-470c-8907-4cbcee29ec92"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("70023a37-4ac7-4bb7-a966-6b838b0f2a60"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("a953284c-6f77-4d2f-a7bb-88d66a705006"));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "Status", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4287dad2-cde9-4492-9b3a-a924681f110e", 0, "440a1a50-be5d-40fc-be57-127745aa61a7", "damian@wp.pl", true, "Damian", "Maksimowicz", false, null, "DAMIAN@WP.PL", "DAMIAN@WP.PL", "AQAAAAEAACcQAAAAEAPFpn/1uUpT0QFdFL/qlGibPAaDVBHlVwFabD4nyNBTXHEZy3YODGJT8hWzqxNWPw==", null, false, 2, "a470071f-8e33-4dc3-bda7-b4298611b950", 1, false, "damian@wp.pl" },
                    { "7b778885-8351-442b-8703-7cc5216b6d8d", 0, "7beedb45-0751-40c6-b40e-6b6771f7648b", "gosc@wp.pl", true, "Gosc", "Gosc", false, null, "GOSC@WP.PL", "GOSC@WP.PL", "AQAAAAEAACcQAAAAEOKz9+YZhWyFz+Wd+u3JxrYIY9Cvra86Dk2HZvbzR82mlBlhB0jSH8MOPxd50WrPow==", null, false, 0, "b130cdef-8105-4b3a-9b71-4683b45726f2", 1, false, "gosc@wp.pl" },
                    { "f8616e81-ff01-40bf-adb6-844c978cbf9d", 0, "f093077b-f7c4-4f7a-a66c-9dd09f437ed6", "pracownik@wp.pl", true, "Pracownik", "Pracownik", false, null, "PRACOWNIK@WP.PL", "PRACOWNIK@WP.PL", "AQAAAAEAACcQAAAAEBZpVj8aLh+gzjVZfC5IqWFS5pchfqObAm68JhCVoFX3TykIK3EBY1q6od8ucXgUcw==", null, false, 1, "c48d5c7d-cd66-4cfd-b115-013ea5d4331d", 1, false, "pracownik@wp.pl" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { new Guid("2b64b94c-ab89-49cb-8a6c-2fd7f577b510"), "Horror" },
                    { new Guid("88c25e8f-70b6-46fc-9f94-7bfbcb671bd3"), "Romans" },
                    { new Guid("a9e344f0-9275-43c9-a2d2-06c30c47e318"), "Kryminalna" },
                    { new Guid("dde93c20-6ff3-448c-ba62-90ee8c235cfd"), "Science-Fiction" },
                    { new Guid("ee8d72c8-13b0-4d49-8a97-4d9e62920fa4"), "Thriller" }
                });
        }
    }
}
