using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Features.Queries.User.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public int TotalCount { get; set; }
        public object Users { get; set; }
    }
}