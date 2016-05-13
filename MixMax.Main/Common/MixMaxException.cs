using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MixMax.Main.Common
{
    public class MixMaxException : Exception
    {
        public MixMaxException()
        {
        }

        public MixMaxException(string message) : base(message)
        {
        }

        public MixMaxException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MixMaxException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
