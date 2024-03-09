using Commands;
using Keys;
using Signals;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
       #region Self Variables

        #region Serialized Variables

        [SerializeField] private bool isFirstTimeTouchTaken,isReadyForTouch;
        [SerializeField] private FloatingJoystick floatingJoystick;

        #endregion

        #region Private Variables

        private bool _isTouching;
        private float _currentVelocity; 
        private Vector3 _moveVector; 
        private QueryPointerOverUIElementCommand _queryPointerOverUIElementCommand;

        #endregion

        #endregion
        
        private void Awake()
        {
            Init();
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            GameSignals.Instance.onEnableInput += OnEnableInput;
            GameSignals.Instance.onDisableInput += OnDisableInput;
            GameSignals.Instance.onPlay += OnPlay;
            GameSignals.Instance.onRestartLevel += OnReset;
        }

        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onEnableInput -= OnEnableInput;
            GameSignals.Instance.onDisableInput -= OnDisableInput;
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onRestartLevel -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void Init()
        {
            _queryPointerOverUIElementCommand = new QueryPointerOverUIElementCommand();
        }

        private void OnPlay()
        {
            GameSignals.Instance.onEnableInput?.Invoke();
            isFirstTimeTouchTaken = true;
        }

        private void Update()
        {
            if (_queryPointerOverUIElementCommand.Execute() || !isFirstTimeTouchTaken || !isReadyForTouch)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                GameSignals.Instance.onInputTaken?.Invoke();
            }
            if (Input.GetMouseButton(0))
            {
                MouseButtonDown();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                MouseButtonUp();   
            }
        }

        #region Event Methods
        
        private void OnEnableInput()
        {
            isReadyForTouch = true;
        }
        
        private void OnDisableInput()
        {
            isReadyForTouch = false;
        }

        private void OnReset()
        {
            isReadyForTouch = false;
        }

        private void OnNextLevel() 
        {
            isReadyForTouch = false;
        }

        #endregion

        private void MouseButtonUp()
        {
            _moveVector = Vector3.zero;
            GameSignals.Instance.onInputReleased?.Invoke();
        }

        private void MouseButtonDown()
        {
            GameSignals.Instance.onInputTaken?.Invoke();
            JoystickInput();
        }
        
        private void JoystickInput()
        {
            _moveVector.x = floatingJoystick.Horizontal;
            _moveVector.z = floatingJoystick.Vertical;
            GameSignals.Instance.onJoystickDragged?.Invoke(new InputParams()
            {
                ValueX = _moveVector.x,
                ValueZ = _moveVector.z
            });
        }
    }
}
