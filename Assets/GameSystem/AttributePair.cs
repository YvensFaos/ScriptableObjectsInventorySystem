using System;
using Utils;

namespace GameSystem
{
    [Serializable]
    public class AttributePair : Pair<float, AttributeSO>
    {
        public AttributePair(float one, AttributeSO two) : base(one, two)
        { }
    }
}