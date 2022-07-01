using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadObjectPool : MonoBehaviour
{

    public List<GameObject> straightRoads = new List<GameObject>();
    public List<GameObject> leftTurnRoads = new List<GameObject>();
    public List<GameObject> rightTurnRoads = new List<GameObject>();
    // Start is called before the first frame update

    public void AddRoadIntoPool(GameObject road)
    {
        if (road.CompareTag("Straight"))
        {
            straightRoads.Add(road);
        }
        else if (road.CompareTag("LeftTurn"))
        {
            leftTurnRoads.Add(road);
        }
        else if (road.CompareTag("rightTurn"))
        {
            rightTurnRoads.Add(road);
        }
    }
}
