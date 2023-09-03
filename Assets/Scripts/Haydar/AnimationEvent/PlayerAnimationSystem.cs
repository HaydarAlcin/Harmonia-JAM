using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAnimationSystem : MonoBehaviour
{
    public GameObject sword;
    public Vector3 distance = new Vector3(5, 2);

    public void Throw()
    {
        sword.SetActive(true);
        sword.transform.position = transform.position+distance;
    }
}
