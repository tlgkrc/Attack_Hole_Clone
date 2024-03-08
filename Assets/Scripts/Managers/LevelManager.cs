using System;
using Cysharp.Threading.Tasks;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        private LevelDatas _levelDatas;
        private int _attemptNumber;
        private int _levelNumber;
        private int _currentLevel;

        #endregion

        private void Awake()
        {
            SetData();
            _currentLevel = 0;
            _attemptNumber = 1;
            
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
            GameSignals.Instance.onLevelFinish += OnLevelFinish;
            GameSignals.Instance.onFail += OnFail;
            GameSignals.Instance.onSuccess += OnSuccess;
        }

        
        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onLevelFinish -= OnLevelFinish;
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
            _attemptNumber = 1;
            _currentLevel++;
            GameSignals.Instance.onSetAttemptText?.Invoke(_attemptNumber);
            GameSignals.Instance.onSetLevelText?.Invoke(_currentLevel+1);
        }

        private void OnFail()
        {
            _attemptNumber++;
            GameSignals.Instance.onSetAttemptText?.Invoke(_attemptNumber);
        }

        private void OnPlay()
        {
            GameSignals.Instance.onSetLevelScoreBorder?.Invoke(_levelDatas.Datas[0].LevelPassScore);
            GameSignals.Instance.onSetAttemptText?.Invoke(_attemptNumber);
            GameSignals.Instance.onSetLevelText?.Invoke(_currentLevel+1);
            
        }

        private void OnLevelFinish()
        {
            var currentScore = GameSignals.Instance.onGetCurrentScore?.Invoke();
            FinisLevel(currentScore);
            
        }

        private async UniTask FinisLevel(float? currentScore)
        {
            GameSignals.Instance.onSetCameraState?.Invoke(CameraStates.LevelEndCam);
            await UniTask.Delay(1500);
            if (currentScore < _levelDatas.Datas[_currentLevel].LevelPassScore)
            {
                GameSignals.Instance.onFail?.Invoke();
            }
            else
            {
                GameSignals.Instance.onSuccess?.Invoke();
            }
        }
    }
}