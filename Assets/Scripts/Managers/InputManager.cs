using System;
using System.Collections.Generic;
using Input_System;
using UnityEngine;

namespace Managers
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private List<InputBooleanData> inputBooleanDataList;

        private void Update()
        {
            foreach (var i in inputBooleanDataList)
            {
                i.Process();
            }
        }
    }
}