using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class Trackingaction
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string MaSp { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime? Ngaythuchien { get; set; }
    }
}
