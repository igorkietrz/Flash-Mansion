using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieGracza1 : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isGrounded = false;
    private Vector3 movement;
    private Animator animator;
    private float change;
    private Rigidbody2D myRigidbody;
    
   
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
       myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
     
        Jump();
        movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        transform.position += movement * Time.fixedDeltaTime * moveSpeed;      

        if(movement == Vector3.zero)
        {
            animator.SetBool("moving", false);
        }
        else 
        {
            animator.SetFloat("moveX", movement.x);
            animator.SetBool("moving", true);
        }
    
    void Jump(){
        if (Input.GetButtonDown("Jump") && isGrounded == true){
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
        }
        
    }

    }
}