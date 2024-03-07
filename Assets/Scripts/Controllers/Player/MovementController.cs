using System;
using Data.ValueObject;
using Keys;
using Managers;
using UnityEngine;

namespace Controllers.Player
{
    public class MovementController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private PlayerManager manager;
        [SerializeField] private bool isReadyToMove;
        
        private float _moveFactor;
        private Vector3 _moveVector;

        #endregion

        private void Update()
        {
            if (isReadyToMove)
            {
                Move();
            }
        }

        public void DeactivateMovement()
        {
            isReadyToMove = false;
        }

        public void ActivateMovement()
        {
            isReadyToMove = true;
        }

        public void SetInputValues(InputParams inputParams)
        {
            _moveVector.x = inputParams.ValueX;
            _moveVector.z = inputParams.ValueZ;
        }

        public void SetMovementData(PlayerData data)
        {
            _moveFactor = data.moveFactor;
        }
        
        private void Move()
        {
            manager.transform.Translate(_moveVector * Time.deltaTime*_moveFactor); 
        }
    }
}