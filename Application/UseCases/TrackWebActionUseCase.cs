using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class TrackWebActionUseCase
    {
        private readonly IWebTrackerRepository _webTrackerRepository;

        public TrackWebActionUseCase()
        {
        }

        public TrackWebActionUseCase(IWebTrackerRepository webTrackerRepository)
        {
            _webTrackerRepository = webTrackerRepository;
        }

        public async Task ExecuteAsync(string urlRequest, string sourceIp)
        {
            var webTracker = new WebTracker
            {
                URLRequest = urlRequest,
                SourceIp = sourceIp,
                TimeOfAction = DateTime.Now
            };
            await _webTrackerRepository.TrackWebActionAsync(webTracker);
        }
    }
}
