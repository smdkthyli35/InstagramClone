using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.PostImageFile.UploadPostImage
{
    public class UploadPostImageCommandRequest : IRequest<UploadPostImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }
    }
}
