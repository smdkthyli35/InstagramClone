using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Domain.Entities
{
    public class Profile : BaseEntity
    {
        public string UserName { get; set; }
        public string Biography { get; set; }
        public bool IsPrivate { get; set; }
        public bool Gender { get; set; }

        public virtual ICollection<ProfileImageFile> ProfileImageFiles { get; set; }
    }
}
