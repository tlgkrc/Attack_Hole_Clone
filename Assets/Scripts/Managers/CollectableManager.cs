using System;
using Data.UnityObject;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class CollectableManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private CollectableType collectableType;
        private float _myValue;

        #endregion

        private void Awake()
        {
            SetData();
        }

        private void SetData()
        {
            Addressables.LoadAssetAsync<CD_CollectableData>("Assets/GameDatas/Data/CD_CollectableData.asset").Completed +=
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        foreach (var data in asyncOperationHandle.Result.data)
                        {
                            if (data.collectableType == collectableType)
                            {
                                _myValue = data.value;
                            }
                        }
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
            GameSignals.Instance.onWarnCollectable += OnWarnCollectable;
        }

        
        private void UnsubscribeEvents()
        {
         
            GameSignals.Instance.onWarnCollectable -= OnWarnCollectable;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnWarnCollectable(GameObject target)
        {
            if (target.GetInstanceID()== gameObject.GetInstanceID())
            {
                GameSignals.Instance.onSetNewScore?.Invoke(_myValue);
                GameSignals.Instance.onPlayAmmoSound?.Invoke(collectableType);
            } 
        }
    }
}