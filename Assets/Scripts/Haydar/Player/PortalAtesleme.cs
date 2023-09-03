using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAtesleme : MonoBehaviour
{
    public int portalNumber = 0;

    public Transform portalGun;
    private Vector3 offset;

    private void Start()
    {
        offset = Vector3.zero;
    }

    public void CreatePortal()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            portalNumber = 1;
        }
    }

    private void Update()
    {
        Vector3 targetPosition = GetMouseWorldPosition() + offset;
        portalGun.DOMove(new Vector3(targetPosition.x, targetPosition.y, portalGun.position.z), 0);
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = portalGun.position.z - Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}