using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {
             if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser
                    {
                        ComplainantName = "Victor",
                        UserName = "victor",
                        State = "Madhya Pradesh",
                        District = "Betul",
                        MunicipalCorporation = "Municipal Corporation Betul",
                        Email = "victor@test.com",
                        PhoneNumber = "9137532999",
                    },
                    new AppUser
                    {
                        ComplainantName = "Diana",
                        UserName = "diana",
                        State = "Maharashtra",
                        District = "Aurangabad",
                        MunicipalCorporation = "Municipal Corporation Aurangabad",
                        Email = "victor@test.com",
                        PhoneNumber = "9137532888",
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
            
            if (context.Complaints.Any())
                return;

            var complaints = new List<Complaint>
            {
                new Complaint
                {
                    ComplainantName = "Aman Jindal",
                    DateOfComplaint = DateTime.UtcNow.AddMonths(-2),
                    State = "Assam",
                    District = "Sonitpur",
                    MunicipalCorporation = "Sonitpur Municipal Corporation ",
                    Email = "amanjindal@gmail.com",
                    PhoneNumber = "73649824",
                    Status = "Complaint in Review"
                },
                new Complaint
                {
                    ComplainantName = "Aarav Kumar",
                    DateOfComplaint = DateTime.UtcNow.AddMonths(-1),
                    State = "Arunachal Pradesh",
                    District = "East Siang",
                    MunicipalCorporation = "East Siang Municipal Corporation",
                    Email = "aaravkumar@gmail.com",
                    PhoneNumber = "1234567",
                    Status = "Complaint Resolved"
                },
                new Complaint
                {
                    ComplainantName = "Amisha Gangwani",
                    DateOfComplaint = DateTime.UtcNow.AddMonths(1),
                    State = "Karnataka",
                    District = "Bidar",
                    MunicipalCorporation = "Bidar Municipal Corporation",
                    Email = "amishagangwani@gmail.com",
                    PhoneNumber = "7654321",
                    Status = "Complaint Filed"
                },
                new Complaint
                {
                    ComplainantName = "Varun Singh",
                    DateOfComplaint = DateTime.UtcNow.AddMonths(2),
                    State = "Mizoram",
                    District = "Aizawl",
                    MunicipalCorporation = "Aizawl Municipal Corporation",
                    Email = "varunsingh@gmail.com",
                    PhoneNumber = "0987654",
                    Status = "Action taken"
                },
                new Complaint
                {
                    ComplainantName = "Kaira Singh",
                    DateOfComplaint = DateTime.UtcNow.AddMonths(3),
                    State = "Manipur",
                    District = "Imphal East ",
                    MunicipalCorporation = "Imphal East Municipal Corporation",
                    Email = "kairasingh@gmail.com",
                    PhoneNumber = "546789546",
                    Status = "Complaint filed"
                },
                new Complaint
                {
                    ComplainantName = "Somya Tripathi",
                    DateOfComplaint = DateTime.UtcNow.AddMonths(4),
                    State = "Madhya Pradesh",
                    District = "Betul",
                    MunicipalCorporation = "Betul Municipal Corporation",
                    Email = "somyatripathi@gmail.com",
                    PhoneNumber = "65345638759",
                    Status = "Complaint Resolved"
                },
               
            };

            await context.Complaints.AddRangeAsync(complaints);
            await context.SaveChangesAsync();

           
        }
    }
}
