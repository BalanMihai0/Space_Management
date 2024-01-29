using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions
{
    public  class PasswordMatchException : Exception
    {
        public PasswordMatchException(string message):base(message) { }
    }
}
