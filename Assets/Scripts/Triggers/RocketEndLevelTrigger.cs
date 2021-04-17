using Player.Rocket;
using UnityEngine;

namespace Triggers
{
    public class RocketEndLevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceID = other.GetInstanceID();
            if (!RocketHelper.RocketList.ContainsKey(instanceID))
                return;
            
            Debug.Log("Space End!");
            //Space End Animation!
            LevelLoader.intance.LoadNextLevel();
        }
    }
}