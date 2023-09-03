using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;

public class Sword : MonoBehaviour
{
    //saplanma
    public bool stab,reback;
    
    //kýlýç hýzý
    public float swordSpeed;
    public float rotateSpeed;

    public Rigidbody rb;

    public PlayerController playerController;
    public PlayerAnimationSystem playerAnimationSystem;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerController=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (reback==true)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 180, 0);
                swordSpeed = -25;
                playerAnimationSystem.distance = new Vector3 (-5, 2, 0);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
                swordSpeed = 25;
                playerAnimationSystem.distance = new Vector3(5, 2, 0);
            }
        }
        SwordMove();
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            stab = true;
            Debug.Log("girdi" + other.gameObject.name);
            rb.isKinematic = true;
            transform.GetChild(0).rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void SwordMove()
    {
        if (stab==false)
        {
            
            transform.position += Vector3.right * swordSpeed * Time.deltaTime;
            transform.GetChild(0).transform.Rotate(Vector3.right*rotateSpeed*Time.deltaTime);
        }
    }
}
