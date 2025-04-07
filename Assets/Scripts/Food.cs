using UnityEngine;
using Fusion;

public class Food : NetworkBehaviour
{

    public GameObject cookedPrefab;

    public float defaultCookTime;

    [Networked] [HideInInspector] [OnChangedRender(nameof(OnCookTimeChanged))]
    public float cookTime { get; set; } = 2;

    private bool cooked = false;

    public override void Spawned()
    {
        if (HasStateAuthority)
        {
            cookTime = defaultCookTime;
            Debug.Log($"[{Runner.LocalPlayer.PlayerId}] cookTime initialized to {cookTime} (authority)");
        }
        else
        {
            Debug.Log($"[{Runner.LocalPlayer.PlayerId}] Proxy Spawned, cookTime will be synced from network.");
        }
    }


    public void cookFood()
    {
        if (this.cookedPrefab != null && !this.cooked)
        {
            Debug.Log("Cooking food");
            GameObject parent = gameObject;
            foreach (Transform child in parent.transform) {
                Debug.Log(child);
                if (child.CompareTag("RawSteak")) {
                    Destroy(child.gameObject);
                }
            }
            GameObject cookedFoodPrefab = this.cookedPrefab;
            MeshFilter rawMeshFilter = parent.AddComponent<MeshFilter>();
            MeshRenderer rawRenderer = parent.AddComponent<MeshRenderer>();

            MeshFilter cookedMeshFilter = cookedFoodPrefab.GetComponent<MeshFilter>();
            MeshRenderer cookedRenderer = cookedFoodPrefab.GetComponent<MeshRenderer>();

            rawMeshFilter.mesh = cookedMeshFilter.mesh;
            rawRenderer.materials = cookedRenderer.materials;
            this.cooked = true;
        }
    }

    // public override void FixedUpdateNetwork()
    // {
    //     if (HasStateAuthority)
    //     {
    //         Debug.Log($"[{Runner.LocalPlayer.PlayerId}] cookTime (authority) = {cookTime}");
    //         if (cookTime < 0 && !cooked)
    //         {
    //             cookFood();
    //         }
    //     }
    //     else
    //     {
    //         // Optional: you can still log for testing
    //         Debug.Log($"[{Runner.LocalPlayer.PlayerId}] cookTime (proxy) = {cookTime}");
    //     }
    // }


    void OnCookTimeChanged() {
        Debug.Log("cookTime = " + this.cookTime);
        if (this.cookTime < 0) {
            cookFood();
        }
    }

    // void Start()
    // {
    //     cookTime = defaultCookTime;
    // }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log("cookTime = " + this.cookTime);
    // }
}
