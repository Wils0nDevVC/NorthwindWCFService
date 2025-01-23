using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class WebTracker
    {
        public int Id { get; set; }
        public string URLRequest { get; set; }
        public string SourceIp { get; set; }
        public DateTime TimeOfAction { get; set; }
    }
}
