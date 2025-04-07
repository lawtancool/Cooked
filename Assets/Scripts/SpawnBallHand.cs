using UnityEngine;

public class RightHandInput : MonoBehaviour
{
    public SpawnBallManager ballManager;

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            if (ballManager != null)
            {
                ballManager.RequestBallSpawn(transform.position, transform.forward);
            }
        }
    }
}
