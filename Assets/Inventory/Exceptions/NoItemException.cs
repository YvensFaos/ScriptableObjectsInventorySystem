using System;

namespace Inventory.Exceptions
{
    public class NoItemException : Exception
    {
        public override string Message => $"Item not found.";
    }
}