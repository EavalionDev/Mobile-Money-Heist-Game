using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindSpawner : MonoBehaviour
{
    public VehicleObjectPool vop;
    public GameObject spawnA, spawnB, spawnC, spawnD;
    private GameObject nextVehicle;
    private float count;
    private bool spawned;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if (count >= 4f && !spawned)
        {
            SpawnInPolice();          
        } 
    }

    void SpawnInPolice()
    {
        int typeIndex = 2;
        spawned = true;
        if (typeIndex == 2 && vop.policeCar.Count > 0)
        {
            //print("SPAWN IN A COP");
            nextVehicle = vop.policeCar[0];
            vop.policeCar.Remove(nextVehicle);
            int index = Random.Range(0, 4);
            if (index == 0)
            {
                nextVehicle.transform.position = spawnA.transform.position + new Vector3(0, 2, 30f);
            }
            else if (index == 1)
            {
                nextVehicle.transform.position = spawnB.transform.position + new Vector3(0, 2, 30f);
            }
            else if (index == 2)
            {
                nextVehicle.transform.position = spawnC.transform.position + new Vector3(0, 2, 30f);
            }
            else if (index == 3)
            {
                nextVehicle.transform.position = spawnD.transform.position + new Vector3(0, 2, 30f);
            }
            bool canMove = nextVehicle.GetComponent<PoliceCar>().canMove;
            bool beenHit = nextVehicle.GetComponent<PoliceCar>().beenHit;
            //NOT TURNING TRUE
            if (!canMove)
            {
                canMove = true;
            }
            if (beenHit)
            {
                beenHit = false;
            }
        }
        count = 0;
        StartCoroutine(SetSpawnToFalse());
    }

    IEnumerator SetSpawnToFalse()
    {
        yield return new WaitForSeconds(1f);
        spawned = false;
    }
    
}
