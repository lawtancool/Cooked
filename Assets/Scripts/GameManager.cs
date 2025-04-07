using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using Oculus.Interaction;
using Fusion;

public class GameManager : NetworkBehaviour
{
    public Transform head;
    public GameObject manager;
    public static bool gameStarted = false;

    public float time;
    [Networked] TickTimer foodTimer { get; set; }
    [Networked] [HideInInspector] private int cookedCount { get; set; } = 0;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI orderText;
    
    public RayInteractable rayInteractable;
    public TextMeshProUGUI pressToStart;

    public void SetTrue()
    {
        gameObject.GetComponent<NetworkObject>().RequestStateAuthority();
        foodTimer = TickTimer.CreateFromSeconds(Runner, time);
        cookedCount = 0;
    }

    public void IncrementCookedCount() {
        if (gameStarted) {
            gameObject.GetComponent<NetworkObject>().RequestStateAuthority();
            cookedCount++;
        }
    }

    void Update() {
        if (OVRInput.GetDown(OVRInput.Button.Start)) {
            manager.SetActive(!manager.activeSelf);
            manager.transform.position = head.transform.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * 2f;
        }
        manager.transform.LookAt(new Vector3(head.transform.position.x, manager.transform.position.y, head.transform.position.z));
        manager.transform.forward *= -1;
        gameStarted = !foodTimer.ExpiredOrNotRunning(Runner);
        if (gameStarted) {
            timerText.text = "Time: " + foodTimer.RemainingTime(Runner)?.ToString("F2");
        } else {
            timerText.text = "Time's up!";
        }
        orderText.text = "<sprite=0>" + cookedCount.ToString();
    }
}