using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital.Exception
{
    class InvalidEmailException : System.Exception
    {
        public InvalidEmailException()
        {

        }

        public InvalidEmailException(string message) : base(message)
        {

        }

        public InvalidEmailException(string message, System.Exception inner) : base(message, inner)
        {

        }
    }
}
