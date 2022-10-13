using System;
using UnityEngine;
using Utils;

namespace GameSystem
{
    [Serializable]
    public class AttributeCurvePair : Pair<AnimationCurve, AttributeSO>
    {
        public AttributeCurvePair(AnimationCurve one, AttributeSO two) : base(one, two)
        { }

        public float EvaluateCurve(float value)
        {
            return One.Evaluate(value);
        }
    }
}