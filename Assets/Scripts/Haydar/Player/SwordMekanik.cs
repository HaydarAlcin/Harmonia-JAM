using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwordMekanik : MonoBehaviour
{
    public GameObject sword;
    public Animator animator;
    public GameObject miniSword;
    public bool swordReady;

    //kýlýcýn gittiði max mesafe
    public Vector3 distance = new Vector3(5, 0);

    PlayerController playerController;
    Sword swordCode;

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        sword.transform.position=transform.position + distance;

        //swordReady = true;

        playerController = GetComponent<PlayerController>();
        swordCode= sword.GetComponent<Sword>();
    }
    private void Update()
    {
        ThrowSword();
        BackThePlayer();
    }

    public void ThrowSword()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)&&swordReady==true)
        {
            //if (playerController.transform.rotation.y <= -180)
            //{
            //    sword.transform.GetChild(0).rotation = Quaternion.Euler(0, 180, 0);
                
            //}
            //else if (playerController.transform.rotation.y >= 0)
            //{
            //    sword.transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
                
            //}
            animator.SetTrigger("Throw");
            swordReady=false;
        }   
    }

    public void BackThePlayer()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Kýlýç geri çaðýr
            //sword.SetActive(false);
            sword.transform.GetComponent<Collider>().enabled = false;
            //SÜREDEN DOLAYI BÖYLE SAÇMA BÝR KOD YAZILMIÞTIR
            sword.transform.GetChild(0).transform.GetChild(0).GetComponent<Collider>().enabled = false;
            if (sword.transform.position.x > transform.position.x)
            {
                sword.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                sword.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
            }


            sword.transform.DOMove(transform.position+distance, 0.3f).OnComplete(() => BackThePlayerComplete());
            

            
            
        }
    }


    public void BackThePlayerComplete()
    {

        sword.transform.GetComponent<Collider>().enabled = true;
        miniSword.SetActive(true);
        swordReady = true;
        sword.transform.GetChild(0).transform.GetChild(0).GetComponent<Collider>().enabled = false;
        sword.transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
        sword.GetComponent<Rigidbody>().isKinematic = false;
        sword.GetComponent<Sword>().stab = false;
        sword.transform.GetChild(0).gameObject.SetActive(false);
        sword.GetComponent<Sword>().reback = true;


    }
}
