using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace QLQuanCafe.Areas.Identity.Pages.Account.Manage
{
    [Authorize(Roles = "Admin")]
    public class NewUserModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppUserRole> _roleManager;
        private readonly ILogger<NewUserModel> _logger;

        
       public NewUserModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<AppUserRole> roleManager,
            ILogger<NewUserModel> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _logger = logger;
        }
        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public string ReturnUrl { get; set; }
        public class InputModel
        {
            [Required]
            [Display(Name = "Tên người dùng")]
            public string Username { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu")]
            public string Password { get; set; }

            [Required]
            [Display(Name = "Chức vụ")]
            public string Roles { get; set; }
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("./NewUser");
            if (ModelState.IsValid)
            {
                var user = new AppUser { UserName = Input.Username, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                IdentityResult roleResult;
                bool isRoleExists = await _roleManager.RoleExistsAsync(Input.Roles);
                if (!isRoleExists)
                {
                    _logger.LogInformation("Adding role");
                    roleResult = await _roleManager.CreateAsync(new AppUserRole(Input.Roles));
                }
                // Select the user, and then add the role to the user
                if (!await _userManager.IsInRoleAsync(user, Input.Roles))
                {
                    _logger.LogInformation("Adding user to role");
                    var userResult = await _userManager.AddToRoleAsync(user, Input.Roles);
                }
                if(result.Errors == null)
                {
                    StatusMessage ="Đã tạo mới người dùng";
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    StatusMessage = "Người dùng đã tồn tại";
                }
            }
            return RedirectToPage();
        }
    }
}