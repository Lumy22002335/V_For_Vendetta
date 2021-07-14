using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForPlayer : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject caughtMessage;

    private AiMove aiMove;
    private GameObject player;
    private MoveDirection moveDirection;
    private RaycastHit2D hit;
    private bool playerHit;
    private float deathDelay;

    // Start is called before the first frame update
    void Start()
    {
        aiMove = GetComponent<AiMove>();
        playerHit = false;
        deathDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = aiMove.Direction;
        hit = Physics2D.Raycast(transform.position, Vector2.right, moveDirection == MoveDirection.Left ? -2f : 2f, playerLayer);

        if (hit && !playerHit)
        {
            aiMove.enabled = false;
            player = hit.transform.gameObject;
            player.GetComponent<Movement>().enabled = false;

            if (CompareTag("Guard"))
            {
                GetComponent<Animator>().SetTrigger("Shoot");
                player.GetComponent<Animator>().SetTrigger("Die");
            }
            
            playerHit = true;
        }

        if (playerHit)
        {
            deathDelay += Time.deltaTime;

            if (deathDelay > 2.5f)
            {
                caughtMessage.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
