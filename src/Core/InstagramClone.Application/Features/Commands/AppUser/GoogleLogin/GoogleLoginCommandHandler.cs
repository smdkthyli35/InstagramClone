using InstagramClone.Application.Abstractions.Services;
using InstagramClone.Application.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.GoogleLoginAsync(request.IdToken, 15);

            return new()
            {
                Token = token
            };
        }
    }
}
