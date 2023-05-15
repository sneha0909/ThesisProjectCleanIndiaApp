using API.Services;
using Application.CleaningEvents;
using Application.Complaints;
using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Photos;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Persistence;
using Grpc.Net.ClientFactory;
using Google.Cloud.Translate.V3;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration config
        )
        {
            //services.AddApplicationServices(config);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt auth header",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            services.AddDbContext<DataContext>(
                opt =>
                {
                    opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
                }
            );

            services.AddCors(
                opt =>
                {
                    opt.AddPolicy(
                        "CorsPolicy",
                        policy =>
                        {
                            policy
                                .AllowAnyMethod()
                                .AllowAnyHeader()
                                .WithOrigins("http://localhost:3000");
                        }
                    );
                }
            );

            services.AddMediatR(typeof(CleaningEventsList.Handler));
            services.AddMediatR(typeof(ComplaintList.Handler));
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<IPhotoAccessor, PhotoAccessor>();
            services.AddScoped<IComplaintPhotoAccessor, ComplaintPhotoAccessor>();
            services.AddScoped<ImageService>();
            services.Configure<CloudinarySettings>(config.GetSection("Cloudinary"));
            services.AddHttpContextAccessor();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<ComplaintCreate>();
            services.AddValidatorsFromAssemblyContaining<CleaningEventsCreate>();
            services.AddIdentityServices(config);
            services
                .AddIdentityCore<AppUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

            return services;
        }
    }
}
