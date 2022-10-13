using System;
using GameSystem;
using UnityEngine;
using Utils;

namespace Inventory
{
    [Serializable]
    public struct ItemAttributeEffect
    {
        [SerializeField]
        private AttributeSO attribute;
        [SerializeField]
        private MathFunction function;
        [SerializeField] 
        private float value;

        public AttributeSO Attribute => attribute;
        public MathFunction Function => function;
        public float Value => value;

        public override string ToString()
        {
            return $"{attribute.ToString()} {function.ToString()} + {value}";
        }
    }
}