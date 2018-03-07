using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float acceleration;

    private Rigidbody2D rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Movement(); 
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(x) >= Mathf.Abs(y))
        {
            y = 0;
        }

        else if (Mathf.Abs(x) <= Mathf.Abs(y))
        {
            x = 0;
        }

        Vector2 movement = new Vector2(x, y) * acceleration;
        rigidbody.velocity = movement;
    }
}
