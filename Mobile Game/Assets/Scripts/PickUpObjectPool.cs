using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjectPool : MonoBehaviour
{
    public List<GameObject> moneyStacks = new List<GameObject>();
    public List<GameObject> moneyBags = new List<GameObject>();
    public List<GameObject> speedBoosts = new List<GameObject>();
    // Start is called before the first frame update

    public void AddPickUpIntoPool(GameObject pickUp)
    {
        if (pickUp.CompareTag("MoneyStack"))
        {
            moneyStacks.Add(pickUp);
        }
        //else if (pickUp.CompareTag("MoneyBag"))
        //{
        //    moneyBags.Add(pickUp);
        //}
        //else if (pickUp.CompareTag("SpeedBoost"))
        //{
        //    speedBoosts.Add(pickUp);
        //}
    }
}
