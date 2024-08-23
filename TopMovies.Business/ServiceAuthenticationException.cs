﻿using System.Runtime.Serialization;

namespace TopMovies.Business
{
    [Serializable]
    public class ServiceAuthenticationException : Exception
    {
        public ServiceAuthenticationException()
        {
        }

        public ServiceAuthenticationException(string? message) : base(message)
        {
        }

        public ServiceAuthenticationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ServiceAuthenticationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}