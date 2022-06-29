using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Post.CreatePost
{
    public class CreatePostCommandRequest : IRequest<CreatePostCommandResponse>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
