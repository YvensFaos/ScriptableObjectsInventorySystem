using System.Collections.Generic;
using GameSystem;
using Inventory;
using UnityEngine;
using Utils;

namespace Entity
{
    [CreateAssetMenu(fileName = "Entity", menuName = "Entities/Generic Entity", order = 0)]
    public class EntitySO : NamedScriptableObject
    {
        [SerializeField]
        private int level;
        [SerializeField]
        private List<AttributeCurvePair> attributes;
        [SerializeField]
        private List<ItemTypeSO> equipmentSlots;
        
        public int Level => level;
        public List<AttributeCurvePair> Attributes => attributes;
        public List<ItemTypeSO> EquipmentSlots => equipmentSlots;
    }
}