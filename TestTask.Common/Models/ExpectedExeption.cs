using System;

namespace TestTask.Common.Models
{
    public class ExpectedException : Exception
    {
        public ExpectedException(string message) : base(message)
        {
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
