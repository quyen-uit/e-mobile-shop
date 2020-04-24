using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class Oauth
    {
        public string Id { get; set; }
        public string ConsumerKey { get; set; }
        public string Callback { get; set; }
        public string RequestToken { get; set; }
        public string VerifierToken { get; set; }
        public DateTime? DateComsumer { get; set; }
        public string MaNcc { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiresTime { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
    }
}
