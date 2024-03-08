using Cinemachine;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class CameraManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private CinemachineVirtualCamera startCam;
        [SerializeField] private CinemachineVirtualCamera levelCam;
        [SerializeField] private CinemachineVirtualCamera levelEndCam;
        [SerializeField] private Animator camAnimator;

        private CameraStates _cameraState = CameraStates.StartCam;

        #endregion
        
        
        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            GameSignals.Instance.onPlay += OnPlay;
            GameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
            GameSignals.Instance.onSetCameraState += OnSetCameraState;
        }

        
        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
            GameSignals.Instance.onSetCameraState -= OnSetCameraState;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void SetCameraStates()
        {
            if (_cameraState == CameraStates.LevelCam)
            {
                camAnimator.Play(CameraStates.LevelCam.ToString());
            }
            else if (_cameraState == CameraStates.LevelEndCam)
            {
                var newTransform = GameSignals.Instance.onGetPlayerTransform?.Invoke();
                if (newTransform != null) levelEndCam.transform.position = newTransform.position;
                camAnimator.Play(CameraStates.LevelEndCam.ToString());
            }
            else if (_cameraState == CameraStates.StartCam)
            {
                camAnimator.Play(CameraStates.StartCam.ToString());
            }

        }

        private void OnSetCameraState(CameraStates cameraState)
        {
            _cameraState = cameraState;
            SetCameraStates();
        }
        
        private void OnSetCameraTarget(Transform playerManager)
        {
            levelCam.Follow = playerManager;
        }

        private void OnPlay()
        {
            OnSetCameraState(CameraStates.LevelCam);
        }
    }
}