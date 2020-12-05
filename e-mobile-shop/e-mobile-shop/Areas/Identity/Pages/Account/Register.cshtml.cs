using e_mobile_shop.Areas.Identity.Data;
using e_mobile_shop.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;


namespace e_mobile_shop.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
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
            [Required(ErrorMessage = "Username không được để trống")]
            [Display(Name = "Username")]
            [DataType(DataType.Text)]
            public string Username { get; set; }

            [Display(Name = "Họ và tên")]
            [Required(ErrorMessage = "Họ và tên không được để trống")]
            [DataType(DataType.Text)]
            public string HoTen { get; set; }

            [Display(Name = "Ngày sinh")]
            [Required(ErrorMessage = "Chọn ngày sinh")]
            [DataType(DataType.DateTime)]
            public DateTime NgaySinh { get; set; }

            [Display(Name = "Giới tính")]
            public int GioiTinh { get; set; }

            [Display(Name = "Avatar")]
            [DataType(DataType.Text)]
            public string Avatar { get; set; }

            [Display(Name = "Số CMND")]
            [StringLength(14, ErrorMessage = "CMND phải có 9 tới 12 số.", MinimumLength = 11)]
            [DataType(DataType.Text)]
            public string CMND { get; set; }

            [Display(Name = "Số điện thoại")]
            [StringLength(12, ErrorMessage = "Số điện thoại phải có {0} tới {1} số.", MinimumLength = 10)]
            [DataType(DataType.Text)]
            public string SDT { get; set; }

            [Required(ErrorMessage = "Địa chỉ không được để trống")]
            [Display(Name = "Địa chỉ")]
            [DataType(DataType.Text)]
            public string DiaChi { get; set; }

            [Required(ErrorMessage = "Email không được để trống")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }



            [Required(ErrorMessage = "Mật khẩu không để trống")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Vui lòng chọn tỉnh/thành phố")]
            public int TinhThanh { get; set; }
            [Required(ErrorMessage = "Vui lòng chọn Quận/huyện")]
            public int QuanHuyen { get; set; }
            [Required(ErrorMessage = "Vui lòng chọn xã phường")]
            public int XaPhuong { get; set; }

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
            using (var context = new ClientDbContext())
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser
                    {
                        HoTen = Input.HoTen,
                        UserName = Input.Username,
                        Email = Input.Email,
                        NgaySinh = Input.NgaySinh,
                        CMND = Input.CMND,
                        Avatar = Input.Avatar,
                        PhoneNumber = Input.SDT,
                        GioiTinh = Input.GioiTinh,
                        DiaChi = Input.DiaChi + ","
                        + context.Ward.Find(Input.XaPhuong).Name + ","
                        + context.District.Find(Input.QuanHuyen).Name
                        + "," + context.Province.Find(Input.TinhThanh).Name
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
                            RoleId = context.AspNetRoles.FirstOrDefault(x => x.Name == "Khách hàng")?.Id,
                            UserId = user.Id
                        };
                        context.AspNetUserRoles.Add(userrole);
                        context.SaveChanges();
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

            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


    }
}
