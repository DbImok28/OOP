using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab11.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CHATS",
                columns: table => new
                {
                    CHAT_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CHAT_ID_PK", x => x.CHAT_ID);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
                columns: table => new
                {
                    USER_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    LOGIN = table.Column<string>(unicode: false, maxLength: 32, nullable: false),
                    PASSWORD_HASH = table.Column<byte[]>(maxLength: 20, nullable: false),
                    PHOTO = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("USER_ID_PK", x => x.USER_ID);
                });

            migrationBuilder.CreateTable(
                name: "CHAT_MESSAGES",
                columns: table => new
                {
                    CHAT_MESSAGES_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CHAT_ID = table.Column<int>(nullable: false),
                    USER_ID = table.Column<int>(nullable: false),
                    MESSAGE_TEXT = table.Column<string>(maxLength: 128, nullable: false),
                    SEND_DATE = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CHAT_MESSAGES", x => x.CHAT_MESSAGES_ID);
                    table.ForeignKey(
                        name: "CHAT_MESSAGES_CHAT_ID_FK",
                        column: x => x.CHAT_ID,
                        principalTable: "CHATS",
                        principalColumn: "CHAT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CHAT_MESSAGES_USER_ID_FK",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CHAT_USER",
                columns: table => new
                {
                    CHAT_ID = table.Column<int>(nullable: false),
                    USER_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CHAT_USER_PK", x => new { x.CHAT_ID, x.USER_ID });
                    table.ForeignKey(
                        name: "CHAT_USER_USER_FK",
                        column: x => x.CHAT_ID,
                        principalTable: "CHATS",
                        principalColumn: "CHAT_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "CHAT_USER_CHAT_FK",
                        column: x => x.USER_ID,
                        principalTable: "USERS",
                        principalColumn: "USER_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_MESSAGES_CHAT_ID",
                table: "CHAT_MESSAGES",
                column: "CHAT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_MESSAGES_USER_ID",
                table: "CHAT_MESSAGES",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CHAT_USER_USER_ID",
                table: "CHAT_USER",
                column: "USER_ID");

            migrationBuilder.CreateIndex(
                name: "LOGIN_UN",
                table: "USERS",
                column: "LOGIN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CHAT_MESSAGES");

            migrationBuilder.DropTable(
                name: "CHAT_USER");

            migrationBuilder.DropTable(
                name: "CHATS");

            migrationBuilder.DropTable(
                name: "USERS");
        }
    }
}
