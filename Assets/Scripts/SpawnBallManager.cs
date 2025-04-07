using Fusion;
using UnityEngine;

public class SpawnBallManager : NetworkBehaviour
{
    [SerializeField] private NetworkObject prefab;
    [SerializeField] private float spawnSpeed = 5f;

    public void RequestBallSpawn(Vector3 spawnPos, Vector3 direction)
    {
        // if (!HasStateAuthority || Runner == null || !Runner.IsRunning)
        // {
        //     Debug.LogWarning("SpawnBallManager: Cannot spawn, not authoritative or runner not ready.");
        //     return;
        // }

        NetworkObject spawnedBall = Runner.Spawn(prefab, spawnPos, Quaternion.identity, Object.InputAuthority);

        if (spawnedBall != null && spawnedBall.TryGetComponent(out Rigidbody rb))
        {
            rb.linearVelocity = direction * spawnSpeed;
        }
    }
}
