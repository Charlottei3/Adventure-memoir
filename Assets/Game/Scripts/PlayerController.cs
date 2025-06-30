using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;

public class PlayerController : MonoBehaviour
{
    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }

    [Header("-------------Attack, move & jumb ------------")]
    [SerializeField] Transform point;
    [SerializeField] float radius;
    [SerializeField] LayerMask enemyMask;
    public float moveSpeed;
    public float jumpForce;
    public bool IsRun => Move != 0;

    private Rigidbody2D _rb;
    private float _move;

    [Header("-------------Wall Slide  System ------------")]
    [SerializeField] private Transform _wallCheck;
    [SerializeField] private LayerMask _wallLayer;
    [SerializeField] private float _wallSlidingSpeed;
    [SerializeField] private float _radiusWall;
    private bool _isWallsliding;

    [Header("-------------Wall Jump System ------------")]
    private bool _isWallJump;
    public float wallJumpForce = 10f; // Adjust this value as needed

    [Header("------------- Ground System ------------")]
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _groundCheck;

    public bool IswallJump => _isWallJump;
    public bool IsGrounded => Physics2D.OverlapCircle(_groundCheck.position, .2f, _groundLayer);
    public bool IsWalled => Physics2D.OverlapCircle(_wallCheck.position, _radiusWall, _wallLayer);
    public bool IsFalled => !IsGrounded && !IsWalled;
    public float Move => _move;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {


    }

    private void FixedUpdate()
    {
        WallSlide();
    }

    public void ProcessInput()
    {
        _move = Input.GetAxisRaw("Horizontal");

        _rb.velocity = new Vector2(_move * moveSpeed, _rb.velocity.y);

        if (!Mathf.Approximately(_move, 0))
        {
            if (_move > 0)
            {
                transform.localScale = Vector2.one;
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
    }

    public void Jump()
    {
        //if (IsWalled)
        //{
        //    WallJump();
        //    return;
        //}
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
    }

    public void DamageEnemy()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(point.position, radius, enemyMask);
        foreach (Collider2D hit in hitEnemy)
        {
            Debug.Log(hit.gameObject.name);
        }
    }


    public void WallSlide()
    {
        //if (_isWallJump) return;
        if (IsWalled && !IsGrounded)
        {
            _isWallsliding = true;
            _rb.velocity = new Vector2(_rb.velocity.x, -_wallSlidingSpeed);
            _isWallJump = true;

        }
        else
        {
            _isWallsliding = false;
        }
        //Debug.Log(IswallJump);
    }

    public void WallJump()
    {
        if (_isWallJump)
        {
            int wallDir = transform.localScale.x > 0 ? -1 : 1;

            float xForce = wallDir * wallJumpForce * 0.5f;
            float yForce = wallJumpForce * 5f;

            _rb.velocity = new Vector2(xForce, yForce);


            _isWallJump = false;
        }
    }

    private void StopJumpWall()
    {
        _isWallJump = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.position, radius);
        Gizmos.DrawWireSphere(_wallCheck.position, _radiusWall);
        Gizmos.DrawWireSphere(_groundCheck.position, .2f);
    }
}
