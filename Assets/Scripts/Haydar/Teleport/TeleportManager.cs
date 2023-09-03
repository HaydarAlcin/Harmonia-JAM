using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform anotherTeleport;
    TeleportManager anotherTeleportManager;

    public bool teleportReady;

    //dotween


    private void Start()
    {
        teleportReady = true;
        anotherTeleportManager=anotherTeleport.gameObject.GetComponent<TeleportManager>();
    }

    public void Teleport(Transform Target)
    {
        if (teleportReady==true)
        { 
            Target.transform.position = anotherTeleport.position;
            anotherTeleportManager.teleportReady = false;
            teleportReady = false;
            StartCoroutine(TeleportAgain());
        }

    }


    IEnumerator TeleportAgain()
    {
        yield return new WaitForSeconds(3);
        anotherTeleportManager.teleportReady = true;
        teleportReady = true;
    }
}
