using System;

namespace Schooled
{
    public class ContractException : Exception
    {
        public ContractException(string message)
            : base(message)
        {
        }
    }
}