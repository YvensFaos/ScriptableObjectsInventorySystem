using System;
using UnityEngine;

namespace Utils
{
    public enum MathFunction
    {
        SUM,
        SUBTRACT,
        MULTIPLY,
        DIVIDE,
        EXPONENTIAL,
        LOGARITHM
        
        
    }

    public static class MathFunctionExtension
    {
        public static float ApplyFunction(this MathFunction function, float a, float b)
        {
            return function switch
            {
                MathFunction.SUM => a + b,
                MathFunction.SUBTRACT => a - b,
                MathFunction.MULTIPLY => a * b,
                MathFunction.DIVIDE => a / b,
                MathFunction.EXPONENTIAL => Mathf.Pow(a, b),
                MathFunction.LOGARITHM => Mathf.Log(a, b),
                _ => 0.0f
            };
        }

        public static string ToString(this MathFunction function)
        {
            return function switch
            {
                MathFunction.SUM => "+",
                MathFunction.SUBTRACT => "-",
                MathFunction.MULTIPLY => "*",
                MathFunction.DIVIDE => "/",
                MathFunction.EXPONENTIAL => "exp",
                MathFunction.LOGARITHM => "log",
                _ => ""
            };
        }
    }
}