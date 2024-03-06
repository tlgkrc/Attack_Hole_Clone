using System;
using System.Collections.Generic;
using Commands;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private List<GameObject> uiPanelGameObjects;

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
        }

        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlay -= OnPlay;
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
        }
    }
}