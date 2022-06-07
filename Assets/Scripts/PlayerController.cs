using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;

    public bool doubleJump;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Jump();
        animator.SetBool("isGrounded", isGrounded());
    }
    private bool isGrounded()
    {
        if (rigidbody2D.velocity.y > -.5f && rigidbody2D.velocity.y < .5f)
        {
            RaycastHit2D hit;

            bool CompareGround() {
                if (hit.collider.CompareTag("Ground")) return true;
                else return false;
            }

            Vector2 pos = transform.position;
            if (hit = Physics2D.Linecast(pos, pos + Vector2.down * 20f, (1 << 0)))
                return CompareGround();
        }
        return false;
    }
    private void Jump()
    {
        if ((Input.GetButtonDown("Vertical") || Input.GetButtonDown("Fire1")) 
            && (isGrounded() || doubleJump))
        {
            doubleJump = false;
            animator.SetTrigger("Jump");
            rigidbody2D.AddForce(Vector2.up * jumpForce * 10000, ForceMode2D.Force);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            //GameOver
            SceneManager.LoadScene(0);
        }
    }
}
