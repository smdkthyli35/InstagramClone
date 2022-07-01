using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.AppUser.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult identityResult = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                Email = request.Email,
                NameSurname = request.NameSurname,
                UserName = request.Username
            }, request.Password);

            CreateUserCommandResponse response = new() { Succeeded = identityResult.Succeeded };

            if (identityResult.Succeeded)
                response.Message = "Kullanıcı başarıyla oluşturuldu.";
            else
            {
                foreach (var error in identityResult.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }

            return response;
        }
    }
}
