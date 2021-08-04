using Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    [Route("api")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificador notificador, SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager) : base(notificador)
        {
            _signManager = signInManager;
            _userManager = userManager;
        }

        /// <summary>
        /// Cria Nova Conta
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            if (result.Succeeded)
            {
                await _signManager.SignInAsync(user, false);
                return CustomResponse(registerUser);
            }

            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }


            return CustomResponse(registerUser);
        }

        /// <summary>
        /// Realiza Login
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(loginUser);
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamnete bloqueado por tentativas inválidas");
                return CustomResponse(loginUser);
            }

            NotificarErro("Usuário ou senha incorretos");
            return CustomResponse(loginUser);
        }
    }
}
