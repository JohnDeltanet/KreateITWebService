using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KreateIT.Exceptions
{
    public class CourseCreditsException : System.Exception
    {
        public CourseCreditsException() : base() { }
        public CourseCreditsException(string message) : base(message) { }
        public CourseCreditsException(string message, System.Exception inner) : base(message, inner) { }
        public CourseCreditsException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }

    public class UserEnrolException : System.Exception
    {
        public UserEnrolException() : base() { }
        public UserEnrolException(string message) : base(message) { }
        public UserEnrolException(string message, System.Exception inner) : base(message, inner) { }
        public UserEnrolException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) { }
    }
}
