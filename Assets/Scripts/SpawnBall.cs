// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Fusion;


// public class SpawnBall : MonoBehaviour
// {
//     [SerializeField] private NetworkObject prefab;
//     public float spawnSpeed = 5;
//     public NetworkRunner runner;

//     // Start is called once before the first execution of Update after the MonoBehaviour is created
//     void Start()
//     {
//         if (runner == null)
//             runner = FindAnyObjectByType<NetworkRunner>();
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) {
//             NetworkObject spawnedBall = runner.Spawn(prefab, transform.position, Quaternion.identity);
//             Rigidbody spawnedBallRB = spawnedBall.GetComponent<Rigidbody>();
//             spawnedBallRB.linearVelocity = transform.forward * spawnSpeed;
//         }
//     }
// }
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;
using Meta.XR.MultiplayerBlocks.Fusion;

public class SpawnBall : MonoBehaviour
{
    [Header("Ball Prefab (from Project view, not Scene)")]
    [SerializeField] private NetworkObject prefab; // Drag your prefab from Project window here

    [Header("Ball Launch Speed")]
    public float spawnSpeed = 5f;

    private NetworkRunner runner;

    void Start()
    {
        runner = FindAnyObjectByType<NetworkRunner>();
    }

    void Update()
    {
        if (runner == null || !runner.IsRunning)
        {
            Debug.LogWarning("Runner not ready yet — skipping spawn.");
            runner = FindAnyObjectByType<NetworkRunner>();
            return;
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            Debug.LogError("prefab = " + prefab);
            Debug.LogError("transform = " + transform.position);

            NetworkObject spawnedBall = runner.Spawn(
                prefab: prefab,
                position: transform.position
            );

            if (spawnedBall != null)
            {
                if (spawnedBall.TryGetComponent(out Rigidbody rb))
                {
                    rb.linearVelocity = transform.forward * spawnSpeed;
                }
            }
            else
            {
                Debug.LogError("Ball spawn failed: runner.Spawn returned null.");
            }
        }
    }
}



