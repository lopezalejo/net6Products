using ARAINV.Infrastructure.Common.Features;
using ARAINV.Infrastructure.DTOs.Users;
using ARAINV.Infrastructure.Persistence.Interfaces.Service;
using ARAINV.Infrastructure.Wrappers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ARAINV.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJWTService _jwtService;
        internal readonly IMapper _mapper;

        public AuthController(IUserService userService, IJWTService jWTService, IMapper mapper)
        {
            _userService = userService;
            _jwtService = jWTService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUserDTO authenticate)
        {
            var valid = await _userService.FilterUserAsync(
                              us => us.EmailUser == authenticate.EmailUser && us.PasswordUser == EncriptDecriptExtensions.Hash(EncriptDecriptExtensions.Base64Decode(authenticate.Password)));

            if (valid is not null)
            {
                var user = valid.FirstOrDefault();

                var token = _jwtService.GenerarToken(user);
                var responseUSer = new UserTokenDTO()
                {
                    Id = user.Id,
                    NameUser = user.NameUser,
                    EmailUser = user.EmailUser,
                    PasswordUser = user.PasswordUser,
                    Token = token
                };

                var response = new ApiResponse<UserTokenDTO>(responseUSer, $"Se genera correctamente el token de autenticación.");

                return Ok(response);

            }

            return BadRequest(" ss:  " + authenticate?.EmailUser);
        }
    }
}
