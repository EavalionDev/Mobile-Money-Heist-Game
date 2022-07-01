using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCarMovement : MonoBehaviour
{
    public Transform vehiclePool;
    public BoxCollider col1, col2, col3, col4;
    public float radius, power, upwardsModifyer;

    private VehicleObjectPool objectPool;
    private float movementSpeed, speed = 600f, fallBackSpeed = 20f;
    public bool canMove, hitTr, hitTl, hitBr, hitBl, beenHit;
    private Vector3 v3 = Vector3.zero;
    private Rigidbody rb;
    private bool hitPolice;
    // Start is called before the first frame update
    void Start()
    {
        hitPolice = false;
        rb = GetComponent<Rigidbody>();
        col1.enabled = true;
        col2.enabled = true;
        col3.enabled = true;
        col4.enabled = true;
        hitTr = false;
        hitTl = false;
        hitBr = false;
        hitBl = false;
        beenHit = false;
        canMove = false;
        objectPool = GameObject.FindWithTag("VehiclePool").GetComponent<VehicleObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // movementSpeed = Random.Range(3f, 15f);
            movementSpeed = 8f;
            transform.position -= new Vector3(0, 0, movementSpeed * Time.deltaTime);
        }
        if (hitTr && !beenHit || hitBl && !beenHit)
        {
            if (hitPolice)
            {
                canMove = false;
                //transform.eulerAngles = v3;
                transform.position -= new Vector3(0, 0, fallBackSpeed / 2 * Time.deltaTime);
                col1.enabled = false;
                col2.enabled = false;
                col3.enabled = false;
                col4.enabled = false;
            }
            else
            {
                canMove = false;
                v3.y -= speed * Time.deltaTime;
                transform.eulerAngles = v3;
                transform.position -= new Vector3(0, 0, fallBackSpeed * Time.deltaTime);
                col1.enabled = false;
                col2.enabled = false;
                col3.enabled = false;
                col4.enabled = false;
            }
            
            StartCoroutine(SendBackToPool());
        }
        else if (hitBr && !beenHit || hitTl && !beenHit)
        {
            if (hitPolice)
            {
                canMove = false;
                //transform.eulerAngles = v3;
                transform.position -= new Vector3(0, 0, fallBackSpeed / 2 * Time.deltaTime);
                col1.enabled = false;
                col2.enabled = false;
                col3.enabled = false;
                col4.enabled = false;
            }
            else
            {
                canMove = false;
                v3.y += speed * Time.deltaTime;
                transform.eulerAngles = v3;
                transform.position -= new Vector3(0, 0, fallBackSpeed * Time.deltaTime);
                col1.enabled = false;
                col2.enabled = false;
                col3.enabled = false;
                col4.enabled = false;
            }
            
            StartCoroutine(SendBackToPool());
        }
    }
    //WHEN BEING PLACED BACK INTO THE GAME AFTER SENT AWAY IT WONT MOVE
    IEnumerator SendBackToPool()
    {
        yield return new WaitForSeconds(3f);
        beenHit = true;
        print("SOLKVNSFKLN");
        hitTr = false;
        hitTl = false;
        hitBr = false;
        hitBl = false;
        canMove = false;
        col1.enabled = true;
        col2.enabled = true;
        col3.enabled = true;
        col4.enabled = true;
        if (!objectPool.basicBadCar.Contains(gameObject))
        {
            objectPool.AddVehicleIntoPool(gameObject);
        }
        transform.position = objectPool.transform.position;
        v3 = Vector3.zero;
        transform.eulerAngles = v3;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //hurt player
        }
        if (other.CompareTag("PoliceCar"))
        {
            StartCoroutine(GoBoom());
        }
    }
    IEnumerator GoBoom()
    {
        yield return new WaitForSeconds(0.25f);
        hitPolice = true;
        Vector3 explosivePos = transform.position + new Vector3(0, 0, 3f);
        rb.AddExplosionForce(power, explosivePos, radius, upwardsModifyer);
    }
}
