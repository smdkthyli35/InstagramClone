using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Domain.Entities
{
    public class Follow : BaseEntity
    {
        public int FollowerCount { get; set; }
        public int FollowedCount { get; set; }
    }
}
