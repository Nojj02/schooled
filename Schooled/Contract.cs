using System;

namespace Schooled
{
    public static class Contract
    {
        public static void Requires(bool condition, string failureMessage = null)
        {
            if (!condition)
            {
                throw new ContractException(failureMessage ?? "Contract failed");
            }
        }
    }
}