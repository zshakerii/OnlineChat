using Azure.Core;
using OnlineChat.PersistantMain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CheckUser(string UserName);
        Task<User> CheckPassword(string UserName, string Password);

    }
}
