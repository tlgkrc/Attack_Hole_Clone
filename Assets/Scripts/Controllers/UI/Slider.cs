using System.Globalization;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;

namespace Controllers.UI
{
    public class Slider : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private UIManager manager;
        [SerializeField] private UnityEngine.UI.Slider slider;
        [SerializeField] private TextMeshProUGUI scoreText;

        private float _scoreBorder;
        #endregion

        public void SetScore(float newScore)
        {
            slider.DOValue(newScore / _scoreBorder,.2f);
            scoreText.text = newScore.ToString();

        }

        public void SetLevelScoreBorder(float value)
        {
            _scoreBorder = value;
        }
    }
}