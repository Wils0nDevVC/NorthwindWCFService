using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistense
{
    public class WebTrackerRepository : IWebTrackerRepository
    {
        private readonly NorthwindContext _context;

        public WebTrackerRepository() { }
        public WebTrackerRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task TrackWebActionAsync(WebTracker webTracker)
        {
            _context.WebTrackers.Add(webTracker);
            await _context.SaveChangesAsync();
        }
    }
}
