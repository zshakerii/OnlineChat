using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        void SaveAsync();
        IUserRepository UserRepository { get; }
    }
}
