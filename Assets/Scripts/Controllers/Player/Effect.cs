using System;
using UnityEngine;

namespace Controllers.Player
{
    public class Effect : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem;

        public void Play()
        {
            if (particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
            particleSystem.Play();
        }
    }
}