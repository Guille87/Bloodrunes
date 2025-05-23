using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Controls controls;
    Vector2 movement;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        controls = new Controls();
        controls.Player.Attack.performed += _ => Attack();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        ReadInput();
        SetAnimation();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void ReadInput()
    {
        movement = controls.Player.Move.ReadValue<Vector2>();
    }

    void SetAnimation()
    {
        anim.SetFloat("move", movement.magnitude);
        if (movement.magnitude > 0)
            sr.flipX = movement.x < 0;
    }

    void Attack()
    {
        anim.SetTrigger("attack");
    }
}
