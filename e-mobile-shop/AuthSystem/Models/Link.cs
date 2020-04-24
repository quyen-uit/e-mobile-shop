using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public string Group { get; set; }
    }
}
