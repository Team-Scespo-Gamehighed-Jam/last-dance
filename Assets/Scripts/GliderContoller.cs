using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GliderContoller : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        _rb.velocity = Vector2.right * Time.deltaTime * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("yeeet");
            _rb.velocity = Vector2.right * Time.deltaTime * speed + (4) * Vector2.up * Time.deltaTime * speed;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            _rb.velocity = Vector2.right * Time.deltaTime * speed + (-3) * Vector2.up * Time.deltaTime * speed;
        }
    }
}
