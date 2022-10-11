﻿using Alumni_Network_Portal_BE.Helpers;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.RegularExpressions;
using Group = Alumni_Network_Portal_BE.Models.Domain.Group;

namespace Alumni_Network_Portal_BE.Models
{
    public class AlumniNetworkDbContext : DbContext
    {
        public AlumniNetworkDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }


        //overriding OnModelCreating to create seeddata for all object models 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if(Database.IsNpgsql())
            {
                var boolConverter = new ValueConverter<bool, int>(v => v ? 1 : 0,v => (v == 1) ? true : false);

                foreach (var entityType in modelBuilder.Model.GetEntityTypes())
                {
                    foreach (var property in entityType.GetProperties())
                    {
                        if (property.ClrType == typeof(bool))
                            property.SetValueConverter(boolConverter);
                    }
                }
            }

            // Seeddata

            // Seed User
            // Id, keycloakid, username, status, bio, funfact, picture
            modelBuilder.Entity<User>().HasData(SeedHelper.GetUserSeed());

            // Seed Group
            // Id, title, body, isprivate
            modelBuilder.Entity<Group>().HasData(SeedHelper.GetGroupSeed());

            // Seed Post
            //Id, Title, Body, AuthorId, GroupId,
            modelBuilder.Entity<Post>().HasData(SeedHelper.GetPostSeed());

            // Seed Topic
            // id, name, description
            modelBuilder.Entity<Topic>().HasData(SeedHelper.GetTopicSeed());

            // Seed Event
            // Id, name, description, lastupdated, starttime, endtime, allowguests?
            modelBuilder.Entity<Event>().HasData(SeedHelper.GetEventSeed());


            // Seed GroupMember, EventUserInvite, EventGroupInvite, EventTopicInvite, RSVP, TopicMember

            //Relationships
            modelBuilder.Entity<User>()
            .HasMany(e => e.AuthoredEvents)
            .WithOne(e => e.Author)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(e => e.AuthoredPosts)
            .WithOne(e => e.Author)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
            .HasMany(e => e.InvitedEvents)
            .WithMany(e => e.UserInvited)
            .UsingEntity<Dictionary<string, object>>(
                    "EventUserInvitation",
                    r => r.HasOne<Event>().WithMany().HasForeignKey("EventId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    je =>
                    {
                        je.HasKey("EventId", "UserId");
                        je.HasData(
                            new { EventId = 1, UserId = 1 },
                            new { EventId = 1, UserId = 2 },
                            new { EventId = 1, UserId = 3 },
                            new { EventId = 1, UserId = 4 },
                            new { EventId = 2, UserId = 1 },
                            new { EventId = 2, UserId = 2 },
                            new { EventId = 2, UserId = 3 },
                            new { EventId = 2, UserId = 4 },
                            new { EventId = 3, UserId = 1 },
                            new { EventId = 3, UserId = 2 },
                            new { EventId = 3, UserId = 3 },
                            new { EventId = 3, UserId = 4 }
                            );
                    });

            modelBuilder.Entity<User>()
            .HasMany(e => e.RespondedEvents)
            .WithMany(e => e.UsersResponded)
            .UsingEntity<Dictionary<string, object>>(
                    "RSVP",
                    r => r.HasOne<Event>().WithMany().HasForeignKey("EventId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    je =>
                    {
                        je.HasKey("EventId", "UserId");
                        je.HasData(
                            new { EventId = 1, UserId = 1 },
                            new { EventId = 1, UserId = 3 },
                            new { EventId = 1, UserId = 4 },
                            new { EventId = 2, UserId = 1 },
                            new { EventId = 2, UserId = 3 },
                            new { EventId = 2, UserId = 4 },
                            new { EventId = 3, UserId = 1 },
                            new { EventId = 3, UserId = 3 },
                            new { EventId = 3, UserId = 4 }
                            );
                    });

            modelBuilder.Entity<User>()
            .HasMany(e => e.Topics)
            .WithMany(e => e.Users)
            .UsingEntity<Dictionary<string, object>>(
                    "Subscribe_Topic",
                    r => r.HasOne<Topic>().WithMany().HasForeignKey("TopicId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    je =>
                    {
                        je.HasKey("TopicId", "UserId");
                        je.HasData(
                            new { TopicId = 1, UserId = 1 },
                            new { TopicId = 1, UserId = 2 },
                            new { TopicId = 1, UserId = 3 },
                            new { TopicId = 2, UserId = 1 },
                            new { TopicId = 2, UserId = 2 },
                            new { TopicId = 2, UserId = 4 },
                            new { TopicId = 3, UserId = 1 },
                            new { TopicId = 3, UserId = 3 },
                            new { TopicId = 3, UserId = 4 },
                            new { TopicId = 4, UserId = 2 },
                            new { TopicId = 4, UserId = 3 },
                            new { TopicId = 4, UserId = 4 }
                            );
                    });

            modelBuilder.Entity<User>()
            .HasMany(e => e.Groups)
            .WithMany(e => e.Users)
            .UsingEntity<Dictionary<string, object>>(
                    "GroupMember",
                    r => r.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    l => l.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    je =>
                    {
                        je.HasKey("GroupId", "UserId");
                        je.HasData(
                            new { GroupId = 1, UserId = 1 },
                            new { GroupId = 1, UserId = 2 },
                            new { GroupId = 1, UserId = 3 },
                            new { GroupId = 2, UserId = 1 },
                            new { GroupId = 2, UserId = 2 },
                            new { GroupId = 2, UserId = 4 },
                            new { GroupId = 3, UserId = 1 },
                            new { GroupId = 3, UserId = 3 },
                            new { GroupId = 3, UserId = 4 },
                            new { GroupId = 4, UserId = 2 },
                            new { GroupId = 4, UserId = 3 },
                            new { GroupId = 4, UserId = 4 }
                            );
                    });

            modelBuilder.Entity<Event>()
            .HasMany(e => e.Groups)
            .WithMany(e => e.Events)
            .UsingEntity<Dictionary<string, object>>(
                    "Event_Group",
                    r => r.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    l => l.HasOne<Event>().WithMany().HasForeignKey("EventId"),
                    je =>
                    {
                        je.HasKey("GroupId", "EventId");
                        je.HasData(
                            new { GroupId = 2, EventId = 1 },
                            new { GroupId = 3, EventId = 1 },
                            new { GroupId = 1, EventId = 2 },
                            new { GroupId = 3, EventId = 3 },
                            new { GroupId = 4, EventId = 3 }
                            );
                    });

            modelBuilder.Entity<Event>()
            .HasMany(e => e.Topics)
            .WithMany(e => e.Events)
            .UsingEntity<Dictionary<string, object>>(
                "Event_Topic",
                r => r.HasOne<Topic>().WithMany().HasForeignKey("TopicId"),
                l => l.HasOne<Event>().WithMany().HasForeignKey("EventId"),
                je =>
                {
                    je.HasKey("TopicId", "EventId");
                    je.HasData(
                        new { TopicId = 2, EventId = 1 },
                        new { TopicId = 2, EventId = 3 }
                    );
                });

        }
    }
}
