using Alumni_Network_Portal_BE.Models.Domain;
using Microsoft.EntityFrameworkCore;

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
            //modelBuilder.Entity<User>().HasData(new User { Id = 1, KeycloakId = "4f1bd04c-7e5a-406f-952d-756ed92933bc", Username = "fred", Status = "Online", Bio = "Likes football", FunFact = "None" });
            //modelBuilder.Entity<User>().HasData(new User { Id = 2, KeycloakId = "14b7a32e-27a4-488b-89d4-e411bec2ba2f", Username = "olem", Status = "Online", Bio = "Likes backend and peaches", FunFact = "None" });
            //modelBuilder.Entity<User>().HasData(new User { Id = 3, KeycloakId = "a23f6e10-697d-4f53-bd1d-f38157e3ef54", Username = "solo", Status = "Online", Bio = "Fan of sodas", FunFact = "None" });
            //modelBuilder.Entity<User>().HasData(new User { Id = 4, KeycloakId = "14b7a32e-27a4-488b-89d4-e411bec2ba2f", Username = "johnny", Status = "Online", Bio = "Mr.Bean lover", FunFact = "None" });

            //// Seed Group
            //// Id, title, body, isprivate
            //modelBuilder.Entity<Group>().HasData(new Group { Id = 1, Title = "Noroff", Body = "The noroff group", IsPrivate = false });
            //modelBuilder.Entity<Group>().HasData(new Group { Id = 2, Title = "C# learning group", Body = "We learn about C#", IsPrivate = false });
            //modelBuilder.Entity<Group>().HasData(new Group { Id = 3, Title = "Experis Academy", Body = "For members of Experis", IsPrivate = true });
            //modelBuilder.Entity<Group>().HasData(new Group { Id = 4, Title = "Group for everyone", Body = "Anyone can be part of this group", IsPrivate = false });

            //// Seed Post

            //modelBuilder.Entity<Post>().HasData(new Post { Id = 1, Title = "Fun fact", Body = "I love peaches" });

            //// Seed Topic
            //// id, name, description
            //modelBuilder.Entity<Topic>().HasData(new Topic { Id = 1, Name = "News", Description = "Discussion of news" });
            //modelBuilder.Entity<Topic>().HasData(new Topic { Id = 2, Name = "Fun", Description = "Discuss anything that is related to fun things!" });
            //modelBuilder.Entity<Topic>().HasData(new Topic { Id = 3, Name = "Animals", Description = "We talk about anything related to animals" });
            //modelBuilder.Entity<Topic>().HasData(new Topic { Id = 4, Name = "Food", Description = "Food talk, recipes and anything that involves food" });

            // Seed Event
            // Id, name, description, lastupdated, starttime, endtime, allowguests?

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
            .WithMany(e => e.UserInvited);

            modelBuilder.Entity<User>()
            .HasMany(e => e.RespondedEvents)
            .WithMany(e => e.UsersResponded);
        }
    }
}
