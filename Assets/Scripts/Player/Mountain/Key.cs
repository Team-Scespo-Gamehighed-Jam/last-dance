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
                image.fillAmount = _time / timeMaxPoint;
                ColorPicker();

            }
            else
            {
                //TODO: Character Down from mountain
            }
        }


        private void ColorPicker()
        {
            float value = _time / timeMaxPoint;
            if (value<=0.33f)
            {
                image.color=Color.red;
            }else if (value<=0.66f && value>0.33f)
            {
                image.color=Color.yellow;
            }
            else
            {
                image.color=Color.green;
            }
        }
    }
}