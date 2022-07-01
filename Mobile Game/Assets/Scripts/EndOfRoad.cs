using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfRoad : MonoBehaviour
{
    public RoadObjectPool roadPool;
    public PickUpObjectPool pickUpPool;
    public GameObject spawnA, spawnB, spawnC, spawnD;
    public VehicleObjectPool vop;

    private GameObject spawningPos;
    private GameObject nextRoadPiece, nextMoneyPiece;
    private float count, vehicleSpawnTimer;
    private GameObject nextVehicle;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        vehicleSpawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        vehicleSpawnTimer += Time.deltaTime;
        if (count >= 0.7f)
        {
            nextMoneyPiece = pickUpPool.moneyStacks[0];
            pickUpPool.moneyStacks.Remove(nextMoneyPiece);
            //nextMoneyPiece.transform.position = gameObject.transform.position - new Vector3(0,2f,0);
            nextMoneyPiece.transform.position = new Vector3(Random.Range(spawnA.transform.position.x, spawnB.transform.position.x), transform.position.y - 3.3f, transform.position.z);
            nextMoneyPiece.GetComponent<PickupMovement>().canMove = true;
            count = 0;
        }

        if (vehicleSpawnTimer >= 2f)
        {
            //int typeIndex = Random.Range(1, 3);
            int typeIndex = 1;

            if (typeIndex == 1 && vop.basicBadCar.Count > 0)
            {
                nextVehicle = vop.basicBadCar[0];
                vop.basicBadCar.Remove(nextVehicle);
                int index = Random.Range(0, 4);
                if (index == 0)
                {
                    nextVehicle.transform.position = spawnA.transform.position - new Vector3(0, 0.7f, 60);
                }
                else if (index == 1)
                {
                    nextVehicle.transform.position = spawnB.transform.position - new Vector3(0, 0.7f, 60);
                }
                else if (index == 2)
                {
                    nextVehicle.transform.position = spawnC.transform.position - new Vector3(0, 0.7f, 60);
                }
                else if (index == 3)
                {
                    nextVehicle.transform.position = spawnD.transform.position - new Vector3(0, 0.7f, 60);
                }
                nextVehicle.GetComponent<BadCarMovement>().canMove = true; nextVehicle.GetComponent<BadCarMovement>().beenHit = false;
            }
            vehicleSpawnTimer = 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //store the gameobject of what left the collider
        //access the public pool, transfer an object over to the starting pos of gameobject that left collider
        if (spawningPos == null)
        {
            spawningPos = other.transform.Find("SpawnPoint").gameObject;
        }
        else
        {
            spawningPos = other.transform.Find("SpawnPoint").gameObject;
        }
        nextRoadPiece = roadPool.straightRoads[0];
        roadPool.straightRoads.Remove(nextRoadPiece);
        nextRoadPiece.transform.position = spawningPos.transform.position;
        nextRoadPiece.GetComponent<RoadMovement>().canMove = true;

    }
}
