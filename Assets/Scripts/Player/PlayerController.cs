using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float normalSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    Controls controls;
    Vector2 movement;
    float lastHorizontalDirection;
    float speed;

    public bool IsLookingRight { get; private set; } = true;
    public bool IsAttacking { get; private set; } = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        controls = new Controls();
        controls.Player.Attack.performed += _ => Attack();
        controls.Player.Dash.performed += _ => Dash();

        speed = normalSpeed;
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
        {
            if (movement.x != 0)
            {
                lastHorizontalDirection = movement.x;
            }

            sr.flipX = lastHorizontalDirection < 0;
            IsLookingRight = !sr.flipX;
        }
    }

    void Attack()
    {
        anim.SetTrigger("attack");
    }

    void OnAttackStart()
    {
        IsAttacking = true;
        Debug.Log("Attack started");
    }

    void OnAttackEnd()
    {
        IsAttacking = false;
        Debug.Log("Attack ended");
    }

    void Dash()
    {
        speed = dashSpeed;
        Invoke(nameof(ResetSpeed), dashTime);
    }

    void ResetSpeed()
    {
        speed = normalSpeed;
    }
}
