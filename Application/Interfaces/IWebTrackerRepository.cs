using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWebTrackerRepository
    {
        Task TrackWebActionAsync(WebTracker webTracker);
    }
}
