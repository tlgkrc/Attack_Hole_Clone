using System.Collections.Generic;
using Data.ValueObject;
using Enums;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_CollectableData", menuName = "Data/CD_CollectableData", order = 0)]
    public class CD_CollectableData : ScriptableObject
    {
        public List<CollectableData> data;
    }
}