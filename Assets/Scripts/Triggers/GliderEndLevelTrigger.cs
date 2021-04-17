using Player.Glider;
using UnityEngine;

namespace Triggers
{
    public class GliderEndLevelTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceID = other.GetInstanceID();
            if (!GliderHelper.GliderList.ContainsKey(instanceID))
                return;
            
            Debug.Log("Use Rocket Animation");
            LevelLoader.intance.LoadNextLevel();
            //Glider End Animation!
        }
    }
}
