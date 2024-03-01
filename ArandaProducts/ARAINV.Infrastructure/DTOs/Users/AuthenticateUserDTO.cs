using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Infrastructure.DTOs.Users
{
    public class AuthenticateUserDTO
    {
        public string EmailUser { get; set; }
        public string Password { get; set; }
    }
}
