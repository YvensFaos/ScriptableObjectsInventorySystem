using System;

namespace Inventory.Exceptions
{
    public class UnusableItemException : Exception
    {
        private ItemSO item;
        public UnusableItemException(ItemSO item)
        {
            this.item = item;
        }
        public ItemSO Item => item;
    }
}