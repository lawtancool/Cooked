using Fusion;
using UnityEngine;

public class PrefabSpawnManager : NetworkBehaviour
{

    public NetworkObject RequestPrefabSpawn(NetworkObject prefab, Vector3 spawnPos, Quaternion spawnRotation)
    {
        // if (!HasStateAuthority || Runner == null || !Runner.IsRunning)
        // {
        //     Debug.LogWarning("SpawnBallManager: Cannot spawn, not authoritative or runner not ready.");
        //     return;
        // }

        NetworkObject spawnedPrefab = Runner.Spawn(prefab, spawnPos, spawnRotation, Object.InputAuthority);
        return spawnedPrefab;
    }
}
