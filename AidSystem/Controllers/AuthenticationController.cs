using AidSystemBLL.BLL.EmailServices;
using AidSystemDAL.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AidSystem.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            return await Task.Run(() => View());
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var anatoliyIdentity = new ClaimsIdentity(authClaims, "Login");

                var userPrincipal = new ClaimsPrincipal(new[] { anatoliyIdentity });

                await userManager.GetClaimsAsync(user);
                await userManager.AddClaimsAsync(user, authClaims);
                await userManager.GetLoginsAsync(user);
                await userManager.AddLoginAsync(user, new UserLoginInfo("https://localhost:7169/", "1234", "CharitySystem"));

                bool emailStatus = await userManager.IsEmailConfirmedAsync(user);
                if (emailStatus == false)
                {
                    return ViewBag.Error = "Email is unconfirmed, please confirm it first";
                }

                if (user != null)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return ViewBag.Error = "Login failed";
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return await Task.Run(() => View());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return ViewBag.Error = "This user is already registered.";

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return ViewBag.Error = "User creation failed! Please check user details and try again.";

            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var confirmationLink = Url.Action("ConfirmEmail", "Email",
                new { token, email = user.Email }, Request.Scheme);
            EmailHelper emailHelper = new EmailHelper();
            bool emailResponse = emailHelper.SendEmail(user.Email, confirmationLink);

            
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Roles.Member.ToString()));
            await roleManager.CreateAsync(new IdentityRole(UserRoles.Roles.User.ToString()));

            await userManager.AddToRoleAsync(user, UserRoles.role.ToString());

            return RedirectToAction("Index", "Home");
        }
        
    }
}
