using System;
using UnityEngine;

namespace Player.Mountain
{
    public class MountainMovement : MonoBehaviour
    {
        [SerializeField] private float movementAmount;
        [SerializeField] private float minPosY;
        [SerializeField] private float maxPosY;
        [SerializeField] private Transform target;
        
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
            if (target.position.y>=maxPosY)
            {
                //LevelLoader.intance.LoadNextLevel();
                //Mountain End!
                Debug.Log("Mountain End!");
                return;
            }

            var pos = target.position;
            pos.y += movementAmount;
            target.position = pos;
        }

        private void MoveDown()
        {
            Debug.Log("Down");
            if (target.position.y<=minPosY)
                return;
            
            
            var pos = target.position;
            pos.y -= movementAmount;
            target.position = pos;
        }
    }
}