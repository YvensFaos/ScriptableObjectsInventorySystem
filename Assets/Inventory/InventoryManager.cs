using System.Collections.Generic;
using Entity;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private InventorySO inventory;

        public void AddItem(ItemSO item, int count = 1)
        {
            inventory.AddItem(item, count);
        }
        
        public void UseItem(ItemSO item, EntitySO target, int count = 1)
        {
            inventory.UseItem(item, target, count);    
        }

        public void RemoveItem(ItemSO item, int count = 1)
        {
            inventory.RemoveItem(item, count, out _);
        }

        public int SellItem(ItemSO item, int count = 1)
        {
            return inventory.SellItem(item, count);
        }

        public List<ItemPair> GetItems()
        {
            return inventory.GetItemsByFilter(null);
        }

        public List<ItemPair> GetItemsOfType(ItemTypeSO type)
        {
            return inventory.GetItemsByFilter(pair => pair.Two.Type.Equals(type));
        }

        public List<ItemPair> GetUsableItems()
        {
            return inventory.GetItemsByFilter(pair => pair.Two.Type.Usable);
        }
        
        public List<ItemPair> GetEquipments()
        {
            return inventory.GetItemsByFilter(pair => pair.Two.Type.Equipment);
        }
    }
}
