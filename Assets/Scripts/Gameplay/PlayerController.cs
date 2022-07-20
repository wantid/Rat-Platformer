using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;

    public bool doubleJump;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;

    private int currentLayerMask;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentLayerMask = 65;
    }

    void Update()
    {
        if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Fire1")) Jump();
        animator.SetBool("isGrounded", isGrounded());
        Physics2D.SetLayerCollisionMask(3, currentLayerMask);
    }

    private bool isGrounded()
    {
        if (rigidbody2D.velocity.y > -.5f && rigidbody2D.velocity.y < .5f)
        {
            RaycastHit2D hit;

            bool CompareGround() {
                switch (hit.collider.tag)
                {
                    case "Ground":
                        currentLayerMask = 65;
                        return true;
                    case "Station":
                        currentLayerMask = 1;
                        return true;
                    default:
                        return false;
                }
            }

            Vector2 pos = new Vector2(transform.position.x, transform.position.y - 8f);
            if (hit = Physics2D.Linecast(pos, pos + Vector2.down * 16f, currentLayerMask))
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
                GameManager.GameOver();
                Destroy(gameObject);
                break;
            case "Hit":
                rigidbody2D.AddForce(Vector2.up * jumpForce * 5000, ForceMode2D.Force);
                doubleJump = true;
                break;
            case "Bonus":
                Destroy(collision.gameObject);
                Scores.AddScore(5);
                GameManager.coin++;
                break;
        }
    }
}
