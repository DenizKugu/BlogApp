using BlogApp.Data.Abstract;
using BlogApp.Entities;
using BlogApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogApp.Controllers
{
	public class UsersController:Controller
	{

        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index","Post");
            }
            return View();
        }
		public IActionResult Register()
		{
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Post");
            }
            return View();
		}
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName || x.Email == model.Email);
                if(user == null)
                {
                    _userRepository.CreateUser(new User
                    {
                        UserName = model.UserName,
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Image = "1.jpg" 
                    });
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya Email kullanımda");
                }  
            }
            return View();
        }

		public async Task<IActionResult> Logout() 
        {
            
            if (!User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Post");
            }
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [HttpPost]
		public async Task<IActionResult> Login(LoginViewsModel model)
		{
            if(ModelState.IsValid)
            {
                var isUser = _userRepository.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (isUser != null)
                {
                    var userCalims=new List<Claim>();
                    userCalims.Add(new Claim(ClaimTypes.NameIdentifier,isUser.UserId.ToString()));
                    userCalims.Add(new Claim(ClaimTypes.Name,isUser.UserName??""));
                    userCalims.Add(new Claim(ClaimTypes.GivenName,isUser.Name??""));
                    userCalims.Add(new Claim(ClaimTypes.UserData,isUser.Image??""));

                    if(isUser.Email=="pancarahmet@gmail.com")
                    {
                        userCalims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    var claimsIndentity = new ClaimsIdentity(userCalims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                    };
                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIndentity),
                        authProperties
                        );
                    return RedirectToAction("Index", "Post");
                }
				else
				{
					ModelState.AddModelError("", "Email veya Şifre hatalı");
				}
			}
            
			return View(model);
		}

        public IActionResult Profile(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            var user = _userRepository
                    .Users
                    .Include(x => x.Posts)
                    .Include(x => x.Comments)
                    .ThenInclude(x => x.Post)
                    .FirstOrDefault(x => x.UserName == username);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
	}
}
