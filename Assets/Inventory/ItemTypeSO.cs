using UnityEngine;
using Utils;

namespace Inventory
{
    [CreateAssetMenu(fileName = "Item Type", menuName = "Inventory/Item Type", order = 0)]
    public class ItemTypeSO : NamedScriptableObject
    {
        [SerializeField]
        private bool usable;
        [SerializeField]
        private bool equipment;
        public bool Usable => usable;
        public bool Equipment => equipment;
    }
}