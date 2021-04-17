using Player.Rocket;
using UnityEngine;

namespace Triggers
{
    public class RocketOptionsTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceID = other.GetInstanceID();
            if (!RocketHelper.RocketList.ContainsKey(instanceID))
                return;
            
            Debug.Log("Rocket End Option");
            //TODO: Parachute animation End!
        }
    }
}