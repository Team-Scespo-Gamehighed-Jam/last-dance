using System;
using UnityEngine;

namespace Player.Mountain
{
    public class MountainMovement : MonoBehaviour
    {
        [SerializeField] private int movementAmount;
        [SerializeField] private int minPosY;
        [SerializeField] private int maxPosY;
        
        private void OnEnable()
        {
            MountainKeyWork.CharacterEventHandler += Move;
        }

        private void OnDisable()
        {
            MountainKeyWork.CharacterEventHandler -= Move;
        }
        
        private void Move(bool isUp)
        {
            if (isUp)
            { MoveUp(); }
            else
            { MoveDown(); }
        }

        private void MoveUp()
        {
            Debug.Log("Up!");
            if (transform.position.y>=maxPosY)
            {
                //TODO: Mountain End!
                Debug.Log("Mountain End!");
                return;
            }
            var pos = transform.position;
            pos.y += movementAmount;
            transform.position = pos;
        }

        private void MoveDown()
        {
            Debug.Log("Down");
            if (transform.position.y<=minPosY)
                return;

            var pos = transform.position;
            pos.y -= movementAmount;
            transform.position = pos;
        }
    }
}