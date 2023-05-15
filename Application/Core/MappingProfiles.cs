using Application.CleaningEvents;
using Application.Profiles;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<Complaint, Complaint>();
            CreateMap<CleaningEvent, CleaningEvent>();
            CreateMap<CleaningEvent, CleaningEventDto>()
                .ForMember(d => d.HostUsername, o => o.MapFrom(s => s.Attendees
                     .FirstOrDefault(x => x.IsHost).AppUser.UserName));
            CreateMap<CleaningEventAttendee, AttendeeDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<AppUser, Profiles.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(x => x.IsMain).Url));

            CreateMap<CleaningEventAttendee, UserCleaningEventDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.CleaningEvent.Id))
                .ForMember(d => d.Date, o => o.MapFrom(s => s.CleaningEvent.Date))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.CleaningEvent.Title))
                .ForMember(d => d.Category, o => o.MapFrom(s =>
                 s.CleaningEvent.Category))
                .ForMember(d => d.HostUsername, o => o.MapFrom(s =>
                 s.CleaningEvent.Attendees.FirstOrDefault(x =>
                 x.IsHost).AppUser.UserName));
           
            

        }
    }
}