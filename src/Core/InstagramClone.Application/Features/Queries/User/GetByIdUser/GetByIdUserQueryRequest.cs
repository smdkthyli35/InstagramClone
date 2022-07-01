using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.User.GetByIdUser
{
    public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
    {
        public string Id { get; set; }
    }
}