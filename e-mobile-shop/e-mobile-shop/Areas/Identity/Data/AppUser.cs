using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace e_mobile_shop.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the AppUser class
    public class AppUser : IdentityUser
    {


        [PersonalData]
        [Column(TypeName = "nvarchar(20)")]
        public string? CMND { get; set; }

        [PersonalData]
        [Column(TypeName ="nvarchar(100)")]
        public string? HoTen { get; set; }

        [PersonalData]
        [Column(TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [PersonalData]
        [Column(TypeName = "int")]
        public int? GioiTinh { get; set; }
        [PersonalData]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? DiaChi { get; set; }
        [PersonalData]
        [Column(TypeName = "text")]
        public string? Avatar { get; set; }
    }
}
