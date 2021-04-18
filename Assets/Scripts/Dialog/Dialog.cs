using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
    [System.Serializable]
    public class Dialog
    {
        [SerializeField] private List<string> lines;


        public List<string> Lines
        {
            get => lines;
            set => lines = value;
        }
    }
}