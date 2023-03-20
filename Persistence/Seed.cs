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
                        // State = "Madhya Pradesh",
                        // District = "Betul",
                        // MunicipalCorporation = "Municipal Corporation Betul",
                        Email = "harry@test.com"
                        // PhoneNumber = "9137532999",
                    },
                    new AppUser
                    {
                        ComplainantName = "Hermione Granger",
                        UserName = "hermione",
                        // State = "Maharashtra",
                        // District = "Aurangabad",
                        // MunicipalCorporation = "Municipal Corporation Aurangabad",
                        Email = "granger@test.com"
                        // PhoneNumber = "9137532888",
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
                    ComplaintLocationCity = "Betul",
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
                    ComplainantAddressCity = "Betul",
                    ComplainantAddressState = "Madhya Pradesh",
                    ComplainantAddressCountry = "India",
                    ComplainantAddressSTDCodeOfficeTelephone = "+912",
                    ComplainantAddressOfficeTelephone = "1234098",
                    ComplainantAddressSTDCodeResidenceTelephone = "+912",
                    ComplainantAddressResidenceTelephone = "1234098",
                    PhoneNumber = "73649824",
                    Email = "amanjindal@gmail.com",
                    PhotoUrl = "/images/products/sb-ang1.png"
                    
                    
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
                    ComplaintLocationCity = "Betul",
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
                    ComplainantAddressCity = "Betul",
                    ComplainantAddressState = "Madhya Pradesh",
                    ComplainantAddressCountry = "India",
                    ComplainantAddressSTDCodeOfficeTelephone = "+912",
                    ComplainantAddressOfficeTelephone = "45487548",
                    ComplainantAddressSTDCodeResidenceTelephone = "+912",
                    ComplainantAddressResidenceTelephone = "45487548",           
                    PhoneNumber = "1234567",
                    Email = "aaravkumar@gmail.com",
                    PhotoUrl = "/images/products/sb-ang1.png"
                    
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
                    ComplaintLocationCity = "Betul",
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
                    ComplainantAddressCity = "Betul",
                    ComplainantAddressState = "Madhya Pradesh",
                    ComplainantAddressCountry = "India",
                    ComplainantAddressSTDCodeOfficeTelephone = "+912",
                    ComplainantAddressOfficeTelephone = "987654321",
                    ComplainantAddressSTDCodeResidenceTelephone = "+912",
                    ComplainantAddressResidenceTelephone = "987654321",           
                    PhoneNumber = "7654321",
                    Email = "amishagangwani@gmail.com",
                    PhotoUrl = "/images/products/sb-ang1.png"    
                },
               
            };

            await context.Complaints.AddRangeAsync(complaints);
            await context.SaveChangesAsync();

           
        }
    }
}
