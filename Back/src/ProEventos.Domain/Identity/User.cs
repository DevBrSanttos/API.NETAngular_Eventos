using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ProEventos.Domain.Enum;

namespace ProEventos.Domain.Identity
{
    public class User : IdentityUser<int>
    {
        public string primeiroNome { get; set; }
        public string ultimoNome { get; set; }
        public Titulo titulo { get; set; }
        public string descricao { get; set; }
        public Funcao funcao { get; set; }
        public string imagemURL { get; set; }
        public IEnumerable<UserRole> userRoles { get; set; }

    }
}