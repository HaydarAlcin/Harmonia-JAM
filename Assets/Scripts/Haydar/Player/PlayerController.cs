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


    public Animator animator;
    public bool teleportStart;

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
            if (rb.velocity.x > 0)
            {
                animator.SetBool("Idle", false);
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
        }

    }

}
