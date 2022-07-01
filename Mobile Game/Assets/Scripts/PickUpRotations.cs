using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRotations : MonoBehaviour
{

    private float rotateSpeed = 400f, bounceSpeed = 3f, count;
    private bool up;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        up = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);



        if (up)
        {
            count += Time.deltaTime;
            transform.position += new Vector3(0,bounceSpeed * Time.deltaTime, 0);
            if (count > 0.2f)
            {
                up = false;
            }
        }
        else
        {
            count -= Time.deltaTime;
            transform.position -= new Vector3(0, bounceSpeed * Time.deltaTime, 0);
            if (count <= 0)
            {
                up = true;
            }
        }

    }
}
