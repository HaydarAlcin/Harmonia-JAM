using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SwordMekanik : MonoBehaviour
{
    public GameObject sword;
    public Animator animator;
    public GameObject miniSword;

    //kýlýcýn gittiði max mesafe
    public Vector3 distance = new Vector3(5, 0);

    private void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        sword.transform.position=transform.position + distance;
    }
    private void Update()
    {
        ThrowSword();
        BackThePlayer();
    }

    public void ThrowSword()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetTrigger("Throw");
            miniSword.SetActive(false);
            
        }   
    }

    public void BackThePlayer()
    {
        if (Input.GetKey(KeyCode.F))
        {
            //Kýlýç geri çaðýr
            //sword.SetActive(false);
            sword.transform.DOMove(transform.position+distance, 0.8f).OnComplete(() => BackThePlayerComplete());
            

        }
    }


    public void BackThePlayerComplete()
    {
        sword.SetActive(false);
        sword.GetComponent<Sword>().stab = false;
        sword.GetComponent<Rigidbody>().isKinematic = false;
        miniSword.SetActive(true);


    }
}
