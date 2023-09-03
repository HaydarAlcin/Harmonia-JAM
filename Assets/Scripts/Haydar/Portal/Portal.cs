using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform target;

    public Transform anotherPortal;
    public bool portalIsReady;
    public void PortalOn()
    {
        if (portalIsReady == true)
        {
            portalIsReady = false;
        }
    }
}
