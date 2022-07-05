using InstagramClone.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.Post.SearchByPost
{
    public class SearchByPostQueryRequest : IRequest<List<SearchPostViewModel>>
    {
        public string SearchText { get; set; }

        public SearchByPostQueryRequest()
        {
        }

        public SearchByPostQueryRequest(string searchText)
        {
            SearchText = searchText;
        }
    }
}
