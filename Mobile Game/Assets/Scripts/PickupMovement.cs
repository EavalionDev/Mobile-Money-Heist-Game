using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMovement : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform pickUpObjectPool;
    private PickUpObjectPool objectPool;
    //no more than 100
    private float movementSpeed = 40f;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = false;
        objectPool = GameObject.FindWithTag("PickUpPool").GetComponent<PickUpObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            ps.Play();
            transform.position -= new Vector3(0, 0, movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BehindCam"))
        {
            canMove = false;
            ps.Stop();
            objectPool.AddPickUpIntoPool(gameObject);
            transform.position = pickUpObjectPool.position;
        }
        if (other.CompareTag("Player"))
        {
            canMove = false;
            ps.Stop();
            objectPool.AddPickUpIntoPool(gameObject);
            transform.position = pickUpObjectPool.position;
            //ADD TO CASH AMOUNT
        }
    }
}
