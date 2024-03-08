using System.Globalization;
using DG.Tweening;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Controllers.UI
{
    public class Slider : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private UIManager manager;
        [SerializeField] private UnityEngine.UI.Slider slider;
        [SerializeField] private TextMeshProUGUI scoreTMP;
        [SerializeField] private TextMeshProUGUI levelTMP;
        [SerializeField] private TextMeshProUGUI attemptTMP;

        private float _scoreBorder;
        #endregion

        public void SetScore(float newScore)
        {
            slider.DOValue(newScore / _scoreBorder,.2f);
            scoreTMP.text = newScore.ToString();

        }

        public void SetLevelScoreBorder(float value)
        {
            _scoreBorder = value;
        }

        public void SetLevelText(int level)
        {
            levelTMP.text = level.ToString();
        }

        public void SetAttemptText(int attemptNumber)
        {
            attemptTMP.text = "ATTEMPT: " + attemptNumber;
        }
    }
}