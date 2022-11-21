using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OnlineChat.Infrastructure.Interfaces;
using OnlineChat.PersistantMain;
using OnlineChat.PersistantMain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.Infrastructure.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly SieveProcessor _sieveProcessor;
        private readonly IMapper _mapper;
        public UserRepository(ApplicationDbContext context,
            Sieve sieveProcessor,
            IMapper mapper)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
            _mapper = mapper;
        }

        public async Task<User> CheckUser(string UserName)
        {
            return await _context.Users.Where(x => x.UserName == UserName).FirstOrDefaultAsync();
        }


        public async Task<User> CheckPassword(string UserName, string Password)
        {
            return await _context.Users.Where(x => x.UserName == UserName && x.Password== Password).FirstOrDefaultAsync();
        }
    }
}
