// using System;
// using Microsoft.EntityFrameworkCore.Migrations;

// #nullable disable

// namespace Taskforce.Db.Migrations
// {
//     /// <inheritdoc />
//     public partial class Init : Migration
//     {
//         /// <inheritdoc />
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.CreateTable(
//                 name: "Events",
//                 columns: table => new
//                 {
//                     Id = table.Column<Guid>(type: "uuid", nullable: false),
//                     IsTemplate = table.Column<bool>(type: "boolean", nullable: false),
//                     Title = table.Column<string>(type: "text", nullable: true),
//                     Type = table.Column<string>(type: "text", nullable: true),
//                     Description = table.Column<string>(type: "text", nullable: true),
//                     StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
//                     EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
//                     CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
//                     UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
//                     DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Events", x => x.Id);
//                 });

//             migrationBuilder.CreateTable(
//                 name: "Tickets",
//                 columns: table => new
//                 {
//                     Id = table.Column<Guid>(type: "uuid", nullable: false),
//                     IsTemplate = table.Column<bool>(type: "boolean", nullable: false),
//                     Title = table.Column<string>(type: "text", nullable: true),
//                     Description = table.Column<string>(type: "text", nullable: true),
//                     State = table.Column<string>(type: "text", nullable: true),
//                     Discriminator = table.Column<string>(type: "text", nullable: false),
//                     DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
//                     CompletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
//                     CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
//                     UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
//                     DeletedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Tickets", x => x.Id);
//                 });
//         }

//         /// <inheritdoc />
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "Events");

//             migrationBuilder.DropTable(
//                 name: "Tickets");
//         }
//     }
// }
