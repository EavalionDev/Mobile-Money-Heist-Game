using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCar : MonoBehaviour
{
    public Transform vehiclePool;
    public float radius, power, upwardsModifyer;
    //public BoxCollider col1, col2, col3, col4;

    private VehicleObjectPool objectPool;
    private float movementSpeed, speed = 600f, fallBackSpeed = 20f;
    public bool canMove, hitTr, hitTl, hitBr, hitBl, beenHit;
    private Vector3 v3 = Vector3.zero;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
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
        //this is not being set to true when spawning in
        if (canMove)
        {
            //rb.useGravity = true;
            movementSpeed = 2f;
            if (transform.position.z < 9f)
            {
                transform.position += new Vector3(0, 0, movementSpeed * Time.deltaTime);
            }
        }
        if (beenHit)
        {
            transform.position -= new Vector3(0, 0, fallBackSpeed / 2 * Time.deltaTime);
        }
    }

    IEnumerator SendBackToPool()
    {
        yield return new WaitForSeconds(3f);
        hitTr = false;
        hitTl = false;
        hitBr = false;
        hitBl = false;
        canMove = false;

        if (!objectPool.basicBadCar.Contains(gameObject))
        {
            objectPool.AddVehicleIntoPool(gameObject);
        }
        transform.position = objectPool.transform.position;
        v3 = Vector3.zero;
        transform.eulerAngles = v3;
    }
    void LaunchCar()
    {
        Vector3 explosivePos = transform.position + new Vector3(0, 0, 3f);
        rb.AddExplosionForce(power, explosivePos, radius, upwardsModifyer);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TRCol") || other.CompareTag("TLCol") || other.CompareTag("BRCol") || other.CompareTag("BLCol"))
        {
            if (!beenHit)
            {
                print("OFFICER DOWN!");
                LaunchCar();
                beenHit = true;
            }
        }
    }
}
