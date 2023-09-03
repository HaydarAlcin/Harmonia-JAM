using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerAnimationSystem : MonoBehaviour
{
    public GameObject sword;
    public Vector3 distance;
    public GameObject miniSword;
    public void Throw()
    {
        sword.transform.GetChild(0).gameObject.SetActive(true);
        sword.transform.GetChild(0).transform.GetChild(0).GetComponent<Collider>().enabled = true;
        sword.GetComponent<Sword>().reback = false;
        sword.transform.position = transform.position+distance;
        miniSword.SetActive(false);
    }
}
