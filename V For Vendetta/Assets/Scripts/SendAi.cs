using UnityEngine;

public class SendAi : MonoBehaviour
{
    [SerializeField] private BreakWashbin washbin;
    [SerializeField] private AiMove[] aiToMove;
    [SerializeField] private GameObject teleporToDisable;
    [SerializeField] private GameObject[] pickables;

    private bool playerInRange;

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && washbin.washbinIsBroken)
        {
            pickables[0].GetComponent<BoxCollider2D>().enabled = true;
            pickables[1].GetComponent<BoxCollider2D>().enabled = true;

            MoveAi();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }

    private void MoveAi()
    {
        teleporToDisable.GetComponent<TeleportPlayer>().enabled = false;

        for (int i = 0; i < aiToMove.Length; i++)
        {
            aiToMove[i].GetComponent<CheckForPlayer>().enabled = true;
            aiToMove[i].MoveToPosition(true);
        }
    }
}
