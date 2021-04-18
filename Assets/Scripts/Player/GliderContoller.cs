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

    private bool controllable;
    private int endGameBoost;
    private bool gameFinished;

    // Start is called before the first frame update
    void Start()
    {
        controllable = true;
        gameFinished = false;
        _rb.velocity = _velocityVector;
        _dampVelocity = Vector2.zero;
        _velocityVector = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (controllable)
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
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            _animator.SetBool("hit", true);
            Debug.Log("hit");
            EndGame(false, 1);
            //TODO: Gameover Glider!
        }

        else if (other.tag.Equals("Ceiling Collider"))
        {
            controllable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Enemy"))
        {
            Debug.Log("exit hit");
            EndGame(false, 1);
            //TODO: Gameover Glider!
        }

        else if (other.tag.Equals("Ceiling Collider") && !gameFinished)
        {
            controllable = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Ground Collider"))
        {
            _animator.SetBool("hit", true);
            Debug.Log("ground hit");
            EndGame(false, 1);
            //TODO: Gameover Glider!
        }
    }

    private void EndGame(bool controllable, float velocityBoost)
    {
        this.controllable = controllable;
        _rb.velocity = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost * velocityBoost);
        gameFinished = true;
        
        //TODO: implement game over!
    }
    
    public void Transition(bool controllable, float velocityBoost)
    {
        this.controllable = controllable;
        _rb.velocity = Vector2.right * (Time.deltaTime * speed * horizontalVelocityBoost * velocityBoost);
        gameFinished = true;
    }
}