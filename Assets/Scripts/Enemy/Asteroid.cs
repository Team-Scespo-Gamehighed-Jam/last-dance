using System;
using Player.Rocket;
using UnityEngine;

namespace Enemy
{
    public class Asteroid : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceID = other.GetInstanceID();
            if (!RocketHelper.RocketList.ContainsKey(instanceID))
                return;
            
            Debug.Log("Game Over!");
            //TODO: Rocket Game Over!
        }
    }
}