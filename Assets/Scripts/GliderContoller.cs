using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GliderContoller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    public float speed;
    public float upwardsVelocityBoost;
    public float downwardsVelocityBoost;
    public float horizontalVelocityBoost;
    
    private Vector2 _velocityVector;
    private Vector2 _dampVelocity;
    private Vector2 _targetVector;

    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = _velocityVector;
        _dampVelocity = Vector2.zero;
        _velocityVector = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost) + Vector2.up * (Time.deltaTime * speed * upwardsVelocityBoost);
        }
        else
        {
            _targetVector = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost) + Vector2.up * (Time.deltaTime * speed * downwardsVelocityBoost);
            
            _rb.velocity = Vector2.SmoothDamp(_velocityVector, _targetVector, ref _dampVelocity, 1);
            
            _velocityVector = _targetVector;
            _dampVelocity = Vector2.zero;
        }
    }
}
