using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace NumJum2.Services.Exceptions
{
    [Serializable()]
    public class PlayerNotFoundException : ApplicationException, ISerializable
    {
        public PlayerNotFoundException() { }
        public PlayerNotFoundException(string message)
            : base(message) { }
        public PlayerNotFoundException(string message, Exception inner)
            : base(message) { }

        // For serialization
        protected PlayerNotFoundException(SerializationInfo info, StreamingContext context) { }
    }
}