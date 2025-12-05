using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nomina.Domain.Exceptions
{
    public class AppException : Exception
    {
        public AppException(string message, Exception inner)
            : base(message, inner) { }
    }
}
