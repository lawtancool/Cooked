using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using Fusion;

public class SubmitFood : NetworkBehaviour
{
    public GameManager gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        NetworkObject foodGO = other.gameObject.GetComponent<NetworkObject>();
        Food food = foodGO.GetComponent<Food>();
        if (food != null)
        {
            Debug.Log(food.cookTime);
            if (food.cookTime < 0)
            {
                Runner.Despawn(foodGO);
                gameManager.IncrementCookedCount();
            }
        }
        
    }
}
