using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pMove : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;
    private bool forward, left, right, backwards;
    // Start is called before the first frame update
    void Start()
    {
        forward = false;
        left = false;
        right = false;
        backwards = false;
    }

    // Update is called once per frame
    void Update()
    {
        forward = Input.GetKey(KeyCode.W);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        backwards = Input.GetKey(KeyCode.S);
    }
    private void FixedUpdate()
    {
        if (!forward && !backwards && !right && !left)
        {
            rb.velocity = Vector3.zero;
        }
        if (forward)
        {
            rb.velocity = transform.forward * speed * Time.fixedDeltaTime;
        }
        if (backwards)
        {
            rb.velocity = transform.forward * -speed * Time.fixedDeltaTime;
        }

        if (left)
        {
            rb.velocity = transform.right * -speed * Time.fixedDeltaTime;
        }
        if (right)
        {
            rb.velocity = transform.right * speed * Time.fixedDeltaTime;
        }

       
    }
}
