using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;
        private bool doublejump = false;
        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;
        private GameManager gameManager;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            //moveInput = Input.GetAxis("Horizontal");
            Vector3 direction = transform.right;
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
            animator.SetInteger("playerState", 1); // Turn on run animation
          
            if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            if (isGrounded)
            {
                doublejump = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) 
            {
                if (isGrounded)
                {
                    rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                }
                else if (doublejump)
                {
                    rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
                    rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                    doublejump = false;
                }
            }
            if (!isGrounded)animator.SetInteger("playerState", 2); // Turn on jump animation

            if(facingRight == false)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else
            {
                deathState = false;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
            }
        }
    }
}
