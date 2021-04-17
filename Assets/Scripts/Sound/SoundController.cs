﻿using System;
using UnityEngine;

namespace Sound
{
    public class SoundController : MonoBehaviour
    {
        public static SoundController SoundPlayer;

        public AudioSource MainAudioSource;
        
        private void Awake()
        {
            if (SoundPlayer!=null)
            {
                Destroy(gameObject);
            }
            else
            {
                SoundPlayer = this;
            }
            DontDestroyOnLoad(gameObject);
        }
    }
}
