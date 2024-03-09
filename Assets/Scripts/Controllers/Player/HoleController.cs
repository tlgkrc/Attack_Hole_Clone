using System.Threading;
using Cysharp.Threading.Tasks;
using Data.ValueObject;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.Player
{
    public class HoleController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private Image image;
        
        private int _currentNumber;
        private HoleData _holeData;

        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Collectable"))
            {
                GameSignals.Instance.onWarnCollectable?.Invoke(other.gameObject);
                other.gameObject.SetActive(false);
                FillCircle();
            }
        }

        private async void FillCircle()
        {
            _currentNumber++;
            await image.DOFillAmount((float)_currentNumber / _holeData.scaleUpBorder, .2f);

            if (_currentNumber >= _holeData.scaleUpBorder)
            {
                manager.transform.localScale += new Vector3(.3f, 0, .3f);
                _holeData.scaleUpBorder += _holeData.increaseAmount;
                image.fillAmount = 0;
                _currentNumber = 0;
            }
        }

        public void SetHoleData(HoleData holeData)
        {
            _holeData = holeData;
        }
    }
}