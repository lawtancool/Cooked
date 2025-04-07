using UnityEngine;
using Fusion;

public class FoodSpawnerCollider : NetworkBehaviour
{
 public NetworkObject rawFood;  // Assign a food prefab in the Inspector
    public Transform spawnPoint;   // Assign a spawn location
    private NetworkObject currentSpawnedObject;
    private bool canSpawn = true;
    public float respawnDistance = 0.5f;
    
    public OVRInput.Controller leftController = OVRInput.Controller.LTouch;
    public OVRInput.Controller rightController = OVRInput.Controller.RTouch;

   

    void Update()
    {
        if (currentSpawnedObject != null)
        {
            float distance = UnityEngine.Vector3.Distance(currentSpawnedObject.transform.position, spawnPoint.position);
            
            // If moved beyond threshold, allow spawning another object
            if (distance > respawnDistance)
            {
                canSpawn = true;
                currentSpawnedObject = null;  // Reset reference
            }
        }

            // Check if either controller's index trigger is pressed and is selecting the spawn point
            // if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, rightController) ||
            //     OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, leftController))
            // {
            //     UnityEngine.Vector3 posRight = OVRInput.GetLocalControllerPosition(rightController);
            //     UnityEngine.Vector3 posLeft = OVRInput.GetLocalControllerPosition(leftController);
               
                
            //     Debug.Log("Index Trigger Pressed");
            //     Debug.Log(other);
            //     // if (isColliding)
            //     // {
            //     //     Debug.Log("Target Object is being grabbed!");
            //     //     TrySpawnNewObject();
            //     // }
            // }
    }

    public void TrySpawnNewObject()
    {
        if (canSpawn && rawFood != null && spawnPoint != null)
        {
            Debug.Log(Runner);
            // spawnManager = FindAnyObjectByType<PrefabSpawnManager>();
            // if (spawnManager == null)
            // {
            //     Debug.LogError("spawnManager not found");
            //     return;
            // }
            // currentSpawnedObject = spawnManager.RequestPrefabSpawn(rawFood, spawnPoint.position, spawnPoint.rotation);
            currentSpawnedObject = Runner.Spawn(rawFood, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Spawned a new object at " + spawnPoint.position);
            canSpawn = false; // Prevent spawning until object moves

            GameObject sound = transform.Find("SoundObject")?.gameObject;
            if (sound != null) {
                sound.GetComponent<AudioSource>().Play();
            }
        }
    }
}
