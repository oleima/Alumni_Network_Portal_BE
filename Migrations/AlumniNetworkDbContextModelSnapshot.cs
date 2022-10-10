﻿// <auto-generated />
using System;
using Alumni_Network_Portal_BE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alumni_Network_Portal_BE.Migrations
{
    [DbContext(typeof(AlumniNetworkDbContext))]
    partial class AlumniNetworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("AllowGuests")
                        .HasColumnType("bit");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowGuests = true,
                            Description = "Get your cowboy boots on and bourbon ready",
                            EndTime = new DateTime(2023, 7, 5, 3, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2022, 10, 10, 13, 45, 21, 24, DateTimeKind.Local).AddTicks(9076),
                            Name = "Party in the USA",
                            StartTime = new DateTime(2023, 7, 4, 16, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            AllowGuests = true,
                            Description = "The Noroff course presentation of the case project",
                            EndTime = new DateTime(2023, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2022, 10, 10, 13, 45, 21, 24, DateTimeKind.Local).AddTicks(9123),
                            Name = "Project Presentation",
                            StartTime = new DateTime(2023, 10, 28, 12, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            AllowGuests = true,
                            Description = "Get your socks on and rock on! The case period is over and we need to forget everything we have learned",
                            EndTime = new DateTime(2023, 10, 28, 22, 0, 0, 0, DateTimeKind.Unspecified),
                            LastUpdated = new DateTime(2022, 10, 10, 13, 45, 21, 24, DateTimeKind.Local).AddTicks(9127),
                            Name = "After Work Beer",
                            StartTime = new DateTime(2023, 10, 28, 16, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsPrivate")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "The noroff group",
                            IsPrivate = false,
                            Title = "Noroff"
                        },
                        new
                        {
                            Id = 2,
                            Body = "We learn about C#",
                            IsPrivate = false,
                            Title = "C# learning group"
                        },
                        new
                        {
                            Id = 3,
                            Body = "For members of Experis",
                            IsPrivate = true,
                            Title = "Experis Academy"
                        },
                        new
                        {
                            Id = 4,
                            Body = "Anyone can be part of this group",
                            IsPrivate = false,
                            Title = "Group for everyone"
                        });
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int?>("RecieverId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("EventId");

                    b.HasIndex("GroupId");

                    b.HasIndex("ParentId");

                    b.HasIndex("RecieverId");

                    b.HasIndex("TopicId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            Body = "I love peaches",
                            GroupId = 1,
                            Title = "Fun fact"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Body = "I love beaches",
                            GroupId = 1,
                            Title = "Fun fact"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            Body = "I love leaches",
                            GroupId = 1,
                            Title = "Fun fact"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 2,
                            Body = "I love breaches",
                            GroupId = 1,
                            Title = "Fun fact"
                        });
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Discussion of news",
                            Name = "News"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Discuss anything that is related to fun things!",
                            Name = "Fun"
                        },
                        new
                        {
                            Id = 3,
                            Description = "We talk about anything related to animals",
                            Name = "Animals"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Food talk, recipes and anything that involves food",
                            Name = "Food"
                        });
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("FunFact")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("KeycloakId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bio = "Likes football",
                            FunFact = "None",
                            KeycloakId = "4f1bd04c-7e5a-406f-952d-756ed92933bc",
                            Status = "Online",
                            Username = "fred"
                        },
                        new
                        {
                            Id = 2,
                            Bio = "Likes backend and peaches",
                            FunFact = "None",
                            KeycloakId = "14b7a32e-27a4-488b-89d4-e411bec2ba2f",
                            Status = "Online",
                            Username = "olem"
                        },
                        new
                        {
                            Id = 3,
                            Bio = "Fan of sodas",
                            FunFact = "None",
                            KeycloakId = "a23f6e10-697d-4f53-bd1d-f38157e3ef54",
                            Status = "Online",
                            Username = "solo"
                        },
                        new
                        {
                            Id = 4,
                            Bio = "Mr.Bean lover",
                            FunFact = "None",
                            KeycloakId = "14b7a32e-27a4-488b-89d4-e411bec2ba2f",
                            Status = "Online",
                            Username = "johnny"
                        });
                });

            modelBuilder.Entity("EventGroup", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("EventGroup");
                });

            modelBuilder.Entity("EventTopic", b =>
                {
                    b.Property<int>("EventsId")
                        .HasColumnType("int");

                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.HasKey("EventsId", "TopicsId");

                    b.HasIndex("TopicsId");

                    b.ToTable("EventTopic");
                });

            modelBuilder.Entity("EventUserInvitation", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventUserInvitation");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 1,
                            UserId = 2
                        },
                        new
                        {
                            EventId = 1,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 1,
                            UserId = 4
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 2
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 4
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 2
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("GroupsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("RSVP", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("RSVP");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 1,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 1,
                            UserId = 4
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 2,
                            UserId = 4
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 1
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 3
                        },
                        new
                        {
                            EventId = 3,
                            UserId = 4
                        });
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.Property<int>("TopicsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("TopicsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("TopicUser");
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Event", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", "Author")
                        .WithMany("AuthoredEvents")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Post", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", "Author")
                        .WithMany("AuthoredPosts")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Event", "Event")
                        .WithMany("Posts")
                        .HasForeignKey("EventId");

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupId");

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Post", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId");

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", "Reciever")
                        .WithMany("RecievedPosts")
                        .HasForeignKey("RecieverId");

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Topic", "Topic")
                        .WithMany("Posts")
                        .HasForeignKey("TopicId");

                    b.Navigation("Author");

                    b.Navigation("Event");

                    b.Navigation("Group");

                    b.Navigation("Parent");

                    b.Navigation("Reciever");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("EventGroup", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventTopic", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Event", null)
                        .WithMany()
                        .HasForeignKey("EventsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EventUserInvitation", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupUser", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RSVP", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TopicUser", b =>
                {
                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.Topic", null)
                        .WithMany()
                        .HasForeignKey("TopicsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni_Network_Portal_BE.Models.Domain.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Event", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Group", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.Topic", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("Alumni_Network_Portal_BE.Models.Domain.User", b =>
                {
                    b.Navigation("AuthoredEvents");

                    b.Navigation("AuthoredPosts");

                    b.Navigation("RecievedPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
