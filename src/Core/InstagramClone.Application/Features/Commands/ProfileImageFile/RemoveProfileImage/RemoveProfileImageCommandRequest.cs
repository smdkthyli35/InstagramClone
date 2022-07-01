using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.ProfileImageFile.RemoveProfileImage
{
    public class RemoveProfileImageCommandRequest : IRequest<RemoveProfileImageCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
