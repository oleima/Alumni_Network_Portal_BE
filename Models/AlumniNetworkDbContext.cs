using Alumni_Network_Portal_BE.Helpers;
using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;
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
        }
    }
}
