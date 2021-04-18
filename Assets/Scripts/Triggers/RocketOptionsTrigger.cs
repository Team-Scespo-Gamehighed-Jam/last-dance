using System.Collections;
using System.Collections.Generic;
using Player.Mountain;
using Player.Rocket;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Triggers
{
    public class RocketOptionsTrigger : MonoBehaviour
    {
        private readonly List<string> _keys = new List<string>();
        [SerializeField] private RocketKey prefabText;
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
        }
        
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var instanceID = other.GetInstanceID();
            if (!RocketHelper.RocketList.ContainsKey(instanceID))
                return;
            
            Debug.Log("Rocket End Option");
            
            
            SpawnKey();
            StartCoroutine(DetectKey());
        }
        
        
        public void SpawnKey()
        {
            var keyIndex = Random.Range(0, _keys.Count);
            var placeIndex = Random.Range(0, placeList.Count);
            
            var text = Instantiate(prefabText, placeList[placeIndex].transform);
            
            text.transform.position = placeList[placeIndex].transform.position;
            text.keyTMP.text = _keys[keyIndex].ToUpper();
            _currentKey = text.keyTMP;
        }

        private IEnumerator DetectKey()
        {
            bool isEnd = true;
            do
            {
                if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
                {
                    if (_currentKey.text.ToLower()==Input.inputString)
                    {
                        Destroy(_currentKey.transform.parent.gameObject);
                        isEnd = false;
                        Debug.Log("Parachute");
                        //Parachute animation End!
                        int index = SceneManager.GetActiveScene().buildIndex + 2;
                        LevelLoader.intance.LoadNextLevel(index);
                        
                    }
                    else
                    {
                        Debug.Log("Space");
                        //Parachute animation End!
                        //LevelLoader.intance.LoadNextLevel();
                        isEnd = false;
                        //Space
                    }
                }
                yield return null;
            } while (isEnd);
            yield return null;
        }
    }
}