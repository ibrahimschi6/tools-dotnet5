using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet5.Tools.Domain.Model
{
    public class EmailTemplate
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
