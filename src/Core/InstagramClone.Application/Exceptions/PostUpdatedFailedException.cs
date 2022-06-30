using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace InstagramClone.Application.Exceptions
{
    public class PostUpdatedFailedException : Exception
    {
        public PostUpdatedFailedException() : base("Böyle bir post bulunamadı!")
        {
        }

        public PostUpdatedFailedException(string message) : base(message)
        {
        }

        public PostUpdatedFailedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
