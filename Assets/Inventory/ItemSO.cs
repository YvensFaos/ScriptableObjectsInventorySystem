using System.Collections.Generic;
using Entity;
using UnityEngine;
using Utils;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item", order = 0)]
    public class ItemSO : NamedScriptableObject
    {
        [SerializeField]
        private Sprite image;
        [SerializeField, TextArea] 
        private string description;
        [SerializeField]
        private int sellPrice;
        [SerializeField] 
        private ItemTypeSO type;
        [SerializeField] 
        private List<ItemAttributeEffect> effects;

        public virtual void Use(EntityManager target)
        {
            target.UseItem(this);
        }
        
        public ItemTypeSO Type => type;
        public int SellPrice => sellPrice;
        public string Description => description;
        public Sprite Image => image;
        public List<ItemAttributeEffect> Effects => effects;
    }
}