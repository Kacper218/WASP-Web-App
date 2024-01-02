using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WASP_Web_App.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auth",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auth", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Group_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Group_ID);
                });

            migrationBuilder.CreateTable(
                name: "Keys",
                columns: table => new
                {
                    Key_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Room = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keys", x => x.Key_ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Users_Auth_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Auth",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Permission_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_ID = table.Column<int>(type: "integer", nullable: false),
                    Group_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Permission_ID);
                    table.ForeignKey(
                        name: "FK_Permissions_Auth_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Auth",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Permissions_Groups_Group_ID",
                        column: x => x.Group_ID,
                        principalTable: "Groups",
                        principalColumn: "Group_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupKeys",
                columns: table => new
                {
                    GroupKey_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key_ID = table.Column<int>(type: "integer", nullable: false),
                    Group_ID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupKeys", x => x.GroupKey_ID);
                    table.ForeignKey(
                        name: "FK_GroupKeys_Groups_Group_ID",
                        column: x => x.Group_ID,
                        principalTable: "Groups",
                        principalColumn: "Group_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupKeys_Keys_Key_ID",
                        column: x => x.Key_ID,
                        principalTable: "Keys",
                        principalColumn: "Key_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rent",
                columns: table => new
                {
                    Rent_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_ID = table.Column<int>(type: "integer", nullable: false),
                    Key_ID = table.Column<int>(type: "integer", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rent", x => x.Rent_ID);
                    table.ForeignKey(
                        name: "FK_Rent_Auth_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Auth",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rent_Keys_Key_ID",
                        column: x => x.Key_ID,
                        principalTable: "Keys",
                        principalColumn: "Key_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialPermissions",
                columns: table => new
                {
                    SpecialPermission_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    User_ID = table.Column<int>(type: "integer", nullable: false),
                    Key_ID = table.Column<int>(type: "integer", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPermissions", x => x.SpecialPermission_ID);
                    table.ForeignKey(
                        name: "FK_SpecialPermissions_Auth_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Auth",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecialPermissions_Keys_Key_ID",
                        column: x => x.Key_ID,
                        principalTable: "Keys",
                        principalColumn: "Key_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupKeys_Group_ID",
                table: "GroupKeys",
                column: "Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GroupKeys_Key_ID",
                table: "GroupKeys",
                column: "Key_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Group_ID",
                table: "Permissions",
                column: "Group_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_User_ID",
                table: "Permissions",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_Key_ID",
                table: "Rent",
                column: "Key_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Rent_User_ID",
                table: "Rent",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPermissions_Key_ID",
                table: "SpecialPermissions",
                column: "Key_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPermissions_User_ID",
                table: "SpecialPermissions",
                column: "User_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupKeys");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Rent");

            migrationBuilder.DropTable(
                name: "SpecialPermissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Keys");

            migrationBuilder.DropTable(
                name: "Auth");
        }
    }
}
