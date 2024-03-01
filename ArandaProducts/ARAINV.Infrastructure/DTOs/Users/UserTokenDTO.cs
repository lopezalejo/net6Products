using ARAINV.Infrastructure.Wrappers;
using ARAINV.Infrastructure.DTOs.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARAINV.Infrastructure.DTOs.Users
{
    public class UserTokenDTO : IRequest<ApiResponse<UserTokenDTO>>
    {
        public int Id { get; set; }
        public string NameUser { get; set; }
        public string EmailUser { get; set; }
        public string PasswordUser { get; set; }
        public string? Token { get; set; }
    }
}
