using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Post.DeletePost
{
    public class DeletePostCommandRequest : IRequest<DeletePostCommandResponse>
    {
        public string Id { get; set; }
    }
}
