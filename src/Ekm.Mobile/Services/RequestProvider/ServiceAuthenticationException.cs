using System;
using System.Collections.Generic;
using System.Text;

namespace Ekm.Mobile.Services.RequestProvider
{
    public class ServiceAuthenticationException : Exception
    {
        public string Content { get; }

        public ServiceAuthenticationException()
        {
        }

        public ServiceAuthenticationException(string content)
        {
            Content = content;
        }

        protected ServiceAuthenticationException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context)
        {
        }

        public ServiceAuthenticationException(string content, Exception innerException) : base(content, innerException)
        {
            Content = content;

            //failed to retrieve token
            //ExceptionlessClient.Default.SubmitLog("LoginAsync", ex.Message,LogLevel.Error);
        }
    }
}
