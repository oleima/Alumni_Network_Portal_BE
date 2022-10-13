using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alumni_Network_Portal_BE.Migrations
{
    public partial class init : Migration
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
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "GroupMember",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GroupMember_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe_Topic",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe_Topic", x => new { x.TopicId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Subscribe_Topic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscribe_Topic_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Group",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Group", x => new { x.GroupId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Event_Group_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Group_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event_Topic",
                columns: table => new
                {
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Topic", x => new { x.TopicId, x.EventId });
                    table.ForeignKey(
                        name: "FK_Event_Topic_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Topic_Topics_TopicId",
                        column: x => x.TopicId,
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
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, true, null, "Get your cowboy boots on and bourbon ready", new DateTime(2023, 7, 5, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4541), "Party in the USA", new DateTime(2023, 7, 4, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, null, "The Noroff course presentation of the case project", new DateTime(2023, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4555), "Project Presentation", new DateTime(2023, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, null, "Get your socks on and rock on! The case period is over and we need to forget everything we have learned", new DateTime(2023, 10, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4560), "After Work Beer", new DateTime(2023, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified) }
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
                columns: new[] { "Id", "Body", "Title" },
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
                    { 2, "Likes backend and peaches", "None", "7ccf5453-c488-43f3-b7eb-587d8e44054b", null, "Online", "olem" },
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
                table: "Event_Group",
                columns: new[] { "EventId", "GroupId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Event_Topic",
                columns: new[] { "EventId", "TopicId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupMember",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, 1, "I love peaches", null, 1, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4226), null, null, "Fun fact", null },
                    { 2, 2, "I love beaches", null, 2, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4275), null, null, "Fun fact", null },
                    { 3, 3, "I love leaches", null, 3, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4279), null, null, "Fun fact", null },
                    { 4, 4, "I love breaches", null, 4, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4283), null, null, "Fun fact", null },
                    { 5, 1, "I love peaches", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4287), null, null, "Fun fact", 1 },
                    { 6, 2, "I love beaches", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4295), null, null, "Fun fact", 2 },
                    { 7, 3, "I love leaches", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4298), null, null, "Fun fact", 3 },
                    { 8, 4, "I love breaches", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4302), null, null, "Fun fact", 4 },
                    { 9, 1, "From fred to olem", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4307), null, 2, "Message", null },
                    { 10, 2, "From olem to fred", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4442), null, 1, "Message", null },
                    { 11, 3, "From solo to johnny", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4448), null, 4, "Message", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[] { 12, 4, "From johnny to solo", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4452), null, 3, "Message", null });

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

            migrationBuilder.InsertData(
                table: "Subscribe_Topic",
                columns: new[] { "TopicId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[] { 13, 2, "Child", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4456), 6, null, "Message", null });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[] { 14, 2, "Child of child", null, null, new DateTime(2022, 10, 13, 12, 37, 48, 408, DateTimeKind.Local).AddTicks(4460), 13, null, "Message", null });

            migrationBuilder.CreateIndex(
                name: "IX_Event_Group_EventId",
                table: "Event_Group",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_Topic_EventId",
                table: "Event_Topic",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_AuthorId",
                table: "Events",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserInvitation_UserId",
                table: "EventUserInvitation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_UserId",
                table: "GroupMember",
                column: "UserId");

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
                name: "IX_Subscribe_Topic_UserId",
                table: "Subscribe_Topic",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event_Group");

            migrationBuilder.DropTable(
                name: "Event_Topic");

            migrationBuilder.DropTable(
                name: "EventUserInvitation");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "RSVP");

            migrationBuilder.DropTable(
                name: "Subscribe_Topic");

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
