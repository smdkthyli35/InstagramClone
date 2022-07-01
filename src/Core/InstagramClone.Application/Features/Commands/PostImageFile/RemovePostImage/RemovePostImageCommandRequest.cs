﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.PostImageFile.RemovePostImage
{
    public class RemovePostImageCommandRequest : IRequest<RemovePostImageCommandResponse>
    {
        public string Id { get; set; }
        public string? ImageId { get; set; }
    }
}
