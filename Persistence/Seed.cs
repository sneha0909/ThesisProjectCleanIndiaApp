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
                        ComplainantName = "Harry Potter",
                        UserName = "harry",
                        Email = "harry@test.com"
                    },
                    new AppUser
                    {
                        ComplainantName = "Hermione Granger",
                        UserName = "hermione",
                        Email = "granger@test.com"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Member");
                }

                var admin = new AppUser 
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new [] {"Member", "Admin"});
            }
            
            if (context.Complaints.Any())
                return;

            var complaints = new List<Complaint>
            {
                new Complaint
                {
                    ComplaintType = "SEWAGE",
                    ComplaintSubType = "REPAIRING",
                    DescriptionofComplaint = "The sewage pipes are damaged and the dirty water is coming on roads",
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
                    PhotoUrl = "https://res.cloudinary.com/sneha09/image/upload/v1680990369/zzewtkpvpvamei3hebo0.png",
                    ComplaintStatus = "In Review"
                    
                    
                },
                new Complaint
                {
                    ComplaintType = "GARBAGE COLLECTION",
                    ComplaintSubType = "DELAY IN GARBAGE COLLECTION",
                    DescriptionofComplaint = "There's no garbage collection from past 1 week and bins are overflowing, dogs are taking out the garbage and spreading on all over the streets",
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
                    PhotoUrl = "https://res.cloudinary.com/sneha09/image/upload/v1679835576/jwy8kmasgjis976voekq.png",
                    ComplaintStatus = "Complaint Resolved"
                    
                },
                new Complaint
                {
                    ComplaintType = "SEWAGE",
                    ComplaintSubType = "REPAIRING",
                    DescriptionofComplaint = "The sewage pipes are damaged from past 1 week and the dirty water is coming on roads and causing Diseases like Malaria",
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
                    PhotoUrl = "https://res.cloudinary.com/sneha09/image/upload/v1678908472/v6u798z0nuj4c95mrzwx.png",
                    ComplaintStatus = "Feedback"
                },
               
            };

            await context.Complaints.AddRangeAsync(complaints);
            await context.SaveChangesAsync();

           
        }
    }
}
