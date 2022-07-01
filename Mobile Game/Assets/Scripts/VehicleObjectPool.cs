using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleObjectPool : MonoBehaviour
{
    public List<GameObject> basicBadCar = new List<GameObject>();
    public List<GameObject> policeCar = new List<GameObject>();

    // Start is called before the first frame update

    public void AddVehicleIntoPool(GameObject vehicle)
    {
        if (vehicle.CompareTag("BasicBadCar"))
        {
            basicBadCar.Add(vehicle);
        }
        else if (vehicle.CompareTag("PoliceCar"))
        {
            policeCar.Add(vehicle);
        }
        //else if (pickUp.CompareTag("SpeedBoost"))
        //{
        //    speedBoosts.Add(pickUp);
        //}
    }
}
