using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Domain.Entities
{
    public class Reply : BaseEntity
    {
        public Post PostId { get; set; }
        public Post Post { get; set; }

        public string Message { get; set; }
    }
}
