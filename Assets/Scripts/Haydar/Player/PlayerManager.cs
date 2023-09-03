using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : MonoBehaviour
{

    public Material targetMaterial,swordMaterial;
    public float targetAlpha = 0.0f;
    public float tweenDuration = 1.0f;

    GameObject currentTeleport;

    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            
            playerController.rb.velocity = Vector3.zero;
            playerController.teleportStart = true;
            currentTeleport = other.gameObject;
            TransparanPlayer();
            
  
        }

        
    }

    public void TransparanPlayer()
    {
        targetMaterial.DOFloat(1f, "_dissolveAmount", 1f)
            .OnComplete(() => TransparanComplete());

        swordMaterial.DOFloat(1f, "_dissolveAmount", 1f);
    }

    public void TransparanComplete()
    {
        currentTeleport.GetComponent<TeleportManager>().Teleport(transform);
        targetMaterial.DOFloat(0f, "_dissolveAmount", 0.4f);
        swordMaterial.DOFloat(0f, "_dissolveAmount", 0.4f);
        playerController.teleportStart = false;

    }

}
