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

    [SerializeField] Transform point;
    [SerializeField] float radius;
    [SerializeField] LayerMask enemyMask;

    public float moveSpeed;
    public float jumpForce;
    public bool IsRun => Move != 0;

    private Rigidbody2D rb;
    private float move;
    public float Move => move;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

    }

    public void ProcessInput()
    {
        move = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (!Mathf.Approximately(move, 0))
        {
            if (move > 0)
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
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    public void DamageEnemy()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(point.position, radius, enemyMask);
        foreach (Collider2D hit in hitEnemy)
        {
            Debug.Log(hit.gameObject.name);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(point.position, radius);
    }
}
