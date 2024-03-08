using System;
using System.Collections.Generic;
using Enums;
using UnityEngine.Serialization;

namespace Data.ValueObject
{
    [Serializable]
    public class CollectableData
    {
        public CollectableType collectableType;
        public float value;
    }
}