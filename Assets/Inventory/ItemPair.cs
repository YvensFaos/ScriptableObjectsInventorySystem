using System;
using Utils;

namespace Inventory
{
    [Serializable]
    public class ItemPair : Pair<int, ItemSO>
    {
        public ItemPair(int one, ItemSO two) : base(one, two)
        { }

        public override string ToString()
        {
            return $"{Two.ScriptableObjectName} x{One}";
        }
    }
}