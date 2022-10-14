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
                Bio = "Likes french culture", 
                FunFact = "None",
            });
            users.Add(new User()
            {
                Id = 2,
                KeycloakId = "7ccf5453-c488-43f3-b7eb-587d8e44054b",
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
                Title = "C# learning group",
                Body = "We learn about C#",
                IsPrivate = false
            });
            groups.Add(new Group()
            {
                Id = 2,
                Title = "Noroff",
                Body = "The Noroff group",
                IsPrivate = false,
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
            groups.Add(new Group()
            {
                Id = 5,
                Title = "Fantasy Premier League Experis",
                Body = "Discuss and compete in Experis' own Fantasy Premier League",
                IsPrivate = true
            });
            groups.Add(new Group()
            {
                Id = 6,
                Title = "Bouldering in Bergen",
                Body = "Group to coordinate bouldering events",
                IsPrivate = false
            });
            groups.Add(new Group()
            {
                Id = 7,
                Title = "League of Legends gaming group",
                Body = "Is Kai'sa letting you down lately? Join this group learn why you should play Ezreal",
                IsPrivate = false
            });
            groups.Add(new Group()
            {
                Id = 8,
                Title = "Freddy and the Quizzy McQuizface",
                Body = "How tall is Mt Everest? How deep is the Mariana Trench? If you know these answers join Quizzy McQuizface for a good time",
                IsPrivate = true
            });
            groups.Add(new Group()
            {
                Id = 9,
                Title = "VestBrygg Bergen Homebrewing AS",
                Body = "We got the ingredients, the equipment, and the knowledge. You got the palate for high quality homebrewed Ipa. So HOP along and join our quest for the cleanest belgian triple.",
                IsPrivate = false
            });
            groups.Add(new Group()
            {
                Id = 10,
                Title = "Bergen Husflid",
                Body = "Do you smell of yarn and listening to podcasts while knitting away. This is place for you to get the best deals on habidasheries.",
                IsPrivate = false
            });
            return groups;
        }
        public static List<Post> GetPostSeed()
        {
            List<Post> posts = new List<Post>();
            int i = 1;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Know your variables",
                Body = "CSharp variables needs to be delcared do to it being a strongly typed language. boolean: true or false, char: single character, int: whole number, float: floating point number, double, like float but more accurate, long: like int but bigger, decimal: monetary values.",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 1,
            }) ;
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Know your arrays",
                Body = "int [] ages = new int[8] is the declaration for integer array of set length 8. Remember they are zero indexed! Access the second element like this: ages[1].",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 1,
            }); //learn c#
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Know your dictionaries",
                Body = "Dictionary<int,string> dictionaryOfWords = new Dictionary<int,string>(); is the declaration of key type integer and value type string. It is of dynamic length. add like this: dictionaryOfWords.Add(423, \"First word\"); and access like this dictionaryOfWords(423).",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Know your Class",
                Body = "A class is made of four components. Constructors, fields, bahaviours and properties",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Firealarm might go off today!",
                Body = "The Firealarm might go off today due to technical issues",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 2,
            }); //group noroff
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Weekly menu in the cafeteria",
                Body = "Monday: Bean Shepards Pie, Tuesday: Baked Cod, Wednesday: Chickpea Masala, Thursday: Lentils Lansagna, Friday: Loaded Veggie Taco",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Anyone know how endpoints work?",
                Body = "I have been trying to get enpoints to work, but they just wont work!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 3,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Have you tried adding scoped of the services?",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Checkout the noroff page to see how to correctly set up controller and services",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i - 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I figured out how to get figma to work",
                Body = "If anyone is interested, just ask me",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 3,
            }); //group experis
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Figma balls",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Remember to turn off the lights when leaving the offices",
                Body = "Save electricity in these dark times",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 3,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "They have automatic movement sensors, so theres no stress",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Alumni Network is the best app out there!",
                Body = "Use it for all your social media needs!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 4,
            }); //Group all
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Thank you for using Almuni Network!",
                Body = "The change we need in social media",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 4,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I decided to add Kevin De Bruyne",
                Body = "The man keeps assisting and scoring points, hes def worth the high price",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 5,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Is Arteta the must-have-coach",
                Body = "Arsenal definitely seems to have turned things around this season",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 5,
            });//group fantasy pl
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Cheaper than Pep and gets as many points, but doubt he can keep it up through this season",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I have him on my team, but after the world cup i might change it to Klopp. He'll have a hell of a second half of the season.",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I have Mancini, fml",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i - 3,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "This round scored me so many points!",
                Body = "Holy guacamoly, I ahave never had so many points in a round before!",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 5,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Praise the Lord, Allahu Ackbar, and Barukh Hashem! Haaland is not injured!",
                Body = "I was so stressed, when I heard the rumors",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 5,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Did you guys see Magnus midtbø's newest video?",
                Body = "So crazy that guy",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 6,
            }); //group bouldering
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I am so looking forward to the new bouldering hall in Åsane!",
                Body = "I heard they will have 700 meters of climbing!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 6,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Kai'sa is so overrated",
                Body = "I have no idea how it is the most popular character!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "ARAM is the best gamemode",
                Body = "It always delivers in creating a balanced game!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "When is Worlds?",
                Body = "I want to watch this years worlds",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "It has already been, i am sorry",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Maybe you can watch the replays on youtube",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i - 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "What is your favourite character?",
                Body = "Mine is Lee Sin",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                GroupId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Mine is Teemo!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i - 2,
            }); //Group lol
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I don't want to play toplane anymore!",
                Body = "I just get rekt :( ",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I have read up on geography",
                Body = "I know all the capitals of European and American countries",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 8,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "We need to get some knowledge on litterature",
                Body = "I feel this is the subject we get the least points on",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 8,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I mean, it is the most boring subject of all",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "We are tied with Conquiztadores for second place overall",
                Body = "Next time we will get them!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                GroupId = 8,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Heck yeah we will!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Cheap HOPS! 20% off all week!",
                Body = "Get your hops on now, all hops from the 2021 season is 20% off all week!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 9,
            }); //group quiz
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Congratulations to Tom for brewing the best stout in our fall-brew-off!",
                Body = "Tasty and aromatic, hints of chocolate and coffee. Beautiful mouthfeel!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 9,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Keen on a proper New England IPA? Come by our store to get the best tips and tricks!",
                Body = "We have made a ten step guide to how to create the best NEIPA!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 9,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Use Norwegian yeast Kveik to brew your pale ales!",
                Body = "Get them at our store, for favourable prices and good insight in yeast culture.",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 9,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Anyone understand this knitting recipe, and can help me out?",
                Body = "Page 3 in the Husflid catalogue. How does that make sense?",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 10,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "3x4 =12 and increase by one each round for 8 rounds to get 20. I think..",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                GroupId = 10,
            }); //group husflid
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "What are your favorite colors for winter gowns. I want to sow my own!",
                Body = "Thinking something green",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 10,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "The darker themes of SelfMade are astonishing!",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                GroupId = 10,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Protests in Iran: 'The younger generation are starting a revolution'",
                Body = "The demonstrations erupted nearly a month ago over the death of 22-year-old Mahsa Amini in police custody",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Why cork is making a comeback",
                Body = "Prized for the lightweight, elastic bark, cork oaks can also store large amounts of carbon during their long lifetimes. Now there are moves to find new uses for this material.",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "England in Australia: Third Twenty20 abandoned because of rain in Canberra",
                Body = "England missed the chance to complete a series clean sweep over Australia when their third Twenty20 match in Canberra was abandoned because of rain.",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Cabrera: The heavenly island that became hell on earth",
                Body = "Between 1809 and 1814 the island became a prison for 11,000 defeated Napoleonic soldiers. Conditions were grim and up to 5,000 were estimated to have died of starvation, dehydration, and various illnesses.",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Kwarteng confirms he was asked to 'stand aside'",
                Body = "Kwasi Kwarteng - who is out of his job as the UK's chancellor - has just confirmed that he was sacked by Prime Minister Liz Truss rather than choosing to leave.",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 1,
            }); //topic world news
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "A woman gets on a bus with her baby. The bus driver says: 'Ugh, that’s the ugliest baby I’ve ever seen!'",
                Body = "The woman walks to the rear of the bus and sits down, fuming. She says to a man next to her: “The driver just insulted me!” The man says: “You go up there and tell him off. Go on, I’ll hold your monkey for you.”",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Haha, great one!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I said to the Gym instructor 'Can you teach me to do the splits?'",
                Body = "He said, 'How flexible are you?' I said, 'I can’t make Tuesdays.'",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Haha, great one!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Police arrested two kids yesterday, one was drinking battery acid, the other was eating fireworks.",
                Body = "They charged one – and let the other one off.",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Haha, great one!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 1,
            }); //topic Fun
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I’m on a whiskey diet.",
                Body = "I’ve lost three days already.",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 2,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Haha, great one!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Fun fact: Fleas can jump 350 times its body length.",
                Body = "Isn't that just amazing!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 3,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Fun fact: Hummingbirds are the only birds that can fly backwards.",
                Body = "Isn't that just amazing!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 3,
            }); //topic animals
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Fun fact: Crocodiles cannot stick their tongue out.",
                Body = "Isn't that just amazing!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 3,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Fun fact: Starfish do not have a brain.",
                Body = "Isn't that just amazing!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 3,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Recipe: Simple Pasta",
                Body = "https://www.bbcgoodfood.com/recipes/caponata-pasta",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 4,
            }); //topic food
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Recipe: Coconut & squash dhansak",
                Body = "https://www.bbcgoodfood.com/recipes/coconut-squash-dhansak",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 4,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Recipe: Veggie Fajitas",
                Body = "https://www.bbcgoodfood.com/recipes/veggie-fajitas",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 4,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Top ten hottest caps right now!",
                Body = "Brown wool caps are hot in every sense of the word",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 5,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Anyone now any good places to get caps?",
                Body = "I want to find a nice fall cap!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                TopicId = 5,
            }); //topic caps
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Vanity has some nice ones",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I Wanna Be Your Dog – The Stooges",
                Body = "Such a cool song!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 6,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I love this song!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Anarchy in the UK – Sex Pistols",
                Body = "Proper banger!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 6,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I love this song!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Self Esteem – The Offspring",
                Body = "Such a cool song!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 6,
            }); //topic punk
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I love this song!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "American Idiot – Green Day",
                Body = "Such a cool song!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 6,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I love this song!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Pour over or french press?",
                Body = "Personally I like pour over best, but what do you guys like?",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I use french press myself, but in weekends I use a Bialetti!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Is barrista coffee overrated?",
                Body = "My Moccamaster makes just as good cooffee as any other fancy coffee bars",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 7,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "What are the best beans? Arabica or Robusta",
                Body = "Arabica has been the most famous for a long time, but I like RObusta myself.",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 7,
            }); //topic beans
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "I like arabica myself!",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                ParentId = i - 1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Should we allow for skyscrapers in Bergen",
                Body = "I think they would look nice!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 8,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Car free Bergen!",
                Body = "We want Bergen to become the first European city to be properly car free!",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                TopicId = 8,
            }); //bergen politics
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Bergen politics is bad!",
                Body = "People don't know what they talk about. Me neither, to be fair.",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                TopicId = 8,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Spaceman is the best song!",
                Body = "I was so upset when he didn't win!",
                LastUpdated = DateTime.Now,
                AuthorId = 4,
                TopicId = 9,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "I am so looking forward to next years ESC!",
                Body = "I hope GB will deliver in their hosting!",
                LastUpdated = DateTime.Now,
                AuthorId = 3,
                TopicId = 9,
            }); //Eurovision
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "It has been decided that UK will host the ESC 2023",
                Body = "As Ukraine has been attacked by Russia and is not a safe place currently, it has to be hosted in the UK",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 9,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Two bytes meet.  The first byte asks, 'Are you ill?'",
                Body = "The second byte replies, 'No, just feeling a bit off.'",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 10,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Haha, great one",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i-1,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "Eight bytes walk into a bar.  The bartender asks, 'Can I get you anything?'",
                Body = "'Yeah,' reply the bytes.  'Make us a double.'",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 10,
            }); //programmes memes
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Title = "How did the programmer die in the shower?",
                Body = "He read the shampoo bottle instructions: Lather. Rinse. Repeat.",
                LastUpdated = DateTime.Now,
                AuthorId = 1,
                TopicId = 10,
            });
            i++;
            posts.Add(new Post()
            {
                Id = i,
                Body = "Haha, great one",
                LastUpdated = DateTime.Now,
                AuthorId = 2,
                ParentId = i - 1,
            });

            return posts;
        }
        public static List<Topic> GetTopicSeed()
        {
            List<Topic> topics = new List<Topic>();
            topics.Add(new Topic()
            {
                Id = 1,
                Title = "Worldnews",
                Body = "Discussion of the latest news around the world",
            });
            topics.Add(new Topic()
            {
                Id = 2,
                Title = "Fun",
                Body = "Discuss anything that is related to fun things! Got a good joke? Maybe a banger meme? Post it here!",
            });
            topics.Add(new Topic()
            {
                Id = 3,
                Title = "Animals",
                Body = "We talk about anything related to animals",
            });
            topics.Add(new Topic()
            {
                Id = 4,
                Title = "Food",
                Body = "Food talk, recipes and anything that involves food",
            });
            topics.Add(new Topic()
            {
                Id = 5,
                Title = "Caps and Hats",
                Body = "The hottest trends in the world of headwear",
            });
            topics.Add(new Topic()
            {
                Id = 6,
                Title = "Punk Music",
                Body = "Do you have Red Flags? Do you Rage Against The Machine? Are you a Basket Case? Discuss it with us here",
            });
            topics.Add(new Topic()
            {
                Id = 7,
                Title = "Java Beans",
                Body = "Java means coffee. Anyone who thinks otherwise is a disillusioned fool. Hot steamed and smoke roast",
            });
            topics.Add(new Topic()
            {
                Id = 8,
                Title = "Bergen Politics",
                Body = "Should the Bybana go above Bryggen. Under? Get the latest Bergen news here",
            });
            topics.Add(new Topic()
            {
                Id = 9,
                Title = "Eurovision Song Contest",
                Body = "It is only 7 months until Eurovision 2023 in Liverpool. Get the latest news and discuss them here as the national entries are annouced",
            });
            topics.Add(new Topic()
            {
                Id = 10,
                Title = "Programmer Memes",
                Body = "What is he difference between C and C++? One",
            });
            return topics;
        }
        public static List<Event> GetEventSeed()
        {
            List<Event> events = new List<Event>();
            events.Add(new Event()
            {
                Id = 1,
                Name = "Halloween Party",
                Description = "Halloween? Hello Wine! Get ready for a spooky and fun night!",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 10, 29, 19, 0, 0),
                EndTime = new DateTime(2022, 10, 29, 23, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 2,
                Name = "Project Presentation",
                Description = "The Noroff course presentation of the case project",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 10, 28, 12, 0, 0),
                EndTime = new DateTime(2022, 10, 28, 16, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 3,
                Name = "After Work Beer",
                Description = "Get your socks on and rock on! The case period is over and we need to forget everything we have learned",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 10, 28, 16, 0, 0),
                EndTime = new DateTime(2022, 10, 28, 22, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 4,
                Name = "Vg Lista topp 20",
                Description = "Come to Festplassen, Bergen to celebrate the best norwegian music!",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2023, 7, 5, 19, 0, 0),
                EndTime = new DateTime(2023, 7, 5, 22, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 5,
                Name = "Fantasy Permier League Weekly Recap",
                Description = "Haaland won't stop scoring goals. Complain about at Fredrik's apartment",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 11, 1, 17, 0, 0),
                EndTime = new DateTime(2022, 11, 1, 19, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 6,
                Name = "Bouldering in Laksevåg",
                Description = "Laksevåg has set new routes so we are going exploring!",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 11, 2, 17, 0, 0),
                EndTime = new DateTime(2022, 11, 2, 21, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 7,
                Name = "5 man queue",
                Description = "Today we are ranking up!",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 10, 28, 17, 0, 0),
                EndTime = new DateTime(2022, 10, 28, 21, 0, 0),
                AllowGuests = false,
            });
            events.Add(new Event()
            {
                Id = 8,
                Name = "Thursday Quiz at Finnegans",
                Description = "Trivia, beer and atmosphere!",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 11, 3, 17, 0, 0),
                EndTime = new DateTime(2022, 11, 3, 21, 0, 0),
                AllowGuests = false,
            });
            events.Add(new Event()
            {
                Id = 9,
                Name = "Learn To brew your own beer!",
                Description = "VestBrygg is hosting a beginners course in brewing your own beer. ",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 10, 31, 18, 0, 0),
                EndTime = new DateTime(2022, 10, 31, 20, 0, 0),
                AllowGuests = true,
            });
            events.Add(new Event()
            {
                Id = 10,
                Name = "Knitting and chatting",
                Description = "Get together to share knitting recepies and inspire eachother. There will be tea and cookies ;)",
                LastUpdated = DateTime.Now,
                StartTime = new DateTime(2022, 10, 30, 10, 0, 0),
                EndTime = new DateTime(2022, 10, 30, 14, 0, 0),
                AllowGuests = true,
            });
            return events;
        }
    }
}
