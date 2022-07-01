using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.ProfileImageFile.GetProfileImages
{
    public class GetProfileImagesQueryRequest : IRequest<List<GetProfileImagesQueryResponse>>
    {
        public string Id { get; set; }
    }
}
