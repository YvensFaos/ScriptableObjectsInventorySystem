using System.Collections.Generic;
using GameSystem;
using Inventory;
using UnityEngine;

namespace Entity
{
    public class EntityManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private EntitySO entitySo;

        [Header("Entity Data")] 
        [SerializeField]
        private int currentLevel;
        [SerializeField]
        private List<AttributePair> currentAttributePairs;
        [SerializeField]
        private List<EquipmentSlotPair> equippedItems;
        
        private void Awake()
        {
            RecalculateAttributes();
            equippedItems = new List<EquipmentSlotPair>();
            entitySo.EquipmentSlots.ForEach(slot =>
            {
                //No item is represented by null
                EquippedItems.Add(new EquipmentSlotPair(slot, null));
            });
        }

        private void RecalculateAttributes()
        {
            currentAttributePairs = new List<AttributePair>();
            entitySo.Attributes.ForEach(attribute =>
            {
                var levelAttribute = attribute.EvaluateCurve(currentLevel);
                //Calculate equipment influence
                
                currentAttributePairs.Add(new AttributePair(levelAttribute, attribute.Two));
            });
        }

        public void LevelUp(bool heal = false)
        {
            ++currentLevel;
            if (heal)
            {
                RecalculateAttributes();
            }
        }

        public void CauseEffectToAttribute(ItemAttributeEffect effect, bool undoEffect = false)
        {
            var currentEntityPair = currentAttributePairs.Find(pair => pair.Two.Equals(effect.Attribute));
            if (currentEntityPair == null) return;
            if (effect.Attribute.Overflow && !undoEffect)
            {
                currentEntityPair.One = effect.ExecuteEffect(currentEntityPair.One);
            }
            else
            {
                var levelPair = entitySo.Attributes.Find(pair => pair.Two.Equals(effect.Attribute));
                var currentMax = levelPair.EvaluateCurve(currentLevel);
                currentEntityPair.One = Mathf.Clamp(effect.ExecuteEffect(currentEntityPair.One, undoEffect), 0.0f, currentMax);
            }
        }

        public void UseItem(ItemSO item)
        {
            item.Effects.ForEach(effect => CauseEffectToAttribute(effect));
        }

        public bool EquipItem(ItemSO item)
        {
            var availableSlots = equippedItems.Find(slot => slot.One.Equals(item.Type) && slot.IsEmpty());
            if (availableSlots == null) return false;
            availableSlots.Equip(item);
            item.Effects.ForEach(effect => CauseEffectToAttribute(effect));
            return true;
        }

        public bool UnequipItem(ItemSO item)
        {
            var equippedSlot = equippedItems.Find(slot => slot.Two.Equals(item));
            if (equippedSlot == null) return false;
            equippedSlot.Unequip();
            item.Effects.ForEach(effect => CauseEffectToAttribute(effect, true));
            return true;
        }
        
        public List<EquipmentSlotPair> EquippedItems => equippedItems;
    }
}