using UnityEngine;

public class HeroController : MonoBehaviour
{
    public float speed = 10.0f;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public Vector2 moveDirection;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        
        if (moveDirection != Vector2.zero)
        {
            sr.flipX = moveDirection.x < 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }
}
