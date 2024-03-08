using System;
using Data.UnityObject;
using Data.ValueObject;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        private float _asas;
        private LevelDatas _levelDatas;
        private int _attemptNumber;
        private int _levelNumber;

        #endregion

        private void Awake()
        {
            SetData();
        }
        private void SetData()
        {
            Addressables.LoadAssetAsync<CD_LevelData>("Assets/GameDatas/Data/CD_LevelData.asset").Completed +=
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        _levelDatas = asyncOperationHandle.Result.levelDatas;
                    }
                    else
                    {
                        Debug.Log("Failed");
                    }
                };
        }
        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            GameSignals.Instance.onPlay += OnPlay;
            GameSignals.Instance.onFail += OnFail;
            GameSignals.Instance.onSuccess += OnSuccess;
        }

        
        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onFail -= OnFail;
            GameSignals.Instance.onSuccess -= OnSuccess;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void OnSuccess()
        {
            //throw new NotImplementedException();
        }

        private void OnFail()
        {
           // throw new NotImplementedException();
        }

        private void OnPlay()
        {
            GameSignals.Instance.onSetLevelScoreBorder?.Invoke(_levelDatas.Datas[0].LevelPassScore);
        }
    }
}