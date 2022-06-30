﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Reply.DeleteReply
{
    public class DeleteReplyCommandRequest : IRequest<DeleteReplyCommandResponse>
    {
        public string Id { get; set; }
    }
}
