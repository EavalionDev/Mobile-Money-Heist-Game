using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform leftBarrier, rightBarrier;
    public float moveSpeed, rotateAmount;
    private bool left, right;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        if (left)
        {
            transform.position = Vector3.MoveTowards(transform.position, leftBarrier.transform.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, leftBarrier.rotation, rotateAmount * Time.deltaTime);
        }
        if (right)
        {
            transform.position = Vector3.MoveTowards(transform.position, rightBarrier.transform.position, moveSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, rightBarrier.rotation, rotateAmount * Time.deltaTime);
        }
        if (!left && !right)
        {
            Quaternion defaultQuaternion = new Quaternion();
            defaultQuaternion.Set(0, 0, 0, 1);
            transform.rotation = Quaternion.Lerp(transform.rotation, defaultQuaternion , rotateAmount * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TRCol"))
        {
            other.transform.parent.GetComponent<BadCarMovement>().hitTr = true;
        }
        else if (other.CompareTag("TLCol"))
        {
            other.transform.parent.GetComponent<BadCarMovement>().hitTl = true;
        }
        else if (other.CompareTag("BRCol"))
        {
            other.transform.parent.GetComponent<BadCarMovement>().hitBr = true;
        }
        else if (other.CompareTag("BLCol"))
        {
            other.transform.parent.GetComponent<BadCarMovement>().hitBl = true;
        }
    }
}
