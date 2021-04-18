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

        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Sprite left;
        [SerializeField] private Sprite right;

        [SerializeField] private Animator playerAnimator;
        
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
            //Debug.Log("Up!");
            if (target.position.y>=maxPosY)
            {
                LevelLoader.intance.LoadNextLevel();
                //Debug.Log("Mountain End!");
                //playerAnimator.enabled = true;
                //playerAnimator.SetTrigger("StartAfterClimb");
                return;
            }

            _spriteRenderer.sprite = (int)target.position.y%2==1 ? left : right;

           
            
            var pos = target.position;
            pos.y += movementAmount;
            target.position = pos;
        }

        private void MoveDown()
        {
            //Debug.Log("Down");
            if (target.position.y<=minPosY)
                return;
            
            _spriteRenderer.sprite = (int)target.position.y%2==1 ? left : right;
            
            var pos = target.position;
            pos.y -= movementAmount;
            target.position = pos;
        }
    }
}