using InstagramClone.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetByIdUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.Users.SingleOrDefaultAsync(i => i.Id == request.Id);

            return new()
            {
                Id = user.Id,
                Email = user.Email,
                NameSurname = user.NameSurname,
                Username = user.UserName
            };
        }
    }
}
