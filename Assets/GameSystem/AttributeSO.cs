using UnityEngine;
using Utils;

namespace GameSystem
{
    [CreateAssetMenu(fileName = "Attribute", menuName = "System/Attribute", order = 0)]
    public class AttributeSO : NamedScriptableObject
    {
        [SerializeField]
        private bool overflow;
        public bool Overflow => overflow;
    }
}