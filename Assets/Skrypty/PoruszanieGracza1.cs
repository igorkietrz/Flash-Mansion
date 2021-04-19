using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoruszanieGracza1v2 : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool isGrounded = false;
    private Animator animator;
    private Rigidbody2D myRigidbody;
    private Vector2 movement = Vector2.zero;
    [SerializeField] private float speed = 5f;
    
   
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
       myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
     Jump();
    movement.x = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
    if(movement != Vector2.zero)
    {
       animator.SetFloat("moveX", movement.x);
       animator.SetBool("moving", true);

    Vector2 velocity = (movement * speed);
      myRigidbody.velocity = velocity;
    }
    else
    {  
        animator.SetBool("moving", false);
      myRigidbody.velocity = Vector2.zero;
    }
    }
    
    void Jump(){
        if (Input.GetButtonDown("Jump") && isGrounded == true){
           gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
        }
        
    }

    
}