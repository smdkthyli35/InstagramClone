using InstagramClone.Application.Interfaces.Repositories;
using InstagramClone.Domain.Entities;
using InstagramClone.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Persistence.Repositories
{
    public class PostImageFileRepository : GenericRepository<PostImageFile>, IPostImageFileRepository
    {
        public PostImageFileRepository(InstagramCloneDbContext context) : base(context)
        {
        }
    }
}
