using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Authentication;
using System;
using System.Linq;
using WebAPI.Core.EntityCore;
using WebAPI.Core.JWT;

namespace WebAPI.Core.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuarioController(DataContext DataContext)
        {
            _context = DataContext;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Authenticate([FromBody] Usuario model)
        {
            // Recupera o usuário
            var user = UsuarioRepository.Get(model.Username, model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = JWTService.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
                user,
                token
            };
        }

        [HttpGet]
        [Route("popular")]
        public ActionResult<dynamic> Popular(int Qtde = 1000)
        {
            var last = _context.Usuario.Count() + 1;

            for (int i = 0; i < Qtde; i++)
            {

                _context.Usuario.Add(new Usuario()
                {
                    Username = $@"Usuário {last + i}",
                    Password = "123456",
                    Role = "manager"
                });
            }

            _context.SaveChanges();

            return new { result = true };
        }

        [HttpGet]
        [Route("anonymous")]
        [AllowAnonymous]
        public string Anonymous() => "Anônimo";

        [HttpGet]
        [Route("authenticated")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - {0}", User.Identity.Name);

        [HttpGet]
        [Route("employee")]
        [Authorize(Roles = "employee,manager")]
        public string Employee() => "Funcionário";

        [HttpGet]
        [Route("manager")]
        [Authorize(Roles = "manager")]
        public string Manager() => "Gerente";
    }
}
