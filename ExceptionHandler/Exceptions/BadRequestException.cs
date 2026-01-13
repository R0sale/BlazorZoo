using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandler.Exceptions
{
    public abstract class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
