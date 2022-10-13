using System;

namespace Inventory.Exceptions
{
    public class InvalidEquipmentException : Exception
    {
        private ItemSO item;

        public InvalidEquipmentException(ItemSO item)
        {
            this.item = item;
        }

        public override string Message => $"Invalid equipment. Attempted to equip {item.ScriptableObjectName}.";
    }
}