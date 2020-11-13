using Models.Authentication;
using System.Linq;
using System.Collections.Generic;

namespace WebAPI.Core.Authentication
{
    public class UsuarioRepository
    {
        public static Usuario Get(string username, string password)
        {
            var users = new List<Usuario>
            {
                new Usuario { Id = 1, Username = "batman", Password = "batman", Role = "manager" },
                new Usuario { Id = 2, Username = "robin", Password = "robin", Role = "employee" }
            };

            return users.Where(x => x.Username.ToLower() == username.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}
