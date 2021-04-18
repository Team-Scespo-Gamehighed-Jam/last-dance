using System;
using Dialog;
using Player.Rocket;
using UnityEngine;

namespace Enemy
{
    
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private Dialog.Dialog _dialog;
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.name);
            var instanceID = other.GetInstanceID();
            if (!RocketHelper.RocketList.ContainsKey(instanceID))
                return;
            
            
            GameOver();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log(other.collider.name);
            var instanceID = other.collider.GetInstanceID();
            if (!RocketHelper.RocketList.ContainsKey(instanceID))
                return;
            
            GameOver();
        }

        private void GameOver()
        {
            DialogManager.instance.ShowDialog(_dialog);
            LevelLoader.intance.LoadNextLevel(0);
        }
    }
}