using System.Collections.Generic;
using Commands;
using Controllers.UI;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private List<GameObject> uiPanelGameObjects;
        [SerializeField] private Timer timer;
        [SerializeField] private Slider slider;

        private UIPanelHandler _uiPanelHandler;

        #endregion

        private void Awake()
        {
            _uiPanelHandler = new UIPanelHandler(ref uiPanelGameObjects);
            foreach (var panelGameObject in uiPanelGameObjects)
            {
                panelGameObject.SetActive(false);
            }
            _uiPanelHandler.Execute(UIPanels.StartPanel,true);
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
            GameSignals.Instance.onSetScoreText += OnSetScoreText;
            GameSignals.Instance.onSetLevelScoreBorder += OnSetLevelScoreBorder;
        }

        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlay -= OnPlay;
            GameSignals.Instance.onFail -= OnFail;
            GameSignals.Instance.onSuccess -= OnSuccess;
            GameSignals.Instance.onSetScoreText -= OnSetScoreText;
            GameSignals.Instance.onSetLevelScoreBorder -= OnSetLevelScoreBorder;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        public void Play()
        {
            GameSignals.Instance.onPlay?.Invoke();
        }

        private void OnPlay()
        {
            _uiPanelHandler.Execute(UIPanels.StartPanel,false);
            _uiPanelHandler.Execute(UIPanels.GamePanel, true);
            timer.StartTimer();
        }

        private void OnFail()
        {
            _uiPanelHandler.Execute(UIPanels.GamePanel,false);
            _uiPanelHandler.Execute(UIPanels.FailPanel, true);
        }

        private void OnSuccess()
        {
            timer.StopTimer();
        }

        private void OnSetScoreText(float value)
        {
            slider.SetScore(value);
        }

        private void OnSetLevelScoreBorder(float value)
        {
            slider.SetLevelScoreBorder(value);
        }
    }
}