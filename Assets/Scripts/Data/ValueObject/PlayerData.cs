using System;
using UnityEngine.Serialization;

namespace Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public float moveFactor;
        public PhysicData physicData;
        public HoleData holeData;
    }
    [Serializable]
    public class PhysicData
    {
        public string noColliderLayer;
        public string defaultLayer;
    }

    [Serializable]
    public class HoleData
    {
        public int scaleUpBorder;
        public int increaseAmount;
    }
}