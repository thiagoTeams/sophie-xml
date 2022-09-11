using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGeneration;
using SophieXML.Units;

namespace SophieXML.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        private readonly ILogger<LoginModel> _logger;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        [TempData]
        public string ErrorMessage { get; set; }
        public string ReturnUrl { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public LoginModel(ILogger<LoginModel> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task OnGetAsync(string? returnUrl = null, string? errorMessage = null)
        {
            if (!string.IsNullOrEmpty(errorMessage))
            {
                ErrorMessage = errorMessage;
                ModelState.AddModelError(string.Empty, errorMessage.Replace("Error: ", ""));
            }
            returnUrl = returnUrl ?? Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl = "/Identity/dashboard";//returnUrl ?? Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                Logs.debug($"Login : {result}" );
                Logs.debug($"UserLogin : {System.Text.Json.JsonSerializer.Serialize(Input)}");

                if (result.Succeeded)
                {
                    var user = await _signInManager.UserManager.FindByEmailAsync(Input.Email);
                    _logger.LogInformation($"User logged in: {System.Text.Json.JsonSerializer.Serialize(user)}");

                    // Registry cookie
                    //await RegistryCookie(user);
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {
                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
                Logs.debug("Error: " + messages);
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task RegistryCookie(IdentityUser user)
        {
            List<Claim> claims = new List<Claim>();
            //claims.Add(new Claim(JwtRegisteredClaimNames.NameId, userDb.Id));
            //claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, userDb.UserName));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Email, userDb.Email));
            //claims.Add(new Claim(JwtRegisteredClaimNames.Amr, userDb.TwoFactorEnabled ? "mfa" : "pwd"));
            claims.Add(new Claim("nameid", user.Id));
            claims.Add(new Claim("unique_name", user.UserName));
            claims.Add(new Claim("email", user.Email));
            claims.Add(new Claim("amr", user.TwoFactorEnabled ? "mfa" : "pwd"));

            IList<string> listRole = await _userManager.GetRolesAsync(user);
            claims.AddRange(listRole.Select(r => new Claim("role", r)));

            ClaimsIdentity identity = new ClaimsIdentity(claims, "Cookies", "user", "role");
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(scheme: CookieAuthenticationDefaults.AuthenticationScheme, principal: principal, properties: new AuthenticationProperties
            {
                IsPersistent = true, // for 'remember me' feature
                ExpiresUtc = DateTimes.Now().AddMinutes(60)
            });
        }
    }
}
