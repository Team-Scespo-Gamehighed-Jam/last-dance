using System;
using UnityEngine;

namespace Player.Glider
{
    public class GliderMono : MonoBehaviour, IGlider
    {
        [SerializeField] private Collider2D _collider2D;
        public int InstanceID { get; private set; }

        private void OnEnable()
        {
            InstanceID = _collider2D.GetInstanceID();
            this.InitializeGlider();
        }

        private void OnDestroy()
        {
            this.DestroyGlider();
        }
    }
}