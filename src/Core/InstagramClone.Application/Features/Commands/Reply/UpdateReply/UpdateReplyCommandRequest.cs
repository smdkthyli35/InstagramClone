using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Reply.UpdateReply
{
    public class UpdateReplyCommandRequest : IRequest<UpdateReplyCommandResponse>
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Message { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
