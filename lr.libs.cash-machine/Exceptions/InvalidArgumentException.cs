using System;

namespace lr.libs.cash_machine.Exceptions
{
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException()
            : base("The argument is invalid")
        {

        }
    }
}