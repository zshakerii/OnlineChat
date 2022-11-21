using AutoMapper;
using OnlineChat.Infrastructure.Interfaces;
using OnlineChat.PersistantMain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async void SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception dbEx)
            {
            }
        }



        public IUserRepository UserRepository => new UserRepository(_context, _sieveProcessor, _mapper);


    }
}
