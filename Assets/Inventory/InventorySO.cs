using System;
using System.Collections.Generic;
using System.Linq;
using Entity;
using Inventory.Exceptions;
using UnityEngine;

namespace Inventory
{
    [Serializable]
    [CreateAssetMenu(fileName = "Inventory", menuName = "Inventory/Inventory", order = 0)]
    public class InventorySO : ScriptableObject
    {
        [SerializeField] private List<ItemPair> items;

        public void AddItem(ItemSO item, int count)
        {
            if (count <= 0) throw new InvalidItemNumericalOperationException(count);

            var itemPair = GetItemPair(item);
            if (itemPair == null)
            {
                items.Add(new ItemPair(count, item));
            }
            else
            {
                itemPair.One += count;
            }
        }
        
        public void UseItem(ItemSO item, EntityManager target, int count)
        {
            if (!item.Type.Usable) throw new UnusableItemException(item);
            RemoveItem(item, count, out var foundItem);
            foundItem.Two.Use(target);
        }
        
        public int SellItem(ItemSO item, int count)
        {
            RemoveItem(item, count, out _);
            return item.SellPrice * count;
        }
        
        public void RemoveItem(ItemSO item, int count, out ItemPair foundItem)
        {
            if (count <= 0) throw new InvalidItemNumericalOperationException(count);
            
            foundItem = GetItemPair(item);
            if (foundItem == null) throw new NoItemException();
            if (foundItem.One < count) throw new NotEnoughItemException();

            foundItem.One -= count;
            if (foundItem.One == 0)
            {
                items.Remove(foundItem);
            }
        }

        public List<ItemPair> GetItemsByFilter(Func<ItemPair, bool> filter = null)
        {
            return filter == null ? items : items.Where(filter).ToList();
        }
        
        private ItemPair GetItemPair(ItemSO item)
        {
            return items.Find(itemPair => itemPair.Two.Equals(item));
        }
    }
}