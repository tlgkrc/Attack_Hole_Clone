using System.Threading;
using Cysharp.Threading.Tasks;
using Managers;
using Signals;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.UI
{
    public class Timer : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private UIManager uiManager;
        [SerializeField] private Image timeProgressImage;
        [SerializeField] private TextMeshProUGUI timeTMP;
        
        private const int TimeBorder = 20;
        private int _currentTime;
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

        #endregion

        public void StartTimer()
        {
            _currentTime = TimeBorder;
            TimeCounter();
            
        }

        private async void TimeCounter()
        {
            _currentTime -= 1;
            await UniTask.Delay(1000,cancellationToken:_cancellationTokenSource.Token);
            if (_currentTime<=0)
            {
                GameSignals.Instance.onFail?.Invoke();
                StopTimer();
            }
            else
            {
                TimeCounter();
            }

            int minutes = _currentTime / 60;
            int seconds = _currentTime % 60;
            timeTMP.text = $"{minutes:00}:{seconds:00}";
            //timeProgressImage.DOFillAmount()
        }

        public void StopTimer()
        {
            _cancellationTokenSource.Cancel();
        }
    }
}