using Data.ValueObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_LevelData", menuName = "Data/CD_LevelData", order = 0)]
    public class CD_LevelData : ScriptableObject
    {
        public LevelDatas levelDatas;
    }
}