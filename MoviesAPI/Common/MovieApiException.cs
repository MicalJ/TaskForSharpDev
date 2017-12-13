using System;
using System.Runtime.Serialization;

namespace MoviesAPI.Common
{
    [Serializable]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class MovieApiException : Exception
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public MovieApiException()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public MovieApiException(string message) : base(message)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public MovieApiException(string message, Exception inner) : base(message, inner)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected MovieApiException(
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
