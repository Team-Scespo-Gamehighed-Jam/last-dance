using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Player.Mountain
{
    public class Key : MonoBehaviour
    {
        [HideInInspector]public MountainKeyWork mountainKeyWork;
        public TMP_Text keyTMP;
        
        [SerializeField] private float timeMaxPoint;
        [SerializeField] private Image image;
        private float _time;

        private void Start()
        {
            _time = timeMaxPoint;
        }

        private void Update()
        {
            if (_time > 0)
            {
                _time -= Time.deltaTime;
                //fillImg.fillAmount = _time / timeMaxPoint;

            }
            else
            {
                
            }
        }
    }
}