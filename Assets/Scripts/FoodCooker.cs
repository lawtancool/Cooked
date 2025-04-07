using Oculus.Interaction;
using UnityEngine;
using TMPro;
using System.Linq;
using System.Collections;
using System;
using Unity.XR.CoreUtils;
using Fusion;

public class FoodCooker : NetworkBehaviour
{
    [SerializeField]
    private SnapInteractable snapInteractable;

    public override void FixedUpdateNetwork()
    {
        // if (!HasStateAuthority) return; // Only run on authority side
        if (snapInteractable.SelectingInteractors.Any())
        {
            var interactor = snapInteractable.SelectingInteractors.First().gameObject;
            Debug.Log(interactor);
            Food food = interactor.transform.parent.GetComponent<Food>();
            if (food != null)
            {
                Debug.Log("attempting to cook");
                food.cookTime -= Runner.DeltaTime;
            }
        }
    }
}
