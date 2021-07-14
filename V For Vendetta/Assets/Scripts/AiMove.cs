using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMove : MonoBehaviour
{
    [SerializeField] private Transform[] targetPositions;
    [SerializeField] private bool multipleTargets;
    [SerializeField] private int startTarget;
    [SerializeField] private float idleTime;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool move;
    private bool disableOnTarget;
    private int currentTarget;
    private float idleTimer;

    public MoveDirection Direction { get; private set; }

    public bool AtPosition { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentTarget = startTarget;
        idleTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPositions[currentTarget].position, CompareTag("Guard") ? 0.0086f : 0.008f);
            animator.SetBool("Walking", true);

            if (transform.position.x > targetPositions[currentTarget].position.x)
            {
                spriteRenderer.flipX = false;
                Direction = MoveDirection.Left;
            }
            else if (transform.position.x < targetPositions[currentTarget].position.x)
            {
                spriteRenderer.flipX = true;
                Direction = MoveDirection.Right;
            }
        }

        if (Vector3.Distance(transform.position, targetPositions[currentTarget].position) < 0.01f && !multipleTargets)
        {
            if (disableOnTarget)
            {
                gameObject.SetActive(false);
            } 
            else
            {
                AtPosition = true;
                animator.SetBool("Walking", false);
            }
        }
        else if (Vector3.Distance(transform.position, targetPositions[currentTarget].position) < 0.01f && multipleTargets)
        {
            animator.SetBool("Walking", false);

            AtPosition = true;

            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTime)
            {
                idleTimer = 0;
                currentTarget = currentTarget == 1 ? 0 : 1;
                AtPosition = false;
            }
        }
    }

    private void OnDisable()
    {
        animator.SetBool("Walking", false);
    }

    public void MoveToPosition(bool disableOnTarget = false)
    {
        this.disableOnTarget = disableOnTarget;
        move = true;
    }
}
