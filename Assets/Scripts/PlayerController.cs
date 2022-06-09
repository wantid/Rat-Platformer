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
        if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Fire1")) Jump();
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

            Vector2 pos = new Vector2(transform.position.x, transform.position.y - 8f);
            if (hit = Physics2D.Linecast(pos, pos + Vector2.down * 16f, (1 << 0)))
                return CompareGround();
        }
        return false;
    }
    private void Jump()
    {
        if (isGrounded() || doubleJump && !isGrounded())
        {
            doubleJump = false;
            animator.SetTrigger("Jump");
            rigidbody2D.AddForce(Vector2.up * jumpForce * 10000, ForceMode2D.Force);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Damage":
                //GameOver
                SceneManager.LoadScene(0);
                break;
            case "Hit":
                rigidbody2D.AddForce(Vector2.up * jumpForce * 5000, ForceMode2D.Force);
                doubleJump = true;
                break;
            case "Bonus":
                Destroy(collision.gameObject);
                Debug.Log("Picked up bonus!");
                //Bonus points
                break;
        }
    }
}
