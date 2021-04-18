using System;
using UnityEngine;

namespace Player.Glider
{
    public class GliderMono : MonoBehaviour, IGlider
    {
        [SerializeField] private Collider2D _collider2D;
        [SerializeField] private GliderContoller _gliderContoller;
        public int InstanceID { get; private set; }
        public GliderContoller Controller { get; private set; }

        private void OnEnable()
        {
            InstanceID = _collider2D.GetInstanceID();
            Controller = _gliderContoller;
            this.InitializeGlider();
        }

        private void OnDestroy()
        {
            this.DestroyGlider();
        }
    }
}