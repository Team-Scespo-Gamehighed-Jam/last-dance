using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderContoller : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;

    [SerializeField] private Animator _animator;

    public float speed;
    public float upwardsVelocityBoost;
    public float downwardsVelocityBoost;
    public float horizontalVelocityBoost;

    private Vector2 _velocityVector;
    private Vector2 _dampVelocity;
    private Vector2 _targetVector;

    private bool directionUpwards;

    // Start is called before the first frame update
    void Start()
    {
        directionUpwards = false;
        _rb.velocity = _velocityVector;
        _dampVelocity = Vector2.zero;
        _velocityVector = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _rb.velocity = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost) +
                           Vector2.up * (Time.deltaTime * speed * upwardsVelocityBoost);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 45), speed * Time.deltaTime);
        }
        else
        {
            _targetVector = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost) +
                            Vector2.up * (Time.deltaTime * speed * downwardsVelocityBoost);

            _rb.velocity = Vector2.SmoothDamp(_velocityVector, _targetVector, ref _dampVelocity, 1);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -45), speed * Time.deltaTime);

            _velocityVector = _targetVector;
            _dampVelocity = Vector2.zero;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            _animator.SetBool("hit", true);
            Debug.Log("hit");
            //TODO: Gameover Glider!
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            _animator.SetBool("hit", false);
            Debug.Log("exit hit");
            //TODO: Gameover Glider!
        }
    }
}