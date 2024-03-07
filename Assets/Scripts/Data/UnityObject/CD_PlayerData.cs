﻿using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_PlayerData", menuName = "Data", order = 0)]
    public class CD_PlayerData : ScriptableObject
    {
        public PlayerData Data;
    }
}