using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using API.Middleware;
using Application.Complaints;
using Application.Core;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// add services to container

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

//Configure the http request pipeline
app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPIv5 v1"));
}

app.UseCors("CorsPolicy");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(
    endpoints =>
    {
        endpoints.MapControllers();
    }
);

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    var context = services.GetRequiredService<DataContext>();
    var userManager = services.GetRequiredService<UserManager<AppUser>>();
    await context.Database.MigrateAsync();
    await Seed.SeedData(context, userManager);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

await app.RunAsync();
