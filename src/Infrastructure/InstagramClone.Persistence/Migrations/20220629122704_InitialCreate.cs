using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InstagramClone.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "follow",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowerCount = table.Column<int>(type: "int", nullable: false),
                    FollowedCount = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_follow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "post",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "profile",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Biography = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_post_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "like",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_like_post_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostPostImageFile",
                columns: table => new
                {
                    PostImageFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostPostImageFile", x => new { x.PostImageFilesId, x.PostsId });
                    table.ForeignKey(
                        name: "FK_PostPostImageFile_Files_PostImageFilesId",
                        column: x => x.PostImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostPostImageFile_post_PostsId",
                        column: x => x.PostsId,
                        principalSchema: "dbo",
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reply",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reply", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reply_post_PostId",
                        column: x => x.PostId,
                        principalSchema: "dbo",
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileProfileImageFile",
                columns: table => new
                {
                    ProfileImageFilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfilesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileProfileImageFile", x => new { x.ProfileImageFilesId, x.ProfilesId });
                    table.ForeignKey(
                        name: "FK_ProfileProfileImageFile_Files_ProfileImageFilesId",
                        column: x => x.ProfileImageFilesId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileProfileImageFile_profile_ProfilesId",
                        column: x => x.ProfilesId,
                        principalSchema: "dbo",
                        principalTable: "profile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_PostId",
                schema: "dbo",
                table: "comment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_like_PostId",
                schema: "dbo",
                table: "like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostPostImageFile_PostsId",
                table: "PostPostImageFile",
                column: "PostsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileProfileImageFile_ProfilesId",
                table: "ProfileProfileImageFile",
                column: "ProfilesId");

            migrationBuilder.CreateIndex(
                name: "IX_reply_PostId",
                schema: "dbo",
                table: "reply",
                column: "PostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "follow",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "like",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PostPostImageFile");

            migrationBuilder.DropTable(
                name: "ProfileProfileImageFile");

            migrationBuilder.DropTable(
                name: "reply",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "profile",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "post",
                schema: "dbo");
        }
    }
}
