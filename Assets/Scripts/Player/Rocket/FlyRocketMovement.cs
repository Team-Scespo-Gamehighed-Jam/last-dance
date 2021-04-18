using System;
using System.Collections;
using UnityEngine;

namespace Player.Rocket
{
    public class FlyRocketMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float speedAmount;
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;
        private float rocketSpeed=0;

        private void Start()
        {
            StartCoroutine(FireRocket());
        }

        private IEnumerator FireRocket()
        {
            yield return new WaitForSeconds(2f);
            do
            {
                rocketSpeed += Time.deltaTime/speedAmount;
                rocketSpeed = Mathf.Clamp(rocketSpeed, minValue, maxValue);
                Vector2 pos = transform.position;
                pos.y += rocketSpeed;
                transform.position = pos;
                yield return null;
            } while (true);
            
        }
    }
}