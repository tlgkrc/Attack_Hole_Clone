using System;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioClip bgAudioClip;
        [SerializeField] private AudioClip handGunAudioClip;
        [SerializeField] private AudioClip shotgunGunAudioClip;
        [SerializeField] private AudioSource ammoAudioSource;
        [SerializeField] private AudioSource backgroundAudioSource;

        private void Awake()
        {
            backgroundAudioSource.clip = bgAudioClip;
            backgroundAudioSource.volume = .2f;
            backgroundAudioSource.loop = true;
            backgroundAudioSource.Play();
            ammoAudioSource.volume = .7f;
            ammoAudioSource.loop = false;
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }
        
        private void SubscribeEvents()
        {
            GameSignals.Instance.onPlayAmmoSound += OnPlayAmmoSound;
        }

        
        private void UnsubscribeEvents()
        {
            GameSignals.Instance.onPlayAmmoSound -= OnPlayAmmoSound;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnPlayAmmoSound(CollectableType collectableType)
        {
            ammoAudioSource.Stop();
            if (collectableType == CollectableType.HandgunAmmo)
            {
                ammoAudioSource.PlayOneShot(handGunAudioClip);
            }
            else if (collectableType == CollectableType.ShotgunAmmo)
            {
                ammoAudioSource.PlayOneShot(shotgunGunAudioClip);
            }
        }
    }
}