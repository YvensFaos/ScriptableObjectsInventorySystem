using System;
using UnityEngine;

namespace Utils
{
    public abstract class NamedScriptableObject : ScriptableObject
    {
        [SerializeField]
        protected string scriptableObjectName;
        public string ScriptableObjectName => scriptableObjectName;

        public override string ToString()
        {
            return scriptableObjectName;
        }

        public override bool Equals(object other)
        {
            return other != null && base.Equals(other) && scriptableObjectName == ((NamedScriptableObject) other).ScriptableObjectName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), GetInstanceID());
        }
    }
}