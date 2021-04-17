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
        [SerializeField] private Key prefabText;
        [SerializeField] private List<Transform> placeList;
        private TMP_Text _currentKey;

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
            
            if (_currentKey.text==Input.inputString)
            {
                //TODO: Character Up from mountain
                Destroy(_currentKey.transform.parent.gameObject);
                SpawnKey();
            }
            else
            {
                //TODO: Character Down from mountain
                Debug.Log("Meeh, you are so bad!");
            }

        }

        public void SpawnKey()
        {
            var keyIndex = Random.Range(0, _keys.Count);
            var placeIndex = Random.Range(0, placeList.Count);
            
            var text = Instantiate(prefabText, transform);
            
            text.transform.position = placeList[placeIndex].transform.position;
            text.keyTMP.text = _keys[keyIndex];

            text.mountainKeyWork = this;

            _currentKey = text.keyTMP;
        }
    }
}