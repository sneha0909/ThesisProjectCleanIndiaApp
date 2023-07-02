using System.Text.Json;
using System.Text.Json.Serialization;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CitiesStatesController : BaseApiController
    {
        private readonly DataContext _context;

        public CitiesStatesController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCitiesStates()
        {
            var cities = await _context.Cities.Include(c => c.State).ToListAsync();
            var states = await _context.States.ToListAsync();

            var response = states.Select(
                state =>
                    new StateDto
                    {
                        Id = state.Id,
                        Name = state.StateName,
                        Cities = cities
                            .Where(city => city.StateId == state.Id)
                            .Select(city => new CityDto { Id = city.Id, Name = city.CityName })
                            .ToList()
                    }
            );

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("/api/States")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _context.States.ToListAsync();
            return Ok(states);
        }

        [AllowAnonymous]
        [HttpGet("/api/Cities")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _context.Cities.ToListAsync();
            return Ok(cities);
        }

        [AllowAnonymous]
        [HttpGet("{stateId}/Cities")]
        public async Task<IActionResult> GetCitiesByState(Guid stateId)
        {
            var cities = await _context.Cities.Where(c => c.StateId == stateId).ToListAsync();
            return Ok(cities);
        }

        [AllowAnonymous]
        [HttpGet("/api/States/{stateId}")]
        public async Task<IActionResult> GetState(Guid stateId)
        {
            var state = await _context.States.FindAsync(stateId);
            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }

        [AllowAnonymous]
        [HttpGet("/api/Cities/{cityId}")]
        public async Task<IActionResult> GetCity(Guid cityId)
        {
            var city = await _context.Cities.FindAsync(cityId);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // [AllowAnonymous]
        // [HttpGet("/api/Complaints/filterByState")]
        // public async Task<IActionResult> FilterComplaintsByState(string stateName)
        // {
        //     var state = await _context.States.FirstOrDefaultAsync(s => s.StateName == stateName);

        //     if (state == null)
        //     {
        //         return NotFound("State not found.");
        //     }

        //     var complaints = await _context.Complaints
        //         .Where(c => c.StateId == state.Id)
        //         .ToListAsync();

        //     return Ok(complaints);
        // }

        // [AllowAnonymous]
        // [HttpGet("/api/Complaints/filterByCity")]
        // public async Task<IActionResult> FilterComplaintsByCity(string cityName)
        // {
        //     var city = await _context.Cities.FirstOrDefaultAsync(c => c.CityName == cityName);

        //     if (city == null)
        //     {
        //         return NotFound("City not found.");
        //     }

        //     var complaints = await _context.Complaints
        //         .Where(c => c.CityId == city.Id)
        //         .ToListAsync();

        //     return Ok(complaints);
        // }
    }
}
