using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;

    private PlayerControles playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    //animation
    private Animator MyAnimator;
    private SpriteRenderer mySpriteRender;


    private void Awake()
    {
        playerControls = new PlayerControles();
        rb = GetComponent<Rigidbody2D>();
        MyAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    //goi playerInput
    private void Update()
    {
        PlayerInput();
    }
    //goi move
    private void FixedUpdate()
    {
        AdjustPlayerFacingDerection();
        Move();
    }
    //khoi tao ham PlayerInput
    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();

        MyAnimator.SetFloat("moveX", movement.x);
        MyAnimator.SetFloat("moveY", movement.y);

    }
    //khoi tao ham Move
    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }
    //goi ham quay mat
    private void AdjustPlayerFacingDerection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            mySpriteRender.flipX = true;
        }
        else
        {
            mySpriteRender.flipX = false;
        }
    }
}
