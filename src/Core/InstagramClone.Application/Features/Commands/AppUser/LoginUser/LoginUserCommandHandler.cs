﻿using InstagramClone.Application.Abstractions.Token;
using InstagramClone.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user is null)
                user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

            if (user is null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
                Dtos.Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse
                {
                    Token = token
                };
            }

            throw new AuthenticationErrorException();
        }
    }
}
