using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using e_mobile_shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using e_mobile_shop.Models;
using Newtonsoft.Json;

namespace e_mobile_shop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private  readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name ="Username")]
            [DataType(DataType.Text)]
            public string Username { get; set; }

            [Display(Name ="Họ và tên")]
            [DataType(DataType.Text)]
            public string HoTen { get; set; }

            [Display(Name ="Ngày sinh")]
            [DataType(DataType.DateTime)]
            public DateTime NgaySinh { get; set; }

            [Display(Name = "Giới tính")]
            public int GioiTinh { get; set; }

            [Display(Name = "Avatar")]
            [DataType(DataType.Text)]
            public string Avatar { get; set; }

            [Display(Name = "Số CMND")]
            [DataType(DataType.Text)]
            public string CMND { get; set; }

            [Display(Name ="Số điện thoại")]
            [DataType(DataType.Text)]
            public string SDT { get; set; }

            [Display(Name = "Địa chỉ")]
            [DataType(DataType.Text)]
            public string DiaChi { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }



            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new AppUser { 
                    HoTen = Input.HoTen,
                    UserName = Input.Username, 
                    Email = Input.Email,
                    NgaySinh =Input.NgaySinh,
                    CMND =Input.CMND,
                    Avatar =Input.Avatar,
                    GioiTinh=Input.GioiTinh,
                    DiaChi=Input.DiaChi
                };

                string content = System.IO.File.ReadAllText("RegisterEmail.html");
                content = content.Replace("{{Hoten}}", user.HoTen);
                content = content.Replace("{{username}}", user.UserName);
                content = content.Replace("{{phone}}", user.PhoneNumber);
                content = content.Replace("{{email}}", user.Email);
                content = content.Replace("{{address}}", user.DiaChi);
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    AspNetUserRoles userrole = new AspNetUserRoles()
                    {
                        RoleId = DataAccess.context.AspNetRoles.Where(x => x.Name == "Khách hàng").FirstOrDefault().Id,
                        UserId = user.Id
                    };
                     DataAccess.context.AspNetUserRoles.Add(userrole);
                    DataAccess.context.SaveChanges();
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page("/Account/ConfirmEmail", pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    content = content.Replace("{{callbackurl}}", $"Vui lòng xác nhận tài khoản bằng cách <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>nhấn vào đây </a>.");

                    await _emailSender.SendEmailAsync(Input.Email, "Email thông tin tài khoản ", $"{System.Net.WebUtility.HtmlDecode(content)}");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }

                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        public JsonResult District_Bind(int provinceId)
        {
            var listDistrict = DataAccess.context.District.Where(x => x.ProvinceId == provinceId).ToList();
            return JsonConvert.SerializeObject(listDistrict);
        }


        public IActionResult Ward_Bind(int districtId)
        {
            var listWard = DataAccess.context.Ward.Where(x => x.DistrictId == districtId).ToList();
            return Json(listWard);
        }
    }
}
