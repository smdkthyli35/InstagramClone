﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Like.DeleteLike
{
    public class DeleteLikeCommandRequest : IRequest<DeleteLikeCommandResponse>
    {
        public string Id { get; set; }
    }
}
