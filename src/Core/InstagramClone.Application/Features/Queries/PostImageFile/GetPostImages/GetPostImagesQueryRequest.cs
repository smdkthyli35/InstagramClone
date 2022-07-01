using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.PostImageFile.GetPostImages
{
    public class GetPostImagesQueryRequest : IRequest<List<GetPostImagesQueryResponse>>
    {
        public string Id { get; set; }
    }
}
