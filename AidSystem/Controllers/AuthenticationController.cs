using AidSystemBLL.BLL.EmailServices;
using AidSystemDAL.Models.Authentication;
using Microsoft.AspNetCore.Authentication;
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
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var anatoliyIdentity = new ClaimsIdentity(authClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { anatoliyIdentity });

                bool emailStatus = await userManager.IsEmailConfirmedAsync(user);
                if (emailStatus == false)
                {
                    return ViewBag.Error = "Email is unconfirmed, please confirm it first";
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                new JwtSecurityTokenHandler().WriteToken(token);
                var expiration = token.ValidTo;
                var Name = user.UserName;

                if (token != null)
                {
                    await HttpContext.SignInAsync(userPrincipal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return ViewBag.Error = "Login failed";
                }
                //await HttpContext.SignInAsync(userPrincipal);
                //return RedirectToAction("Index", "Home");
                //return Ok(new
                //{
                //    token = new JwtSecurityTokenHandler().WriteToken(token),
                //    expiration = token.ValidTo,
                //    Name = user.UserName
                //});
                //HttpContext.SignInAsync(userPrincipal);

                //return RedirectToAction("Index", "Home");
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

            
            if (!await roleManager.RoleExistsAsync(UserRoles.Member))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Member));

            await userManager.AddToRoleAsync(user, "Member");

            return RedirectToAction("Index", "Home");
        }
        
    }
}
