using MediatR;
using OnlineChat.Api.Core.Commands.Auth.Login;
using OnlineChat.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineChat.Api.Core.Handlers.Auth
{
    public  class LoginHandler: IRequestHandler<LoginCommand,bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LoginHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            //بررسی اینکه این کاربر وجود دارد 
            //بررسی اینکه این کاربر پسورد درست را وارد کرده است 
            //توکن جدید به کاربر اختصاص داده شود 
            //Microsoft.AspNetCore.Identity.IdentityResult SignUpStatus;
            //SignUpStatus = await _applicationUserManager.SignUp(signUpviewModel);
            if (true/*SignUpStatus == IdentityResult.Success*/)
            {
                //Microsoft.AspNetCore.Identity.SignInResult Status;
                var IsUser = await _unitOfWork.UserRepository.CheckUser(request.UserName);

                if (IsUser != null)
                {
                    var Status = await _unitOfWork.UserRepository.CheckPassword(request.UserName, request.Password);
                    if (Status!=null)
                    {
                        return false;
                    }
                    else { return true; }
                }
                else
                {
                    //Status = Microsoft.AspNetCore.Identity.SignInResult.Failed;
                    return false;
                }
            }
            return false;
        }
    }
}
