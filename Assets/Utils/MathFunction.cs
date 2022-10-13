using System;
using UnityEngine;

namespace Utils
{
    public enum MathFunction
    {
        Sum,
        Subtract,
        Multiply,
        Divide,
        Exponential,
        Logarithm
    }

    public static class MathFunctionExtension
    {
        public static float ApplyFunction(this MathFunction function, float a, float b)
        {
            return function switch
            {
                MathFunction.Sum => a + b,
                MathFunction.Subtract => a - b,
                MathFunction.Multiply => a * b,
                MathFunction.Divide => a / b,
                MathFunction.Exponential => Mathf.Pow(a, b),
                MathFunction.Logarithm => Mathf.Log(a, b),
                _ => 0.0f
            };
        }
        
        public static float ApplyInverseFunction(this MathFunction function, float a, float b)
        {
            return function switch
            {
                MathFunction.Sum => a - b,
                MathFunction.Subtract => a + b,
                MathFunction.Multiply => a / b,
                MathFunction.Divide => a * b,
                MathFunction.Exponential => Mathf.Pow(a, 1.0f/b),
                MathFunction.Logarithm => Mathf.Pow(a, b),
                _ => 0.0f
            };
        }

        public static string ToString(this MathFunction function)
        {
            return function switch
            {
                MathFunction.Sum => "+",
                MathFunction.Subtract => "-",
                MathFunction.Multiply => "*",
                MathFunction.Divide => "/",
                MathFunction.Exponential => "exp",
                MathFunction.Logarithm => "log",
                _ => ""
            };
        }
    }
}