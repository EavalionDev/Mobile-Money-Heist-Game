using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMovement : MonoBehaviour
{
    public Transform roadObjectPool;
    private RoadObjectPool objectPool;
    //no more than 100
    private float movementSpeed = 40f;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        objectPool = GameObject.FindWithTag("RoadPool").GetComponent<RoadObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position -= new Vector3(0,0, movementSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BehindCam"))
        {
            canMove = false;
            objectPool.AddRoadIntoPool(gameObject);
            transform.position = roadObjectPool.position;
        }
    }
}
