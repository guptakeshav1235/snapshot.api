using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace snapShot.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("11093fed-ca90-4277-8789-5189e68630cb"), "Easy" },
                    { new Guid("726fad50-d3a6-44c7-a68e-f7b97eeece65"), "Medium" },
                    { new Guid("f0428b14-5737-4926-92cb-ed2a6b852aa9"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("0b102c44-c7b5-4bfb-bf7f-d046b2907f5f"), "NSN", "Nelson Region", null },
                    { new Guid("4147dfa0-c90b-4918-ab98-5c463eabb66e"), "WLG", "Wellington Region", "https://images.pexels.com/photos/8379417/pexels-photo-8379417.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { new Guid("68f40740-4eca-4a45-9154-1c55cefebcb8"), "AKL", "Auckland Region", "https://images.pexels.com/photos/5342974/pexels-photo-5342974.jpeg?auto=compress&cs=tinysrgb&w=600" },
                    { new Guid("e45935cc-ae2b-483b-bce3-6e95ff9c6077"), "STL", "Scotland Region", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("11093fed-ca90-4277-8789-5189e68630cb"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("726fad50-d3a6-44c7-a68e-f7b97eeece65"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f0428b14-5737-4926-92cb-ed2a6b852aa9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("0b102c44-c7b5-4bfb-bf7f-d046b2907f5f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("4147dfa0-c90b-4918-ab98-5c463eabb66e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("68f40740-4eca-4a45-9154-1c55cefebcb8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e45935cc-ae2b-483b-bce3-6e95ff9c6077"));
        }
    }
}
