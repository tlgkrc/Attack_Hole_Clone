using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObject
{
    [Serializable]
    public class LevelDatas
    {
        public List<LevelData> Datas;
    }
    
    [Serializable]
    public class LevelData
    {
        public int LevelId;
        public float LevelPassScore;
        public GameObject LevelGameObject;
    }
}