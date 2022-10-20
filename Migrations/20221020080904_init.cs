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
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(525)", maxLength: 525, nullable: true),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                table: "Groups",
                columns: new[] { "Id", "Body", "IsPrivate", "Title" },
                values: new object[,]
                {
                    { 1, "We learn about C#", false, "C# learning group" },
                    { 2, "The Noroff group", false, "Noroff" },
                    { 3, "For members of Experis", true, "Experis Academy" },
                    { 4, "Anyone can be part of this group", false, "Group for everyone" },
                    { 5, "Discuss and compete in Experis' own Fantasy Premier League", true, "Fantasy Premier League Experis" },
                    { 6, "Group to coordinate bouldering events", false, "Bouldering in Bergen" },
                    { 7, "Is Kai'sa letting you down lately? Join this group learn why you should play Ezreal", false, "League of Legends gaming group" },
                    { 8, "How tall is Mt Everest? How deep is the Mariana Trench? If you know these answers join Quizzy McQuizface for a good time", true, "Freddy and the Quizzy McQuizface" },
                    { 9, "We got the ingredients, the equipment, and the knowledge. You got the palate for high quality homebrewed Ipa. So HOP along and join our quest for the cleanest belgian triple.", false, "VestBrygg Bergen Homebrewing AS" },
                    { 10, "Do you smell of yarn and listening to podcasts while knitting away. This is place for you to get the best deals on habidasheries.", false, "Bergen Husflid" }
                });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "Id", "Body", "Title" },
                values: new object[,]
                {
                    { 1, "Discussion of the latest news around the world", "Worldnews" },
                    { 2, "Discuss anything that is related to fun things! Got a good joke? Maybe a banger meme? Post it here!", "Fun" },
                    { 3, "We talk about anything related to animals", "Animals" },
                    { 4, "Food talk, recipes and anything that involves food", "Food" },
                    { 5, "The hottest trends in the world of headwear", "Caps and Hats" },
                    { 6, "Do you have Red Flags? Do you Rage Against The Machine? Are you a Basket Case? Discuss it with us here", "Punk Music" },
                    { 7, "Java means coffee. Anyone who thinks otherwise is a disillusioned fool. Hot steamed and smoke roast", "Java Beans" },
                    { 8, "Should the Bybana go above Bryggen. Under? Get the latest Bergen news here", "Bergen Politics" },
                    { 9, "It is only 7 months until Eurovision 2023 in Liverpool. Get the latest news and discuss them here as the national entries are annouced", "Eurovision Song Contest" },
                    { 10, "What is he difference between C and C++? One", "Programmer Memes" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "FunFact", "KeycloakId", "Picture", "Status", "Username" },
                values: new object[,]
                {
                    { 1, "Likes french culture", "None", "4f1bd04c-7e5a-406f-952d-756ed92933bc", null, "Online", "fred" },
                    { 2, "Likes backend and peaches", "None", "7ccf5453-c488-43f3-b7eb-587d8e44054b", null, "Online", "olem" },
                    { 3, "Fan of sodas", "None", "a23f6e10-697d-4f53-bd1d-f38157e3ef54", null, "Online", "solo" },
                    { 4, "Mr.Bean lover", "None", "14b7a32e-27a4-488b-89d4-e411bec2ba2f", null, "Online", "johnny" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AllowGuests", "AuthorId", "Description", "EndTime", "LastUpdated", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, true, 2, "Halloween? Hello Wine! Get ready for a spooky and fun night!", new DateTime(2022, 10, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8841), "Halloween Party", new DateTime(2022, 10, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, 2, "The Noroff course presentation of the case project", new DateTime(2022, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8846), "Project Presentation", new DateTime(2022, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, 2, "Get your socks on and rock on! The case period is over and we need to forget everything we have learned", new DateTime(2022, 10, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8849), "After Work Beer", new DateTime(2022, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, true, 2, "Come to Festplassen, Bergen to celebrate the best norwegian music!", new DateTime(2023, 7, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8851), "Vg Lista topp 20", new DateTime(2023, 7, 5, 19, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, true, 2, "Haaland won't stop scoring goals. Complain about at Fredrik's apartment", new DateTime(2022, 11, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8853), "Fantasy Permier League Weekly Recap", new DateTime(2022, 11, 1, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, true, 2, "Laksevåg has set new routes so we are going exploring!", new DateTime(2022, 11, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8861), "Bouldering in Laksevåg", new DateTime(2022, 11, 2, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, false, 2, "Today we are ranking up!", new DateTime(2022, 10, 28, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8863), "5 man queue", new DateTime(2022, 10, 28, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, false, 2, "Trivia, beer and atmosphere!", new DateTime(2022, 11, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8865), "Thursday Quiz at Finnegans", new DateTime(2022, 11, 3, 17, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, true, 2, "VestBrygg is hosting a beginners course in brewing your own beer. ", new DateTime(2022, 10, 31, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8868), "Learn To brew your own beer!", new DateTime(2022, 10, 31, 18, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, true, 2, "Get together to share knitting recepies and inspire eachother. There will be tea and cookies ;)", new DateTime(2022, 10, 30, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8871), "Knitting and chatting", new DateTime(2022, 10, 30, 10, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "GroupMember",
                columns: new[] { "GroupId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 1 },
                    { 4, 2 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 6, 3 },
                    { 6, 4 },
                    { 7, 1 },
                    { 7, 3 },
                    { 8, 2 },
                    { 8, 3 },
                    { 9, 1 },
                    { 9, 3 },
                    { 9, 4 },
                    { 10, 3 },
                    { 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 1, 1, "CSharp variables needs to be delcared do to it being a strongly typed language. boolean: true or false, char: single character, int: whole number, float: floating point number, double, like float but more accurate, long: like int but bigger, decimal: monetary values.", null, 1, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8414), null, null, "Know your variables", null },
                    { 2, 1, "int [] ages = new int[8] is the declaration for integer array of set length 8. Remember they are zero indexed! Access the second element like this: ages[1].", null, 1, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8445), null, null, "Know your arrays", null },
                    { 3, 1, "Dictionary<int,string> dictionaryOfWords = new Dictionary<int,string>(); is the declaration of key type integer and value type string. It is of dynamic length. add like this: dictionaryOfWords.Add(423, \"First word\"); and access like this dictionaryOfWords(423).", null, 1, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8447), null, null, "Know your dictionaries", null },
                    { 4, 1, "A class is made of four components. Constructors, fields, bahaviours and properties", null, 1, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8449), null, null, "Know your Class", null },
                    { 5, 2, "The Firealarm might go off today due to technical issues", null, 2, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8451), null, null, "Firealarm might go off today!", null },
                    { 6, 2, "Monday: Bean Shepards Pie, Tuesday: Baked Cod, Wednesday: Chickpea Masala, Thursday: Lentils Lansagna, Friday: Loaded Veggie Taco", null, 2, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8454), null, null, "Weekly menu in the cafeteria", null },
                    { 7, 2, "I have been trying to get enpoints to work, but they just wont work!", null, 3, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8456), null, null, "Anyone know how endpoints work?", null },
                    { 10, 1, "If anyone is interested, just ask me", null, 3, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8464), null, null, "I figured out how to get figma to work", null },
                    { 12, 1, "Save electricity in these dark times", null, 3, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8471), null, null, "Remember to turn off the lights when leaving the offices", null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 14, 1, "Use it for all your social media needs!", null, 4, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8475), null, null, "Alumni Network is the best app out there!", null },
                    { 15, 2, "The change we need in social media", null, 4, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8482), null, null, "Thank you for using Almuni Network!", null },
                    { 16, 3, "The man keeps assisting and scoring points, hes def worth the high price", null, 5, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8484), null, null, "I decided to add Kevin De Bruyne", null },
                    { 17, 4, "Arsenal definitely seems to have turned things around this season", null, 5, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8486), null, null, "Is Arteta the must-have-coach", null },
                    { 21, 4, "Holy guacamoly, I ahave never had so many points in a round before!", null, 5, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8495), null, null, "This round scored me so many points!", null },
                    { 22, 4, "I was so stressed, when I heard the rumors", null, 5, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8497), null, null, "Praise the Lord, Allahu Ackbar, and Barukh Hashem! Haaland is not injured!", null },
                    { 23, 4, "So crazy that guy", null, 6, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8499), null, null, "Did you guys see Magnus midtbø's newest video?", null },
                    { 24, 3, "I heard they will have 700 meters of climbing!", null, 6, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8501), null, null, "I am so looking forward to the new bouldering hall in Åsane!", null },
                    { 25, 1, "I have no idea how it is the most popular character!", null, 7, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8503), null, null, "Kai'sa is so overrated", null },
                    { 26, 1, "It always delivers in creating a balanced game!", null, 7, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8505), null, null, "ARAM is the best gamemode", null },
                    { 27, 1, "I want to watch this years worlds", null, 7, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8507), null, null, "When is Worlds?", null },
                    { 30, 1, "Mine is Lee Sin", null, 7, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8513), null, null, "What is your favourite character?", null },
                    { 32, 3, "I just get rekt :( ", null, 7, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8517), null, null, "I don't want to play toplane anymore!", null },
                    { 33, 2, "I know all the capitals of European and American countries", null, 8, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8520), null, null, "I have read up on geography", null },
                    { 34, 2, "I feel this is the subject we get the least points on", null, 8, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8574), null, null, "We need to get some knowledge on litterature", null },
                    { 36, 2, "Next time we will get them!", null, 8, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8580), null, null, "We are tied with Conquiztadores for second place overall", null },
                    { 38, 3, "Get your hops on now, all hops from the 2021 season is 20% off all week!", null, 9, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8583), null, null, "Cheap HOPS! 20% off all week!", null },
                    { 39, 3, "Tasty and aromatic, hints of chocolate and coffee. Beautiful mouthfeel!", null, 9, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8585), null, null, "Congratulations to Tom for brewing the best stout in our fall-brew-off!", null },
                    { 40, 3, "We have made a ten step guide to how to create the best NEIPA!", null, 9, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8588), null, null, "Keen on a proper New England IPA? Come by our store to get the best tips and tricks!", null },
                    { 41, 3, "Get them at our store, for favourable prices and good insight in yeast culture.", null, 9, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8590), null, null, "Use Norwegian yeast Kveik to brew your pale ales!", null },
                    { 42, 4, "Page 3 in the Husflid catalogue. How does that make sense?", null, 10, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8592), null, null, "Anyone understand this knitting recipe, and can help me out?", null },
                    { 44, 4, "Thinking something green", null, 10, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8596), null, null, "What are your favorite colors for winter gowns. I want to sow my own!", null },
                    { 46, 2, "The demonstrations erupted nearly a month ago over the death of 22-year-old Mahsa Amini in police custody", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8600), null, null, "Protests in Iran: 'The younger generation are starting a revolution'", 1 },
                    { 47, 2, "Prized for the lightweight, elastic bark, cork oaks can also store large amounts of carbon during their long lifetimes. Now there are moves to find new uses for this material.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8603), null, null, "Why cork is making a comeback", 1 },
                    { 48, 2, "England missed the chance to complete a series clean sweep over Australia when their third Twenty20 match in Canberra was abandoned because of rain.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8605), null, null, "England in Australia: Third Twenty20 abandoned because of rain in Canberra", 1 },
                    { 49, 2, "Between 1809 and 1814 the island became a prison for 11,000 defeated Napoleonic soldiers. Conditions were grim and up to 5,000 were estimated to have died of starvation, dehydration, and various illnesses.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8607), null, null, "Cabrera: The heavenly island that became hell on earth", 1 },
                    { 50, 2, "Kwasi Kwarteng - who is out of his job as the UK's chancellor - has just confirmed that he was sacked by Prime Minister Liz Truss rather than choosing to leave.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8609), null, null, "Kwarteng confirms he was asked to 'stand aside'", 1 },
                    { 51, 1, "The woman walks to the rear of the bus and sits down, fuming. She says to a man next to her: “The driver just insulted me!” The man says: “You go up there and tell him off. Go on, I’ll hold your monkey for you.”", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8611), null, null, "A woman gets on a bus with her baby. The bus driver says: 'Ugh, that’s the ugliest baby I’ve ever seen!'", 2 },
                    { 53, 1, "He said, 'How flexible are you?' I said, 'I can’t make Tuesdays.'", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8615), null, null, "I said to the Gym instructor 'Can you teach me to do the splits?'", 2 },
                    { 55, 1, "They charged one – and let the other one off.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8620), null, null, "Police arrested two kids yesterday, one was drinking battery acid, the other was eating fireworks.", 2 },
                    { 57, 1, "I’ve lost three days already.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8624), null, null, "I’m on a whiskey diet.", 2 },
                    { 59, 1, "Isn't that just amazing!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8628), null, null, "Fun fact: Fleas can jump 350 times its body length.", 3 },
                    { 60, 2, "Isn't that just amazing!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8633), null, null, "Fun fact: Hummingbirds are the only birds that can fly backwards.", 3 },
                    { 61, 1, "Isn't that just amazing!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8635), null, null, "Fun fact: Crocodiles cannot stick their tongue out.", 3 },
                    { 62, 2, "Isn't that just amazing!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8637), null, null, "Fun fact: Starfish do not have a brain.", 3 },
                    { 63, 2, "https://www.bbcgoodfood.com/recipes/caponata-pasta", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8639), null, null, "Recipe: Simple Pasta", 4 },
                    { 64, 2, "https://www.bbcgoodfood.com/recipes/coconut-squash-dhansak", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8641), null, null, "Recipe: Coconut & squash dhansak", 4 },
                    { 65, 2, "https://www.bbcgoodfood.com/recipes/veggie-fajitas", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8643), null, null, "Recipe: Veggie Fajitas", 4 },
                    { 66, 2, "Brown wool caps are hot in every sense of the word", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8646), null, null, "Top ten hottest caps right now!", 5 },
                    { 67, 3, "I want to find a nice fall cap!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8648), null, null, "Anyone now any good places to get caps?", 5 },
                    { 69, 2, "Such a cool song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8652), null, null, "I Wanna Be Your Dog – The Stooges", 6 },
                    { 71, 1, "Proper banger!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8656), null, null, "Anarchy in the UK – Sex Pistols", 6 }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 73, 2, "Such a cool song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8660), null, null, "Self Esteem – The Offspring", 6 },
                    { 75, 2, "Such a cool song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8664), null, null, "American Idiot – Green Day", 6 },
                    { 77, 2, "Personally I like pour over best, but what do you guys like?", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8726), null, null, "Pour over or french press?", 7 },
                    { 79, 1, "My Moccamaster makes just as good cooffee as any other fancy coffee bars", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8730), null, null, "Is barrista coffee overrated?", 7 },
                    { 80, 2, "Arabica has been the most famous for a long time, but I like RObusta myself.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8732), null, null, "What are the best beans? Arabica or Robusta", 7 },
                    { 82, 2, "I think they would look nice!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8736), null, null, "Should we allow for skyscrapers in Bergen", 8 },
                    { 83, 2, "We want Bergen to become the first European city to be properly car free!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8738), null, null, "Car free Bergen!", 8 },
                    { 84, 4, "People don't know what they talk about. Me neither, to be fair.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8740), null, null, "Bergen politics is bad!", 8 },
                    { 85, 4, "I was so upset when he didn't win!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8742), null, null, "Spaceman is the best song!", 9 },
                    { 86, 3, "I hope GB will deliver in their hosting!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8744), null, null, "I am so looking forward to next years ESC!", 9 },
                    { 87, 1, "As Ukraine has been attacked by Russia and is not a safe place currently, it has to be hosted in the UK", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8746), null, null, "It has been decided that UK will host the ESC 2023", 9 },
                    { 88, 1, "The second byte replies, 'No, just feeling a bit off.'", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8748), null, null, "Two bytes meet.  The first byte asks, 'Are you ill?'", 10 },
                    { 90, 1, "'Yeah,' reply the bytes.  'Make us a double.'", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8752), null, null, "Eight bytes walk into a bar.  The bartender asks, 'Can I get you anything?'", 10 },
                    { 91, 1, "He read the shampoo bottle instructions: Lather. Rinse. Repeat.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8754), null, null, "How did the programmer die in the shower?", 10 }
                });

            migrationBuilder.InsertData(
                table: "Subscribe_Topic",
                columns: new[] { "TopicId", "UserId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 2 },
                    { 3, 1 },
                    { 3, 2 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 6, 1 },
                    { 6, 2 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 4 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 9, 1 },
                    { 9, 3 },
                    { 9, 4 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 }
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
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
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
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 8, 1, "Have you tried adding scoped of the services?", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8458), 7, null, null, null },
                    { 9, 3, "Checkout the noroff page to see how to correctly set up controller and services", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8460), 7, null, null, null },
                    { 11, 1, "Figma balls", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8469), 10, null, null, null },
                    { 13, 2, "They have automatic movement sensors, so theres no stress", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8473), 12, null, null, null },
                    { 18, 3, "Cheaper than Pep and gets as many points, but doubt he can keep it up through this season", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8489), 17, null, null, null },
                    { 19, 2, "I have him on my team, but after the world cup i might change it to Klopp. He'll have a hell of a second half of the season.", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8491), 17, null, null, null },
                    { 20, 3, "I have Mancini, fml", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8493), 17, null, null, null },
                    { 28, 3, "It has already been, i am sorry", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8509), 27, null, null, null },
                    { 29, 3, "Maybe you can watch the replays on youtube", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8511), 27, null, null, null },
                    { 35, 3, "I mean, it is the most boring subject of all", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8577), 34, null, null, null },
                    { 37, 3, "Heck yeah we will!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8582), 36, null, null, null },
                    { 43, 3, "3x4 =12 and increase by one each round for 8 rounds to get 20. I think..", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8594), 42, null, null, null },
                    { 45, 3, "The darker themes of SelfMade are astonishing!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8599), 44, null, null, null },
                    { 52, 2, "Haha, great one!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8613), 51, null, null, null },
                    { 54, 2, "Haha, great one!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8618), 53, null, null, null },
                    { 56, 2, "Haha, great one!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8622), 55, null, null, null },
                    { 58, 2, "Haha, great one!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8626), 57, null, null, null },
                    { 68, 2, "Vanity has some nice ones", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8650), 67, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[,]
                {
                    { 70, 1, "I love this song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8654), 69, null, null, null },
                    { 72, 2, "I love this song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8658), 71, null, null, null },
                    { 74, 1, "I love this song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8662), 73, null, null, null },
                    { 76, 1, "I love this song!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8666), 75, null, null, null },
                    { 78, 1, "I use french press myself, but in weekends I use a Bialetti!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8728), 77, null, null, null },
                    { 81, 1, "I like arabica myself!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8734), 80, null, null, null },
                    { 89, 2, "Haha, great one", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8750), 88, null, null, null },
                    { 92, 2, "Haha, great one", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8756), 91, null, null, null }
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

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "Body", "EventId", "GroupId", "LastUpdated", "ParentId", "RecieverId", "Title", "TopicId" },
                values: new object[] { 31, 3, "Mine is Teemo!", null, null, new DateTime(2022, 10, 20, 10, 9, 3, 877, DateTimeKind.Local).AddTicks(8515), 29, null, null, null });

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
