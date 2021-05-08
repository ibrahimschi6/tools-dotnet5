using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet5.Tools.Domain.Model
{
    public class EmailConfiguration
    {
        public string Host { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

    }
}
