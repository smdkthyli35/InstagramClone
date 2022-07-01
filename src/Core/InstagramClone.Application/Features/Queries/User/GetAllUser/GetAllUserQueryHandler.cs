using InstagramClone.Application.RequestParameters.Page;
using InstagramClone.Application.ViewModels;
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

namespace InstagramClone.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllUserQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var totalUsers = _userManager.Users.ToList().Count();
            var users = await _userManager.Users.Skip(request.Page * request.Size).Take(request.Size).Select(u => new
            {
                u.Id,
                u.Email,
                u.NameSurname,
                u.UserName,
            }).ToListAsync();

            return new()
            {
                TotalCount = totalUsers,
                Users = users
            };
        }
    }
}
