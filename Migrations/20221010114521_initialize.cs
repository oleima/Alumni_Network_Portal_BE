using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni_Network_Portal_BE.Migrations
{
    public partial class initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeycloakId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FunFact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AllowGuests = table.Column<bool>(type: "bit", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupUser",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUser", x => new { x.GroupsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_GroupUser_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicUser",
                columns: table => new
                {
                    TopicsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicUser", x => new { x.TopicsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_TopicUser_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventGroup",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventGroup", x => new { x.EventsId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_EventGroup_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTopic",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    TopicsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTopic", x => new { x.EventsId, x.TopicsId });
                    table.ForeignKey(
                        name: "FK_EventTopic_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventTopic_Topics_TopicsId",
                        column: x => x.TopicsId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventUserInvitation",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUserInvitation", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_EventUserInvitation_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUserInvitation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    RecieverId = table.Column<int>(type: "int", nullable: true),
                    TopicId = table.Column<int>(type: "int", nullable: true),
                    GroupId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Posts_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Posts_Users_RecieverId",
                        column: x => x.RecieverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RSVP",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RSVP", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RSVP_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RSVP_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AllowGuests", "AuthorId", "Description", "EndTime", "LastUpdated", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, true, null, "Get your cowboy boots on and bourbon ready", new DateTime(2023, 7, 5, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 13, 45, 21, 24, DateTimeKind.Local).AddTicks(9076), "Party in the USA", new DateTime(2023, 7, 4, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, null, "The Noroff course presentation of the case project", new DateTime(2023, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 13, 45, 21, 24, DateTimeKind.Local).AddTicks(9123), "Project Presentation", new DateTime(2023, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, null, "Get your socks on and rock on! The case period is over and we need to forget everything we have learned", new DateTime(2023, 10, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 10, 13, 45, 21, 24, DateTimeKind.Local).AddTicks(9127), "After Work Beer", new DateTime(2023, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "Body", "IsPrivate", "Title" },
                values: new object[,]
                {
                    { 1, "The noroff group", false, "Noroff" },
                    { 2, "We learn about C#", false, "C# learning group" },
                    { 3, "For members of Experis", true, "Experis Academy" },
                    { 4, "Anyone can be part of this group", false, "Group for everyone" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Discussion of news", "News" },
                    { 2, "Discuss anything that is related to fun things!", "Fun" },
                    { 3, "We talk about anything related to animals", "Animals" },
                    { 4, "Food talk, recipes and anything that involves food", "Food" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "FunFact", "KeycloakId", "Picture", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "Likes football", "None", "4f1bd04c-7e5a-406f-952d-756ed92933bc", null, "Online", "fred" },
                    { 2, "Likes backend and peaches", "None", "14b7a32e-27a4-488b-89d4-e411bec2ba2f", null, "Online", "olem" },
                    { 3, "Fan of sodas", "None", "a23f6e10-697d-4f53-bd1d-f38157e3ef54", null, "Online", "solo" },
                    { 4, "Mr.Bean lover", "None", "14b7a32e-27a4-488b-89d4-e411bec2ba2f", null, "Online", "johnny" }
                });

            migrationBuilder.InsertData(
                table: "EventUserInvitation",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, 2, "I love peaches", null, 1, null, null, "Fun fact", null },
                    { 2, 2, "I love beaches", null, 1, null, null, "Fun fact", null },
                    { 3, 2, "I love leaches", null, 1, null, null, "Fun fact", null },
                    { 4, 2, "I love breaches", null, 1, null, null, "Fun fact", null }
                });

            migrationBuilder.InsertData(
                table: "RSVP",
                columns: new[] { "EventId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventGroup_GroupsId",
                table: "EventGroup",
                column: "GroupsId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AuthorId",
                table: "Events",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventTopic_TopicsId",
                table: "EventTopic",
                column: "TopicsId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserInvitation_UserId",
                table: "EventUserInvitation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUser_UsersId",
                table: "GroupUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_EventId",
                table: "Posts",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_GroupId",
                table: "Posts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ParentId",
                table: "Posts",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_RecieverId",
                table: "Posts",
                column: "RecieverId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_TopicId",
                table: "Posts",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_UserId",
                table: "RSVP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TopicUser_UsersId",
                table: "TopicUser",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGroup");

            migrationBuilder.DropTable(
                name: "EventTopic");

            migrationBuilder.DropTable(
                name: "EventUserInvitation");

            migrationBuilder.DropTable(
                name: "GroupUser");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "RSVP");

            migrationBuilder.DropTable(
                name: "TopicUser");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
