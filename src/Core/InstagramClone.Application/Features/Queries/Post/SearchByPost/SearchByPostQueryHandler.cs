using InstagramClone.Application.Interfaces.Repositories;
using InstagramClone.Application.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Post.SearchByPost
{
    public class SearchByPostQueryHandler : IRequestHandler<SearchByPostQueryRequest, List<SearchPostViewModel>>
    {
        private readonly IPostRepository _postRepository;

        public SearchByPostQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<List<SearchPostViewModel>> Handle(SearchByPostQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _postRepository
                .GetWhere(i => EF.Functions.Like(i.Description, $"{request.SearchText}%"))
                .Select(i => new SearchPostViewModel()
                {
                    Id = i.Id,
                    Description = i.Description
                });

            return await result.ToListAsync();
        }
    }
}
