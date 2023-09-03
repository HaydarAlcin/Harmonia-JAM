using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;

    public Rigidbody rb;
    public float upForce = 20f;

    //bilal
    public float jumpForce = 10.0f;
    public float fallMultiplier = 2.5f;
    private bool isGrounded;


    public Animator animator, swordAnimator;
    public bool teleportStart;
    bool justOneRotate;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    private void Update()
    {
        HorizontalMove();
        Jump();
        if (rb.velocity.y != 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }


    public void HorizontalMove()
    {
        if (teleportStart==false)
        {
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed, rb.velocity.y);

            if (rb.velocity.x !=0)
            {
                animator.SetBool("Idle", false);
                Rotation();


            }

            else if (rb.velocity.x == 0)
            {
                animator.SetBool("Idle", true);
                
            }
        }



    }


    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            animator.SetTrigger("Jump");

            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
        }
    }

    ///    SEQUENCE BAKMALISIN ////
    //public bool control;
    //Sequence Leftsequence;
    //Sequence Rightsequence;
    //public void LeftRotation()
    //{
    //    DOTween.Kill(Leftsequence);
    //    Leftsequence = DOTween.Sequence();
    //    if(rb.velocity.x <= 0f && !control)
    //    {
    //        control = true;
    //        Leftsequence.Append(transform.DORotate(new Vector3(0, 180, 0), 0.3f));

    //    }
        
    //}

    public void Rotation()
    {
        
        if (rb.velocity.x<0 && justOneRotate==false)
        {
            justOneRotate = true; 
            transform.DORotate(new Vector3(0, 180, 0), 0.3f);
            
        }

        else if (rb.velocity.x>=0&&justOneRotate==true)
        {

            justOneRotate = false;
            transform.DORotate(new Vector3(0, 0, 0), 0.3f);
            
        }
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Force"))
        {
            rb.AddForce(Vector3.up * upForce, ForceMode.Force);
            swordAnimator.SetTrigger("Force");
        }

    }

}
