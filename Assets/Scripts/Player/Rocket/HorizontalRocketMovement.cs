using System;
using System.Collections;
using Input_System;
using UnityEngine;

namespace Player.Rocket
{
    public class HorizontalRocketMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private InputBooleanData leftData;
        [SerializeField] private InputBooleanData rightData;

        private void Start()
        {
            StartCoroutine(HorizontalMovement());
        }

        private IEnumerator HorizontalMovement()
        {
            yield return new WaitForSeconds(2f);
            do
            {
                if (leftData.Value)
                {
                    LeftMovement();
                }else if (rightData.Value)
                {
                    RightMovement();
                }
                yield return null;
            } while (true);
        }
        

        private void LeftMovement()
        {
            var pos =transform.position;
            pos.x -= speed * Time.deltaTime;
            transform.position = pos;
        }

        private void RightMovement()
        {
            var pos =transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}