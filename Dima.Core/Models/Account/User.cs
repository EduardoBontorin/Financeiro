using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dima.Core.Models.Account
{
    public class User
    {
        //v1/identity/manage/info
        //TODO: Adicionar nome do Usuario
        //TODO: Adicionar validação de email
        //TODO: Adicionar validação de senha.

        public string Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public Dictionary<string, string> Claims { get; set; } = [];
    }
}
