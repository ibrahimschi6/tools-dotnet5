using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet5.Tools.Domain.Exceptions
{
    public class EmailSendErrorException : Exception
    {
        public EmailSendErrorException(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
