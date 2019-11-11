using System;

namespace lr.libs.cash_machine.Exceptions
{
    public class NoteUnavailableException : ArgumentException
    {
        public NoteUnavailableException()
            : base("Note unavailable")
        {

        }
    }
}