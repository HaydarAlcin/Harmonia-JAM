using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sword : MonoBehaviour
{
    //saplanma
    public bool stab;
    
    //kýlýç hýzý
    public float swordSpeed;
    public float rotateSpeed;

    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        SwordMove();
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            stab = true;
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
