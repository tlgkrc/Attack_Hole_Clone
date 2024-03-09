using System;
using Enums;
using Extensions;
using Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class GameSignals: MonoSingleton<GameSignals>
    {
        #region CoreGame

        public UnityAction onPlay = delegate {  };
        public UnityAction onFail = delegate {  };
        public UnityAction onSuccess = delegate {  };
        public UnityAction onLevelFinish = delegate {  };
        public UnityAction onNext = delegate {  };
        public UnityAction onRestartLevel; //int value represents attempt number

        #endregion

        #region Input

        public UnityAction<InputParams> onJoystickDragged = delegate{  };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction onInputReleased = delegate {  };
        public UnityAction onFirstTimeTouchTaken =delegate {  };
        public UnityAction onEnableInput = delegate {  };
        public UnityAction onDisableInput = delegate {  };

        #endregion

        #region Collectable

        public UnityAction<GameObject> onWarnCollectable;

        #endregion

        #region Score

        public UnityAction<float> onSetNewScore;
        public Func<float> onGetCurrentScore;

        #endregion

        #region UI

        public UnityAction<float> onSetScoreText;
        public UnityAction<float> onSetLevelScoreBorder;
        public UnityAction<int> onSetAttemptText;
        public UnityAction<int> onSetLevelText;

        #endregion

        #region Camera

        public UnityAction<Transform> onSetCameraTarget;
        public UnityAction<CameraStates> onSetCameraState;
        public Func<Transform> onGetPlayerTransform;

        #endregion




    }
}