using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    Vector2 moveDirection;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        SetAnimation();
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveDirection * speed * Time.fixedDeltaTime);
    }

    public void SetMoveDirection(Vector2 direction)
    {
        moveDirection = direction.normalized;
    }

    void SetAnimation()
    {
        anim.SetFloat("Move", moveDirection.magnitude);
        if (moveDirection.magnitude > 0)
            sr.flipX = moveDirection.x < 0;
    }
}
