using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    private Vector3 v3 = Vector3.zero;
    private float speed = 700f;
    // Update is called once per frame
    void Update()
    {
        v3.x += speed * Time.deltaTime;
        transform.eulerAngles = v3;
    }
}
