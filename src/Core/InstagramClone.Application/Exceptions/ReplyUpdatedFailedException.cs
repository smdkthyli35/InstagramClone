using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Exceptions
{
    public class ReplyUpdatedFailedException : Exception
    {
        public ReplyUpdatedFailedException() : base("Böyle bir mesaj bulunamadı!")
        {
        }

        public ReplyUpdatedFailedException(string message) : base(message)
        {
        }

        public ReplyUpdatedFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
