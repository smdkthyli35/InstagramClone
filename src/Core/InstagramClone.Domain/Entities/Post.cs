using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public virtual ICollection<Reply> Replies { get; set; }
        public virtual ICollection<PostImageFile> PostImageFiles { get; set; }
    }
}
