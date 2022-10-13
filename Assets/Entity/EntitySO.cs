using System.Collections.Generic;
using GameSystem;
using UnityEngine;
using Utils;

namespace Entity
{
    [CreateAssetMenu(fileName = "Entity", menuName = "Entities/Generic Entity", order = 0)]
    public class EntitySO : NamedScriptableObject
    {
        [SerializeField]
        private List<AttributePair> attributes;

        public List<AttributePair> Attributes => attributes;
    }
}