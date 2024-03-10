using System;
using Data.ValueObject;
using UnityEngine;

namespace Controllers.Player
{
    public class PhysicController : MonoBehaviour
    {
        #region Self Variables

        [SerializeField] private new Collider collider;

        #endregion
        private PhysicData _physicData;
        private void OnTriggerEnter(Collider other)
        {
            ChangeLayer(other, _physicData.noColliderLayer);
        }

        private void OnTriggerExit(Collider other)
        {
            ChangeLayer(other, _physicData.defaultLayer);
        }

        private void ChangeLayer(Collider other,string layer)
        {
            other.gameObject.layer = LayerMask.NameToLayer(layer);
        }

        public void SetPhysicData(PhysicData physicData)
        {
            _physicData = physicData;
        }

        public void ActivatePhysic()
        {
            collider.isTrigger = true;
        }
        
        public void DeactivatePhysic()
        {
            collider.isTrigger = false;
        }
    }
}