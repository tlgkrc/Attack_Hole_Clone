using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

namespace Commands
{
    public class LevelLoaderCommand
    {
        #region Self Variables

        private readonly GameObject _levelHolder;
        private readonly LevelDatas _levelDatas;

        #endregion
        public LevelLoaderCommand(ref GameObject levelHolder,ref LevelDatas levelDatas)
        {
            _levelHolder = levelHolder;
            _levelDatas = levelDatas;
        }
        
        public void Execute(int levelID)
        {
            Object.Instantiate(_levelDatas.Datas[levelID%_levelDatas.Datas.Count].LevelGameObject,
                _levelHolder.transform);
        }
    }
}