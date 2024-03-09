using System;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Physics.gravity = new Vector3(0, -100, 0);
        }
    }
}