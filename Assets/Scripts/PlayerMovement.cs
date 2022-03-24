using System.Collections;
using Buttons;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private BoxCollider2D playerCollider;
    private SpriteRenderer spriteRenderer;
    private Animator playerAnimator;

    private JumpButton jumpButton;
    private DropdownButton dropdownButton;
    private LeftButton leftButton;
    private RightButton rightButton;

    private bool isJumping;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 15f;
    private bool isDroppingDown;

    private enum MovementState
    {
        Idle,
        Run,
        Jump,
        Fall
    }

    [SerializeField] private AudioSource jumpSoundEffect;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        jumpButton = GameObject.Find("JumpButton").GetComponent<JumpButton>();
        dropdownButton = GameObject.Find("DropdownButton").GetComponent<DropdownButton>();
        leftButton = GameObject.Find("LeftButton").GetComponent<LeftButton>();
        rightButton = GameObject.Find("RightButton").GetComponent<RightButton>();
    }

    private void Update()
    {
#if UNITY_EDITOR
        KeyboardMovement();
        // JoystickMovement();
#elif UNITY_STANDALONE_WIN
        KeyboardMovement();
#elif UNITY_ANDROID
        JoystickMovement();
#endif

        if (Input.GetKeyDown(KeyCode.S))
        {
            Dropdown();
        }

        if (!isDroppingDown)
        {
            KeyboardJump();
        }

        UpdateAnimationState();
    }

    private void KeyboardMovement()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        playerRigidbody.velocity = new Vector2(moveSpeed * dirX, playerRigidbody.velocity.y);
    }

    private void JoystickMovement()
    {
        if (leftButton.LeftPressed && !rightButton.RightPressed)
        {
            dirX = -1;
        }
        else if (rightButton.RightPressed && !leftButton.LeftPressed)
        {
            dirX = 1;
        }

        if (!leftButton.LeftPressed && !rightButton.RightPressed)
        {
            dirX = 0;
        }

        playerRigidbody.velocity = new Vector2(moveSpeed * dirX, playerRigidbody.velocity.y);

        JoystickJump();
        JoystickDropdown();
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            jumpSoundEffect.Play();
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpForce);
        }
    }

    private void KeyboardJump()
    {
        if (Input.GetButtonDown("Jump")) //Input.GetKeyDown("space")
        {
            Jump();
        }
    }

    private void JoystickJump()
    {
        if (jumpButton.JumpPressed && !isJumping)
        {
            isJumping = true;
            Jump();
        }

        if (!jumpButton.JumpPressed)
        {
            isJumping = false;
        }
    }

    private void Dropdown()
    {
        if (!isDroppingDown && IsGrounded())
        {
            StartCoroutine(DropdownFromPassableGround());
        }
    }

    private void JoystickDropdown()
    {
        if (dropdownButton.DropdownPressed)
        {
            Dropdown();
        }
    }

    private IEnumerator DropdownFromPassableGround()
    {
        var raycastHit2D = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f,
            Vector2.down, .1f,
            jumpableGround);
        if (raycastHit2D.collider.GetComponent<PlatformEffector2D>().useOneWay)
        {
            isDroppingDown = true;

            var passableTerrainCollider = raycastHit2D.collider.GetComponent<CompositeCollider2D>();
            passableTerrainCollider.isTrigger = true;

            yield return new WaitForSeconds(0.35f);

            passableTerrainCollider.isTrigger = false;

            isDroppingDown = false;
        }
    }

    private void UpdateAnimationState()
    {
        MovementState movementState;
        if (dirX > 0f)
        {
            movementState = MovementState.Run;
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0f)
        {
            movementState = MovementState.Run;
            spriteRenderer.flipX = true;
        }
        else
        {
            movementState = MovementState.Idle;
        }

        if (playerRigidbody.velocity.y > .1f)
        {
            movementState = MovementState.Jump;
        }
        else if (playerRigidbody.velocity.y < -.1f)
        {
            movementState = MovementState.Fall;
        }

        playerAnimator.SetInteger("state", (int) movementState);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, .1f,
            jumpableGround);
    }
}