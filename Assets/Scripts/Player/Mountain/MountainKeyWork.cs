using System;
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
        
        public delegate void CharacterUpDown(bool isUp);
        public static event CharacterUpDown CharacterEventHandler;
        

        private void Start()
        {
            _keys.Add("a");
            _keys.Add("b");
            _keys.Add("c");
            _keys.Add("d");
            _keys.Add("e");
            _keys.Add("f");
            _keys.Add("g");
            _keys.Add("h");
            
            SpawnKey();
        }

        private void Update()
        {
            if (!Input.anyKeyDown || Input.GetMouseButtonDown(0)) return;
            
            if (_currentKey.text.ToLower()==Input.inputString)
            {
                //Character Up from mountain
                CharacterMove(true);

                Destroy(_currentKey.transform.parent.gameObject);
                SpawnKey();
            }
            else
            {
                //Character Down from mountain
                CharacterMove(false);
            }

        }

        public void SpawnKey()
        {
            var keyIndex = Random.Range(0, _keys.Count);
            var placeIndex = Random.Range(0, placeList.Count);
            
            var text = Instantiate(prefabText, transform);
            
            text.transform.position = placeList[placeIndex].transform.position;
            text.keyTMP.text = _keys[keyIndex].ToUpper();

            text.mountainKeyWork = this;

            _currentKey = text.keyTMP;
        }

        public void CharacterMove(bool isUp)
        {
            CharacterEventHandler?.Invoke(isUp);
        }
    }
}