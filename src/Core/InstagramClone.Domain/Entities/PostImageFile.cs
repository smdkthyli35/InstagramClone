﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Domain.Entities
{
    public class PostImageFile : File
    {
        public virtual ICollection<Post> Posts { get; set; }
    }
}
