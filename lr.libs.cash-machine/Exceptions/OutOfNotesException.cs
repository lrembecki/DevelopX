using System;

namespace lr.libs.cash_machine.Exceptions
{
    public class OutOfNotesException : ArgumentException
    {
        public OutOfNotesException()
            : base("Out of notes exception")
        {

        }
    }
}