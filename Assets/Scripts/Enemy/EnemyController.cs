using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyController : MonoBehaviour
    {
        public float maxY;
        public float minY;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag.Equals("Enemy"))
            {
                var newPos = transform.position;
            
                newPos.y = Random.Range(minY, maxY);

                transform.position = newPos;
            }
        }

        private void OnDestroy()
        {
            transform.parent.GetComponent<EnemySpawnManager>().RemoveChildFromList(gameObject);
        }
    }
}
