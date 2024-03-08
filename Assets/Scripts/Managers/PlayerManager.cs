using Controllers.Player;
using Data.UnityObject;
using Data.ValueObject;
using Keys;
using Signals;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private MovementController movementController;
        [SerializeField] private PhysicController physicController;
        [SerializeField] private HoleController holeController;
        private PlayerData _playerData = new PlayerData();
        #endregion

        private void Awake()
        {
            SetData();
        }

        private void SetData()
        {
            Addressables.LoadAssetAsync<CD_PlayerData>("Assets/GameDatas/Data/CD_PlayerData.asset").Completed +=
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        _playerData = asyncOperationHandle.Result.Data;
                        movementController.SetMovementData(_playerData);
                        physicController.SetPhysicData(_playerData.physicData);
                        holeController.SetHoleData(_playerData.holeData);
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
            GameSignals.Instance.onInputTaken += OnActivateMovement;
            GameSignals.Instance.onInputReleased += OnDeactivateMovement;
            GameSignals.Instance.onJoystickDragged += OnSetInputValues;
            GameSignals.Instance.onPlay += OnPlay;
            GameSignals.Instance.onGetPlayerTransform += OnGetPlayerTransform;
        }

        
        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onInputTaken -= OnActivateMovement;
            GameSignals.Instance.onInputReleased -= OnDeactivateMovement;
            GameSignals.Instance.onJoystickDragged -= OnSetInputValues;
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onGetPlayerTransform -= OnGetPlayerTransform;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void OnDeactivateMovement()
        {
            movementController.DeactivateMovement();
        }

        private void OnActivateMovement()
        {
            movementController.ActivateMovement();
        }
        
        private void OnSetInputValues(InputParams arg0)
        {
            movementController.SetInputValues(arg0);
        }

        private void OnPlay()
        {
            GameSignals.Instance.onSetCameraTarget?.Invoke(transform);
        }

        private Transform OnGetPlayerTransform()
        {
            return transform;
        }
    }
}