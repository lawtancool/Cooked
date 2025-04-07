using Oculus.Interaction;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections;
using System;
using Unity.XR.CoreUtils;
using Fusion;
using System.Collections.Generic;

public class FoodCookerCollider : NetworkBehaviour
{
    private List<GameObject> foodList = new List<GameObject>();

    void OnCollisionEnter(Collision collision)
    {
        GameObject foodGO = collision.gameObject;
        Debug.Log("collision object: " + foodGO);

        Food food = foodGO.GetComponent<Food>();
        if (food != null && !foodList.Contains(foodGO)) {
            // foodGO.GetComponent<NetworkObject>().RequestStateAuthority();
            foodList.Add(foodGO);
            Debug.Log("Added food to list: " + food);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        GameObject foodGO = collision.gameObject;
        Food food = foodGO.GetComponent<Food>();
        if (food != null && foodList.Contains(foodGO)) {
            foodList.Remove(foodGO);
            Debug.Log("Removed food from list: " + food);
        }
    }

    void Update()
    {
        foreach (GameObject g in foodList) {
            if (g.GetComponent<NetworkObject>().HasStateAuthority) {
                Food f = g.GetComponent<Food>();
                Debug.Log("Cooking food: " + f);
                f.cookTime -= Runner.DeltaTime;
            } 
            // else {
            //     Debug.Log("Current state authority: " + g.GetComponent<NetworkObject>().StateAuthority);
            // }
        }
        GameObject sound = transform.Find("SoundObject")?.gameObject;
        if (sound != null) {
            sound.SetActive(foodList.Any());
        }
    }
}
