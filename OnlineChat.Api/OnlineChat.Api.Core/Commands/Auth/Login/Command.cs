using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.Api.Core.Commands.Auth.Login
{
   
    public class LoginCommand:IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
