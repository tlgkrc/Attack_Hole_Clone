using System;
using Signals;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        #region Self Variables

        private float _currentScore;

        #endregion

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
            GameSignals.Instance.onSetNewScore += OnSetNewScore;
        }

       private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onFail -= OnFail;
            GameSignals.Instance.onSuccess -= OnSuccess;
            GameSignals.Instance.onSetNewScore -= OnSetNewScore;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void OnSuccess()
        {
            _currentScore = 0;
            GameSignals.Instance.onSetScoreText?.Invoke(_currentScore);
        }

        private void OnFail()
        {
            _currentScore = 0;
            GameSignals.Instance.onSetScoreText?.Invoke(_currentScore);
        }

        private void OnPlay()
        {
            _currentScore = 0;
            GameSignals.Instance.onSetScoreText?.Invoke(_currentScore);
        }

        private void OnSetNewScore(float value)
        {
            _currentScore += value;
            GameSignals.Instance.onSetScoreText?.Invoke(_currentScore);
        }
    }
}