using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Domain.Entities
{
    public class ProfileImageFile : File
    {
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
