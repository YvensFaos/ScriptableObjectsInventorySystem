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

        private void Awake()
        {
            RecalculateAttributes();
        }

        private void RecalculateAttributes()
        {
            currentAttributePairs = new List<AttributePair>();
            entitySo.Attributes.ForEach(attribute =>
            {
                currentAttributePairs.Add(new AttributePair(attribute.EvaluateCurve(currentLevel), attribute.Two));
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

        public void CauseEffectToAttribute(ItemAttributeEffect effect)
        {
            var currentEntityPair = currentAttributePairs.Find(pair => pair.Two.Equals(effect.Attribute));
            if (currentEntityPair == null) return;
            if (effect.Attribute.Overflow)
            {
                currentEntityPair.One = effect.ExecuteEffect(currentEntityPair.One);
            }
            else
            {
                var levelPair = entitySo.Attributes.Find(pair => pair.Two.Equals(effect.Attribute));
                var currentMax = levelPair.EvaluateCurve(currentLevel);
                currentEntityPair.One = Mathf.Min(effect.ExecuteEffect(currentEntityPair.One), currentMax);
            }
        }

        public void UseItem(ItemSO item)
        {
            item.Effects.ForEach(CauseEffectToAttribute);
        }
    }
}