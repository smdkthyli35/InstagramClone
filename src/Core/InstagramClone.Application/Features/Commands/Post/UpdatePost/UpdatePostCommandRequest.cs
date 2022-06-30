using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Commands.Post.UpdatePost
{
    public class UpdatePostCommandRequest : IRequest<UpdatePostCommandResponse>
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
