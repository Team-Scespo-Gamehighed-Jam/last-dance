using System;
using UnityEngine;

namespace Player.Mountain
{
    public class MountainMovement : MonoBehaviour
    {
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
        }

        private void MoveDown()
        {
            Debug.Log("Down");
        }
    }
}