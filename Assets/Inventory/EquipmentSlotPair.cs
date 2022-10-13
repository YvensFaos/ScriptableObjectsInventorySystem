using System;
using Inventory.Exceptions;
using Utils;

namespace Inventory
{
    [Serializable]
    public class EquipmentSlotPair : Pair<ItemTypeSO, ItemSO>
    {
        public EquipmentSlotPair(ItemTypeSO one, ItemSO two) : base(one, two)
        { }

        public bool IsEmpty() => Two == null;
        public void Unequip() => Two = null;

        public void Equip(ItemSO equipemnt)
        {
            if (equipemnt.Type.Equipment)
            {
                Two = equipemnt;    
            }
            else
            {
                throw new InvalidEquipmentException(equipemnt);
            }
        } 
    }
}