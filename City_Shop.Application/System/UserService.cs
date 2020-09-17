using City_Shop.Data.Entities;
using City_Shop.ViewModel.Common;
using City_Shop.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace City_Shop.Application.System
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IConfiguration config)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            // Check Username
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null) return null;
            // Check Password
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, request.Rememberme, true);

            if (!result.Succeeded) { return null; }

            var roles = _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Role, string.Join(";", roles)),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<PagedResult<UserViewModel>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x =>
                x.UserName.Contains(request.Keyword) ||
                x.Email.Contains(request.Keyword) || 
                x.PhoneNumber.Contains(request.Keyword)
                );
            }

            // PAGING
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.PhoneNumber,
                    Dob = x.Dob,
                    Username = x.UserName,
                }).ToListAsync();

            // SELECT AND PROJECTION
            var pagedResult = new PagedResult<UserViewModel>()
            {
                TotalRecord = totalRow,
                Items = data,
            };

            return pagedResult;
        }

        public async Task<bool> Register(RegisterRequest request)
        {
            var user = new AppUser()
            {
                Dob = request.Dob,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                Email = request.Email,
                PhoneNumber = request.Phone,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
    }
}
