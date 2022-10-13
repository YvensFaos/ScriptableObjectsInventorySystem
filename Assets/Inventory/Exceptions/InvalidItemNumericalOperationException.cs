using System;

namespace Inventory.Exceptions
{
    public class InvalidItemNumericalOperationException : Exception
    {
        private int count;
        public InvalidItemNumericalOperationException(int count)
        {
            this.count = count;
        }
        public int Count => count;

        public override string Message => $"Invalid Numerical Operation with an item. Value used: {Count}";
    }
}