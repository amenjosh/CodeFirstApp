using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeFirstApp.ViewModel;
using CodeFirstApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CodeFirstApp.Services.Interface;

namespace CodeFirstApp.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticateResult>> Authenticate([FromBody]AuthenticateVm authenticateVm)
        {
            var authUser = await _authService.AuthenticateAsync(authenticateVm.UserName, authenticateVm.Password);

            if (authUser == null) throw new Exception("User is unauthorized or credential does not match");

            return new JsonResult(_authService.GetToken(authUser.FirstOrDefault()));
        }
    }
}