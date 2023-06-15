using Domain;
using Domain.Complaints;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !context.CleaningEvents.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Shanaya Gangwani",
                        UserName = "shanaya",
                        Email = "shanaya@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Meera Raj",
                        UserName = "meera",
                        Email = "meera@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Raman Singh",
                        UserName = "raman",
                        Email = "raman@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Member");
                }

                var admin = new AppUser { UserName = "admin", Email = "admin@test.com" };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });

                var cleaningEvents = new List<CleaningEvent>
                {
                    new CleaningEvent
                    {
                        Title = "Beach Cleaning at Vasco",
                        Date = DateTime.UtcNow.AddMonths(-2),
                        Description = "Cleaning Event",
                        Category = "Beach Cleaning",
                        City = "Vasco da Gama",
                        Venue = "Velsao Beach",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[0], IsHost = true }
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Let's make India's Capital City clean",
                        Date = DateTime.UtcNow.AddMonths(-1),
                        Description = "Cleaning Event 1 month ago",
                        Category = "City Cleaning",
                        City = "New Delhi",
                        Venue = "Connaught Place",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[0], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[1], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Let's clean  India Silicon Valley",
                        Date = DateTime.UtcNow.AddMonths(1),
                        Description = "Cleaning Event",
                        Category = "Educational Event",
                        City = "Bangalore",
                        Venue = "Koramangala",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[2], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[1], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Orange City Cleanliness Campaign",
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = "Cleaning Event",
                        Category = "College campus cleaning",
                        City = "Nagpur",
                        Venue = "Bardi",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[0], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[2], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Let's clean Nizams city",
                        Date = DateTime.UtcNow.AddMonths(3),
                        Description = "Cleaning Event",
                        Category = "City Cleaning",
                        City = "Hyderabad",
                        Venue = "Nizampet",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[1], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[0], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Go Goa Clean",
                        Date = DateTime.UtcNow.AddMonths(4),
                        Description = "Cleaning Event",
                        Category = "Beach Cleaning",
                        City = "Panaji",
                        Venue = "Odxel Beach",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[1], IsHost = true }
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Clean IITs clean India",
                        Date = DateTime.UtcNow.AddMonths(5),
                        Description = "Cleaning event",
                        Category = "College Campus Cleaning ",
                        City = "New Delhi",
                        Venue = "IIT Delhi",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[0], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[1], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Know more about Swachhata",
                        Date = DateTime.UtcNow.AddMonths(6),
                        Description = "Cleaning Event",
                        Category = "Educational Event",
                        City = "Bhopal",
                        Venue = "Habib Ganj ",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[2], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[1], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Clean Bihar Campaign",
                        Date = DateTime.UtcNow.AddMonths(7),
                        Description = "Lets make Bihar's capital clean",
                        Category = "City Cleaning",
                        City = "Patna",
                        Venue = "Mithapur",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[0], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[2], IsHost = false },
                        }
                    },
                    new CleaningEvent
                    {
                        Title = "Clean Mangalore Campaign",
                        Date = DateTime.UtcNow.AddMonths(8),
                        Description = "Cleaning Event to support Swacch Bharat",
                        Category = "Beach Cleaning",
                        City = "Mangalore",
                        Venue = "Mulki Beach",
                        Attendees = new List<CleaningEventAttendee>
                        {
                            new CleaningEventAttendee { AppUser = users[2], IsHost = true },
                            new CleaningEventAttendee { AppUser = users[1], IsHost = false },
                        }
                    }
                };

                // Read and parse the CSV file
                var csvFilePath = "C:/Users/msi-pc/CleanIndiaWebApp/Persistence/CitiesStatesList.csv";
                var csvData = File.ReadAllLines(csvFilePath);

                var states = new Dictionary<string, State>();

                foreach (var row in csvData.Skip(1))
                {
                    var columns = row.Split(',');

                    var cityName = columns[0].Trim();
                    var stateName = columns[1].Trim();

                    // Check if the state already exists in the dictionary
                    if (!states.TryGetValue(stateName, out var state))
                    {
                        // If the state doesn't exist, check if it already exists in the database
                        state = await context.States.SingleOrDefaultAsync(
                            s => s.StateName == stateName
                        );

                        // If the state doesn't exist in the database, create a new state entity and add it to the context and the dictionary
                        if (state == null)
                        {
                            state = new State { StateName = stateName };
                            context.States.Add(state);
                        }

                        states.Add(stateName, state);
                    }

                    // Create a new city entity and associate it with the state
                    var city = new City { CityName = cityName, State = state };
                    context.Cities.Add(city);
                }

                await context.SaveChangesAsync();

                await context.CleaningEvents.AddRangeAsync(cleaningEvents);
                await context.SaveChangesAsync();
            }

        }
     }
}
