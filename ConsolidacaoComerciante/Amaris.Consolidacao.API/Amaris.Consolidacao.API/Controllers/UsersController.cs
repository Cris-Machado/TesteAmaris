using Amaris.Consolidacao.Identity.Dtos;
using Amaris.Consolidacao.Identity.Entities;
using Amaris.Consolidacao.Service.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PointNow.API.Presentation.Controllers.Base;

namespace Amaris.Consolidacao.API.Controllers
{
    public class UsersController : BaseController
    {

        private readonly IUsersService _userService;
        private readonly UserManager<AppUser> _userManager;

        public UsersController(IUsersService userService, UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        #region Methods

        [HttpGet]
        [Route("get-all")]
        [AllowAnonymous]
        public async Task<ActionResult> GetAll()
        {
            var result = await _userService.FindAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("create-user")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] User model)
        {
            var result = await _userService.CreateUserAsync(model);
            return Ok(result);
        }
        #endregion
    }
}
