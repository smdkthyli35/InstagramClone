using InstagramClone.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
