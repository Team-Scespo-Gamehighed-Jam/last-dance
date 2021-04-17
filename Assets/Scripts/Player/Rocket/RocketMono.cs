using System;
using UnityEngine;

namespace Player.Rocket
{
    public class RocketMono : MonoBehaviour, IRocket
    {
        [SerializeField] private Collider2D _collider2D;
        public int InstanceID { get; private set; }

        private void OnEnable()
        {
            InstanceID=_collider2D.GetInstanceID();
            this.InitializeRocket();
        }

        private void OnDestroy()
        {
            this.DestroyRocket();
        }
    }
}