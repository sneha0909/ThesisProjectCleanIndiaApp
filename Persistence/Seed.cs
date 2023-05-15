using Domain;
using Microsoft.AspNetCore.Identity;

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
                        Title = "Past Cleaning Event 1",
                        Date = DateTime.UtcNow.AddMonths(-2),
                        Description = "Cleaning Event 2 months ago",
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
                        Title = "Past Cleaning Event 2",
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
                        Title = "Future Cleaning Event 1",
                        Date = DateTime.UtcNow.AddMonths(1),
                        Description = "Cleaning Event 1 month in future",
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
                        Title = "Future Cleaning Event 2",
                        Date = DateTime.UtcNow.AddMonths(2),
                        Description = "Cleaning Event 2 months in future",
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
                        Title = "Future Cleaning Event 3",
                        Date = DateTime.UtcNow.AddMonths(3),
                        Description = "Cleaning Event 3 months in future",
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
                        Title = "Future Cleaning Event 4",
                        Date = DateTime.UtcNow.AddMonths(4),
                        Description = "Cleaning Event 4 months in future",
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
                        Title = "Future Cleaning Event 5",
                        Date = DateTime.UtcNow.AddMonths(5),
                        Description = "Cleaning event 5 months in future",
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
                        Title = "Future Cleaning Event 6",
                        Date = DateTime.UtcNow.AddMonths(6),
                        Description = "Cleaning Event 6 months in future",
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
                        Title = "Future Cleaning Event 7",
                        Date = DateTime.UtcNow.AddMonths(7),
                        Description = "Cleaning Event 7 months in future",
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
                        Title = "Future Cleaning Event 8",
                        Date = DateTime.UtcNow.AddMonths(8),
                        Description = "Cleaning Event 8 months in future",
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

                await context.CleaningEvents.AddRangeAsync(cleaningEvents);
                await context.SaveChangesAsync();
            }

            if (context.Complaints.Any())
                return;

            var complaints = new List<Complaint>
            {
                new Complaint
                {
                    ComplaintType = "SEWAGE",
                    ComplaintSubType = "REPAIRING",
                    DescriptionofComplaint =
                        "The sewage pipes are damaged and the dirty water is coming on roads",
                    ComplaintLocationHouseNo = "11",
                    ComplaintLocationHouseName = "Shanti Niwas",
                    ComplaintLocationAreaInAddress = "Gauthana",
                    ComplaintLocationZoneWardNo = "D2",
                    ComplaintLocationArea1 = "Gauthana",
                    ComplaintLocationArea2 = "Gauthana",
                    ComplaintLocationCity = "AALOT NAGAR PARISHAD  / आलोट नगर परिषद",
                    ComplaintLocationPincode = "460001",
                    ComplainantName = "Aman Jindal",
                    ComplainantAddressWard = "WARD 1",
                    ComplainantAddressHouseNo = "11",
                    ComplainantAddressHouseName = "Shanti Niwas",
                    ComplainantAddressAreaInAddress = "Gauthana",
                    ComplainantAddressZoneWardNo = "D2",
                    ComplainantAddressArea1 = "Gauthana",
                    ComplainantAddressArea2 = "Gauthana",
                    ComplainantAddressLandmark = "Durga Devi Temple",
                    ComplainantAddressCity = "AALOT NAGAR PARISHAD  / आलोट नगर परिषद",
                    ComplainantAddressState = "Madhya Pradesh",
                    ComplainantAddressCountry = "India",
                    ComplainantAddressSTDCodeOfficeTelephone = "+912",
                    ComplainantAddressOfficeTelephone = "1234098",
                    ComplainantAddressSTDCodeResidenceTelephone = "+912",
                    ComplainantAddressResidenceTelephone = "1234098",
                    PhoneNumber = "73649824",
                    Email = "amanjindal@gmail.com",
                    PhotoUrl =
                        "https://res.cloudinary.com/sneha09/image/upload/v1681061451/csjktq34pwysj8vviz1n.png",
                    ComplaintStatus = "In Review"
                },
                new Complaint
                {
                    ComplaintType = "GARBAGE COLLECTION",
                    ComplaintSubType = "DELAY IN GARBAGE COLLECTION",
                    DescriptionofComplaint =
                        "There's no garbage collection from past 1 week and bins are overflowing, dogs are taking out the garbage and spreading on all over the streets",
                    ComplaintLocationHouseNo = "15",
                    ComplaintLocationHouseName = "Liana House",
                    ComplaintLocationAreaInAddress = "Tikari",
                    ComplaintLocationZoneWardNo = "D10",
                    ComplaintLocationArea1 = "Tikari",
                    ComplaintLocationArea2 = "Tikari",
                    ComplaintLocationCity = "CHICHOLI NAGAR PARISHAD / चिचोली नगर परिषद्",
                    ComplaintLocationPincode = "460001",
                    ComplainantName = "Aarav Kumar",
                    ComplainantAddressWard = "WARD 5",
                    ComplainantAddressHouseNo = "15",
                    ComplainantAddressHouseName = "Liana House",
                    ComplainantAddressAreaInAddress = "Tikari",
                    ComplainantAddressZoneWardNo = "D10",
                    ComplainantAddressArea1 = "Tikari",
                    ComplainantAddressArea2 = "Tikari",
                    ComplainantAddressLandmark = "ELC Church",
                    ComplainantAddressCity = "CHICHOLI NAGAR PARISHAD / चिचोली नगर परिषद्",
                    ComplainantAddressState = "Madhya Pradesh",
                    ComplainantAddressCountry = "India",
                    ComplainantAddressSTDCodeOfficeTelephone = "+912",
                    ComplainantAddressOfficeTelephone = "45487548",
                    ComplainantAddressSTDCodeResidenceTelephone = "+912",
                    ComplainantAddressResidenceTelephone = "45487548",
                    PhoneNumber = "1234567",
                    Email = "aaravkumar@gmail.com",
                    PhotoUrl =
                        "https://res.cloudinary.com/sneha09/image/upload/v1682692665/celalnin2_sgvwfx.png",
                    ComplaintStatus = "Complaint Resolved"
                },
                new Complaint
                {
                    ComplaintType = "SEWAGE",
                    ComplaintSubType = "REPAIRING",
                    DescriptionofComplaint =
                        "The sewage pipes are damaged from past 1 week and the dirty water is coming on roads and causing Diseases like Malaria",
                    ComplaintLocationHouseNo = "12",
                    ComplaintLocationHouseName = "Durga Niwas",
                    ComplaintLocationAreaInAddress = "Sadar",
                    ComplaintLocationZoneWardNo = "D3",
                    ComplaintLocationArea1 = "Sadar",
                    ComplaintLocationArea2 = "Sadar",
                    ComplaintLocationCity = "DINDORI NAGAR PARISHAD / डिंडोरी नगर परिषद्",
                    ComplaintLocationPincode = "460001",
                    ComplainantName = "Amisha Gangwani",
                    ComplainantAddressWard = "WARD 2",
                    ComplainantAddressHouseNo = "12",
                    ComplainantAddressHouseName = "Durga Niwas",
                    ComplainantAddressAreaInAddress = "Sadar",
                    ComplainantAddressZoneWardNo = "D3",
                    ComplainantAddressArea1 = "Sadar",
                    ComplainantAddressArea2 = "Sadar",
                    ComplainantAddressLandmark = "Samsung Showroom",
                    ComplainantAddressCity = "DINDORI NAGAR PARISHAD / डिंडोरी नगर परिषद्",
                    ComplainantAddressState = "Madhya Pradesh",
                    ComplainantAddressCountry = "India",
                    ComplainantAddressSTDCodeOfficeTelephone = "+912",
                    ComplainantAddressOfficeTelephone = "987654321",
                    ComplainantAddressSTDCodeResidenceTelephone = "+912",
                    ComplainantAddressResidenceTelephone = "987654321",
                    PhoneNumber = "7654321",
                    Email = "amishagangwani@gmail.com",
                    PhotoUrl =
                        "https://res.cloudinary.com/sneha09/image/upload/v1682692665/cleain_eqbwwm.png",
                    ComplaintStatus = "Feedback"
                },
            };

            await context.Complaints.AddRangeAsync(complaints);
            await context.SaveChangesAsync();
        }
    }
}
