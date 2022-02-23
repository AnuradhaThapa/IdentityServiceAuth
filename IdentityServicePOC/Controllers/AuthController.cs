using IdentityService.Core.Entities;
using IdentityService.Core.Interfaces;
using IdentityService.Infrastructure.JWT;
using IdentityService.Infrastructure.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentityService.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtFactory _jwtFactory;

   
        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtFactory = jwtFactory;
        }


        [ProducesResponseType(typeof(string), 400)]
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] CredentialsModelEntity credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ////Adding Admin Role
            //IdentityResult roleResult;
            //var roleCheck = await _roleManager.RoleExistsAsync("Admin");
            //if (!roleCheck)
            //{
            //    //create the roles and seed them to the database
            //    roleResult = await _roleManager.CreateAsync(new IdentityRole("Client"));
            //    roleResult = await _roleManager.CreateAsync(new IdentityRole("Agent"));
            //    roleResult = await _roleManager.CreateAsync(new IdentityRole("Admin"));
            //}
            //var user = new ApplicationUser { UserName = credentials.UserName, Email = "annu@123.com" ,UserId="UR1234"};
            //await _userManager.CreateAsync(user, "Anu@123");
            //await _userManager.AddToRoleAsync(user, "Admin");
            ////Adding Admin Role

            var identity = await GetIdentityUser(credentials.UserName, credentials.Password);
            if (identity == null)
            {
                return BadRequest(ModelState);
            }
            
            var jwt = await Tokens.GenerateJwtResponse(_jwtFactory, identity, new JsonSerializerSettings { Formatting = Formatting.Indented });
            dynamic data = JObject.Parse(jwt);
            string token = data.auth_token;
            HttpContext.Session.SetString("Token", token);
            return Ok(jwt);
        }

        private async Task<ClaimsModelEntity> GetIdentityUser(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsModelEntity>(null);

            // get the user to verifty
            var userToVerify = await _userManager.FindByNameAsync(userName);

            if (userToVerify == null) return await Task.FromResult<ClaimsModelEntity>(null);

            // check the credentials
            if (await _userManager.CheckPasswordAsync(userToVerify, password))
            {
                var role = await _userManager.GetRolesAsync(userToVerify);
                return new ClaimsModelEntity{ 
                Id=userToVerify.Id,
                UserName=userToVerify.UserName,
                UserId = userToVerify.UserId,
                RoleType = role[0]
                };
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsModelEntity>(null);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDetailsEntity userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = new ApplicationUser { UserName = userViewModel.UserName, Email = userViewModel.Email,UserId=userViewModel.UserId };
            var userCreated = await _userManager.CreateAsync(user, userViewModel.Password);
            var roleCheck = await _roleManager.RoleExistsAsync(userViewModel.RoleType);
            if (roleCheck && userCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userViewModel.RoleType);
                return Ok("Created");
            }
            else if(userCreated.Errors.Count() > 0)
            {
                var error = userCreated.Errors.Select(x=>x.Description).FirstOrDefault();
                return BadRequest(error);
            }
            else
                return BadRequest("Error");
        }

            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(typeof(string), 400)]
        [HttpGet("getData")]
        public async Task<IActionResult> GetData(string username)
        {
            var data = await _userManager.FindByNameAsync(username);
            return Ok(data);
        }
    }
}
