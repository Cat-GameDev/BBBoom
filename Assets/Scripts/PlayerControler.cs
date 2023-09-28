using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D Rb { get => rb;}

    [SerializeField] private float moveSpeed = 5f, jumpForce = 5f;
    private bool isGrounded;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private LayerMask whatIsGround;


    private float velocity;
    private Animator anim;
    public Animator Anim { get => anim;}
    
    [SerializeField] private bool isKeyboard2;
    [SerializeField] private bool isKeyboard3, isKeyboard4;
    [SerializeField] private float timeBetweenAttacks = 0.02f;
    private float attackCounter = 0f;

    [SerializeField] private Transform ThrowPoint1, ThrowPoint2;
    public Boom LaunchableBoomPrefab;
    public BoomStraight boomPrefab;
    [SerializeField] private GameObject playName1, playName2;

    private bool doubleJump;

    private bool m_FacingRight = true;

    private void Awake()
    {
        transform.position = new Vector2(0, 0);
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameManager.Instance.AddPlayer(this);
        playName2.SetActive(false);
        playName1.SetActive(true);
    }

    void Update()
    {

        PlayerController2();
        PlayerController3();
        PlayerController4();
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);
        Rb.velocity = new Vector2(velocity * moveSpeed, Rb.velocity.y);
        if(Time.timeScale != 0)
        {
            AnimatorController();
            if (Rb.velocity.x > 0 && !m_FacingRight)
            {
                playName2.SetActive(false);
                playName1.SetActive(true);
                Flip();
            }

            else if (Rb.velocity.x < 0 && m_FacingRight)
            {
                Flip();
                playName2.SetActive(true);
                playName1.SetActive(false);
            }
        }    
    }

    private void PlayerController2()
    {
        if (isKeyboard2)
        {
            velocity = 0f;

            if (Keyboard.current.lKey.isPressed)
            {
                velocity += 1f;
            }
            else if (Keyboard.current.jKey.isPressed)
            {
                velocity += -1f;
            }

            if (Keyboard.current.enterKey.wasPressedThisFrame)
            {
                if (isGrounded)
                {
                    Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                    doubleJump = true;
                }
                else if (doubleJump)
                {
                    Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                    doubleJump = false;
                }
            }
            if (isGrounded && Keyboard.current.enterKey.wasReleasedThisFrame && Rb.velocity.y > 0f)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * .5f);
            }

            if (Keyboard.current.iKey.wasPressedThisFrame)
            {
                attackCounter += Time.fixedDeltaTime;
                if (attackCounter < timeBetweenAttacks) return;
                attackCounter = 0;
                Anim.SetTrigger("attack"); ;
                Instantiate(LaunchableBoomPrefab, ThrowPoint1.position, transform.rotation);
            }
            if (Keyboard.current.kKey.wasPressedThisFrame)
            {
                attackCounter += Time.fixedDeltaTime;
                if (attackCounter < timeBetweenAttacks) return;
                attackCounter = 0;
                Anim.SetTrigger("attack"); ;
                Instantiate(boomPrefab, ThrowPoint2.position, transform.rotation);
            }


        }
    }

    private void PlayerController3()
    {
        if (isKeyboard3)
        {
            velocity = 0f;

            if (Keyboard.current.rightArrowKey.isPressed)
            {
                velocity += 1f;
            }
            else if (Keyboard.current.leftArrowKey.isPressed)
            {
                velocity += -1f;
            }

            if (Keyboard.current.rightShiftKey.wasPressedThisFrame)
            {
                if (isGrounded)
                {
                    Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                    doubleJump = true;
                }
                else if (doubleJump)
                {
                    Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                    doubleJump = false;
                }
            }
            if (isGrounded && Keyboard.current.rightShiftKey.wasReleasedThisFrame && Rb.velocity.y > 0f)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * .5f);
            }

            if (Keyboard.current.upArrowKey.wasPressedThisFrame)
            {
                attackCounter += Time.fixedDeltaTime;
                if (attackCounter < timeBetweenAttacks) return;
                attackCounter = 0;
                Anim.SetTrigger("attack"); ;
                Instantiate(LaunchableBoomPrefab, ThrowPoint1.position, transform.rotation);
            }
            if (Keyboard.current.downArrowKey.wasPressedThisFrame)
            {
                attackCounter += Time.fixedDeltaTime;
                if (attackCounter < timeBetweenAttacks) return;
                attackCounter = 0;
                Anim.SetTrigger("attack"); ;
                Instantiate(boomPrefab, ThrowPoint2.position, transform.rotation);
            }


        }
    }

    private void PlayerController4() {
        if (isKeyboard4)
        {
            velocity = 0f;

            if (Keyboard.current.numpad3Key.isPressed)
            {
                velocity += 1f;
            }
            else if (Keyboard.current.numpad1Key.isPressed)
            {
                velocity += -1f;
            }

            if (Keyboard.current.numpadEnterKey.wasPressedThisFrame)
            {
                if (isGrounded)
                {
                    Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                    doubleJump = true;
                }
                else if (doubleJump)
                {
                    Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                    doubleJump = false;
                }
            }
            if (isGrounded && Keyboard.current.numpadEnterKey.wasReleasedThisFrame && Rb.velocity.y > 0f)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * .5f);
            }

            if (Keyboard.current.numpad5Key.wasPressedThisFrame)
            {
                attackCounter += Time.fixedDeltaTime;
                if (attackCounter < timeBetweenAttacks) return;
                attackCounter = 0;
                Anim.SetTrigger("attack"); ;
                Instantiate(LaunchableBoomPrefab, ThrowPoint1.position, transform.rotation);
            }
            if (Keyboard.current.numpad2Key.wasPressedThisFrame)
            {
                attackCounter += Time.fixedDeltaTime;
                if (attackCounter < timeBetweenAttacks) return;
                attackCounter = 0;
                Anim.SetTrigger("attack"); ;
                Instantiate(boomPrefab, ThrowPoint2.position, transform.rotation);
            }


        }
    }
     private void AnimatorController()
    {
        Anim.SetBool("isGrounded", isGrounded);
        Anim.SetFloat("ySpeed", Rb.velocity.y);
        Anim.SetFloat("speed", Mathf.Abs(Rb.velocity.x));
        Anim.SetBool("DoubleJump", doubleJump);
    }
 
    private void Flip()
    {

        m_FacingRight = !m_FacingRight;

        transform.Rotate(0f, 180f, 0f);
    }

    public void Move(InputAction.CallbackContext context)
    {
        velocity = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(context.started )
        {
            if(isGrounded)
            {
                Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
                doubleJump = true;
            } else if(doubleJump)
            {
               Rb.velocity = new Vector2(Rb.velocity.y, jumpForce);
               doubleJump= false;
            }
        }
        
        if (!isGrounded && context.canceled && Rb.velocity.y > 0f)
        {
            Rb.velocity = new Vector2(Rb.velocity.x, Rb.velocity.y * .5f);
        }

    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackCounter += Time.fixedDeltaTime;
            if (attackCounter < timeBetweenAttacks) return;
            attackCounter = 0;
            Anim.SetTrigger("attack"); ;
            Instantiate(LaunchableBoomPrefab, ThrowPoint1.position, transform.rotation);
        }
    }

    public void Attack2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            attackCounter += Time.fixedDeltaTime;
            if (attackCounter < timeBetweenAttacks) return;
            attackCounter = 0;
            Anim.SetTrigger("attack"); ;
            Instantiate(boomPrefab, ThrowPoint2.position, transform.rotation);
        }
    }



}
