using AutoMapper;
using InstagramClone.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user is null)
                throw new DatabaseValidationException("Böyle bir kullanıcı bulunamadı.");

            _mapper.Map(request, user);

            var rows = await _userManager.UpdateAsync(user);

            UpdateUserCommandResponse response = new() { Succeeded = rows.Succeeded };
            if (rows.Succeeded)
                response.Message = "Kullanıcı başarıyla güncellendi.";
            else
            {
                foreach (var error in rows.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description}\n";
                }
            }

            return response;
        }
    }
}
