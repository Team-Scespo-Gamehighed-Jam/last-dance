using System;
using System.Collections;
using Input_System;
using UnityEngine;

namespace Player.Rocket
{
    public class RotationRocketMovement : MonoBehaviour
    {
        [SerializeField] private Transform firePoint;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private InputBooleanData leftData;
        [SerializeField] private InputBooleanData rightData;

        private void Start()
        {
            StartCoroutine(RotateMovement());
        }

        private IEnumerator RotateMovement()
        {
            yield return new WaitForSeconds(2f);
            do
            {
                if (leftData.Value)
                {
                    LeftRotate();
                
                }else if (rightData.Value)
                {
                    RightRotate();
                }

                yield return null;
            } while (true);
        }
        

        private void LeftRotate()
        {
            if (transform.rotation.z*Mathf.Rad2Deg>=10/2f)
                return;
            
            transform.RotateAround(firePoint.position,Vector3.forward, rotationSpeed*Time.deltaTime);
        }

        private void RightRotate()
        {
            if (transform.rotation.z*Mathf.Rad2Deg<=-10/2f)
                return;
            
            transform.RotateAround(firePoint.position,Vector3.forward, -rotationSpeed*Time.deltaTime);
        }
        
    }
}