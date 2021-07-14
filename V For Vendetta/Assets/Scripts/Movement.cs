using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runmodifier;
    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;
    [SerializeField] private Transform leftFollowPoint;
    [SerializeField] private Transform rightFollowPoint;
    [SerializeField] private Transform camFollowTarget;

    private Rigidbody2D rb;
    private float moveH;
    private Animator animator;
    private SpriteRenderer spriteRender;
    
    private MoveDirection direction;

    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
        direction = MoveDirection.Right;
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * (Input.GetKey(KeyCode.LeftShift) ? runmodifier : moveSpeed), rb.velocity.y);

        if (rb.velocity.x > 0) 
        {
            direction = MoveDirection.Right;
            camFollowTarget.parent = rightFollowPoint;
        }
        else if (rb.velocity.x < 0) 
        {
            direction = MoveDirection.Left;
            camFollowTarget.parent = leftFollowPoint;
        }

        camFollowTarget.transform.localPosition = Vector3.Lerp(camFollowTarget.transform.localPosition, Vector3.zero, 0.005f);

        animator.SetBool("IsWalking", rb.velocity.x != 0);
        spriteRender.flipX = direction == MoveDirection.Right;
    }

    private void OnDisable()
    {
        spriteRender.flipX = direction == MoveDirection.Right;
        animator.SetBool("IsWalking", false);
    }

}

public enum MoveDirection 
{
    Right,
    Left
}