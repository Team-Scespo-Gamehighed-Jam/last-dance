using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Mountain
{
    public class MountainKeyWork : MonoBehaviour
    {
        private readonly List<string> _keys = new List<string>();
        [SerializeField] private MountainKey prefabText;
        [SerializeField] private List<Transform> placeList;
        private TMP_Text _currentKey;
        public MountainKey currentKeyScript;
        [SerializeField] private Animator playerAnimator;
        
        public delegate void CharacterUpDown(bool isUp);
        public static event CharacterUpDown CharacterEventHandler;

        private void Start()
        {
            _keys.Add("q");
            _keys.Add("w");
            _keys.Add("a");
            _keys.Add("s");
            _keys.Add("d");
            _keys.Add("e");

            StartCoroutine(CheckKey());

        }

        private IEnumerator CheckKey()
        {
            yield return new WaitForSeconds(12);
            //Animator go 
            playerAnimator.enabled=false;
            SpawnKey();

            do
            {
                if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
                {
                    if (_currentKey.text.ToLower()==Input.inputString)
                    {
                        //Character Up from mountain
                        CharacterMove(true);

                        DestroyCurrentKey();
                        SpawnKey();
                    }
                    else
                    {
                        //Character Down from mountain
                        CharacterMove(false);
                    }
                }


                yield return null;
            } while (true);

            yield return null;
        }

        public void SpawnKey()
        {
            var keyIndex = Random.Range(0, _keys.Count);
            var placeIndex = Random.Range(0, placeList.Count);
            
            var text = Instantiate(prefabText, transform);
            
            text.transform.position = placeList[placeIndex].transform.position;
            text.keyTMP.text = _keys[keyIndex].ToUpper();

            text.mountainKeyWork = this;
            currentKeyScript = text;

            _currentKey = text.keyTMP;
        }

        public void CharacterMove(bool isUp)
        {
            CharacterEventHandler?.Invoke(isUp);
        }

        private void DestroyCurrentKey()
        {
            Destroy(_currentKey.transform.parent.gameObject);
        }
    }
}