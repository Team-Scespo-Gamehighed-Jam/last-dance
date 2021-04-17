using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] private Camera cam;

    [SerializeField] private EnemyController enemyController;

    private float _cameraWidth;
    private float _cameraHeight;

    private Vector2 _spawnVector;
    private Vector2 _destroyVector;

    [SerializeField] private float spawnOffsetX;

    private int _enemyPerColumn;
    [SerializeField] private int columnCount;
    [SerializeField] private float columnGap;

    private List<GameObject> _enemies;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new List<GameObject>();
        
        _spawnVector = new Vector2(0, 0);
        _destroyVector = new Vector2(0, 0);
        
        _cameraHeight = 2f * cam.orthographicSize;
        _cameraWidth = _cameraHeight * cam.aspect;

        _enemyPerColumn = Random.Range(0, 3);

        _spawnVector.x = cam.transform.position.x + _cameraWidth / 2 + spawnOffsetX;
        for (int i = 0; i < columnCount; i++)
        {
            for (int j = 0; j < _enemyPerColumn; j++)
            {
                _spawnVector.y = Random.Range(cam.transform.position.y - _cameraHeight / 2,
                    cam.transform.position.y + _cameraHeight / 2);
                
                var enemy = Instantiate(enemyController, _spawnVector, Quaternion.identity, gameObject.transform);

                enemy.maxY = cam.transform.position.y + _cameraHeight / 2;
                enemy.minY = cam.transform.position.y - _cameraHeight / 2;
                
                _enemies.Add(enemy.gameObject);
            }
            _enemyPerColumn = Random.Range(0, 3);
            _spawnVector.x += columnGap;
        }
    }

    // Update is called once per frame
    void Update()
    {
        _destroyVector.x = cam.transform.position.x - _cameraWidth / 2 - spawnOffsetX;
        
        for (var i = 0; i < _enemies.Count; i++)
        {
            var enemy = _enemies[i];
            if (enemy.transform.position.x < _destroyVector.x)
            {
                Destroy(enemy);
                _enemies.Remove(enemy);
            }
        }
    }

    public void RemoveChildFromList(GameObject enemy)
    {
        _enemies.Remove(enemy.gameObject);
    }
}
