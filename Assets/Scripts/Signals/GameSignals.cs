using Extensions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class GameSignals: MonoSingleton<GameSignals>
    {
        #region CoreGame

        public UnityAction onPlay = delegate {  };
        public UnityAction onFail = delegate {  };
        public UnityAction onSuccess = delegate {  };

        #endregion

        #region Input

        public UnityAction<InputParams> onJoystickDragged = delegate{  };
        public UnityAction onInputTaken = delegate {  };
        public UnityAction onInputReleased = delegate {  };
        public UnityAction onFirstTimeTouchTaken =delegate {  };
        public UnityAction onEnableInput = delegate {  };
        public UnityAction onDisableInput = delegate {  };

        #endregion

        #region Level

        public UnityAction onNextLevel;
        public UnityAction<int> onResetLevel; //int value represents attempt number

        #endregion


    }
}