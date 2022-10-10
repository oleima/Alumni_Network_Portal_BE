using Alumni_Network_Portal_BE.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace Alumni_Network_Portal_BE.Helpers
{
    public class SeedHelper
    {
        public static List<User> GetUserSeed()
        {
            List<User> users = new List<User>();
            users.Add(new User()
            {
                Id = 1,
                KeycloakId = "4f1bd04c-7e5a-406f-952d-756ed92933bc", 
                Username = "fred", 
                Status = "Online", 
                Bio = "Likes football", 
                FunFact = "None",
            });
            users.Add(new User()
            {
                Id = 2,
                KeycloakId = "14b7a32e-27a4-488b-89d4-e411bec2ba2f",
                Username = "olem",
                Status = "Online",
                Bio = "Likes backend and peaches",
                FunFact = "None"
            });
            users.Add(new User()
            {
                Id = 3,
                KeycloakId = "a23f6e10-697d-4f53-bd1d-f38157e3ef54",
                Username = "solo",
                Status = "Online",
                Bio = "Fan of sodas",
                FunFact = "None"
            });
            users.Add(new User()
            {
                Id = 4,
                KeycloakId = "14b7a32e-27a4-488b-89d4-e411bec2ba2f",
                Username = "johnny",
                Status = "Online",
                Bio = "Mr.Bean lover",
                FunFact = "None"
            });
            return users;
        }
        public static List<Group> GetGroupSeed()
        {
            List<Group> groups = new List<Group>();
            groups.Add(new Group()
            {
                Id = 1,
                Title = "Noroff",
                Body = "The noroff group",
                IsPrivate = false,
            });
            groups.Add(new Group()
            {
                Id = 2,
                Title = "C# learning group",
                Body = "We learn about C#",
                IsPrivate = false
            });
            groups.Add(new Group()
            {
                Id = 3,
                Title = "Experis Academy",
                Body = "For members of Experis",
                IsPrivate = true
            });
            groups.Add(new Group()
            {
                Id = 4,
                Title = "Group for everyone",
                Body = "Anyone can be part of this group",
                IsPrivate = false
            });
            return groups;
        }
        public static List<Post> GetPostSeed()
        {
            List<Post> posts = new List<Post>();
            posts.Add(new Post()
            {
                Id = 1,
                Title = "Fun fact",
                Body = "I love peaches",
                AuthorId = 2,
                GroupId = 1,
            }) ;
            posts.Add(new Post()
            {
                Id = 2,
                Title = "Fun fact",
                Body = "I love beaches",
                AuthorId = 2,
                GroupId = 1,
            });
            posts.Add(new Post()
            {
                Id = 3,
                Title = "Fun fact",
                Body = "I love leaches",
                AuthorId = 2,
                GroupId = 1,
            });
            posts.Add(new Post()
            {
                Id = 4,
                Title = "Fun fact",
                Body = "I love breaches",
                AuthorId = 2,
                GroupId = 1,
            });
            return posts;
        }
        public static List<Topic> GetTopicSeed()
        {
            List<Topic> topics = new List<Topic>();
            topics.Add(new Topic()
            {
                Id = 1,
                Name = "News",
                Description = "Discussion of news",
            });
            topics.Add(new Topic()
            {
                Id = 2,
                Name = "Fun",
                Description = "Discuss anything that is related to fun things!",
            });
            topics.Add(new Topic()
            {
                Id = 3,
                Name = "Animals",
                Description = "We talk about anything related to animals",
            });
            topics.Add(new Topic()
            {
                Id = 4,
                Name = "Food",
                Description = "Food talk, recipes and anything that involves food",
            });
            return topics;
        }
        public static List<Event> GetEventSeed()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Party in the USA",
                Description = "Get your cowboy boots on and bourbon ready",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2023, 07, 04, 16, 0, 0),
                EndTime = new DateTime(2023, 07, 05, 03, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "Project Presentation",
                Description = "The Noroff course presentation of the case project",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2023, 10, 28, 12, 0, 0),
                EndTime = new DateTime(2023, 10, 28, 16, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 3,
                Name = "After Work Beer",
                Description = "Get your socks on and rock on! The case period is over and we need to forget everything we have learned",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2023, 10, 28, 16, 0, 0),
                EndTime = new DateTime(2023, 10, 28, 22, 0, 0),
                AllowGuests = true,
            });
            return events;
        }
    }
}
