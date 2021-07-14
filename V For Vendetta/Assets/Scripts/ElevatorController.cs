using Cinemachine;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ElevatorController : Interactible
{
    [SerializeField] private CinemachineConfiner2D confiner2D;
    [SerializeField] private GameObject player;

    [SerializeField] private AiMove labGuard;
    [SerializeField] private AiMove prisionGuard;

    // By order, 0 = Prision, 1 = Lobby, 2 = Labs
    [SerializeField] private PolygonCollider2D[] polygonConfiner;
    [SerializeField] private Transform[] teleportLocations;
    [SerializeField] private Sprite[] numberSprites;
    [SerializeField] private SpriteRenderer floorSprite;
    [SerializeField] private int currentFloor;
    [SerializeField] private int selectedFloor;

    [SerializeField] private SpriteRenderer elevatorLight;
    [SerializeField] private Light2D elevatorLight2D;

    [SerializeField] private Animator fadeAnimator;

    private PlayerInventory playerInventory;

    private Animator animator;
    private bool doorOpen;

    private bool playerInRange;
    private bool playerHasKeyCard;

    private void Start()
    {
        animator = GetComponentInParent<Animator>();

        playerHasKeyCard = false;
        playerInRange = false;
        doorOpen = false;
    }

    private void Update()
    {
        if (playerInRange && playerHasKeyCard)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                OpenDoor();
                selectedFloor = Mathf.Clamp(selectedFloor + 1, -1, 1);
                floorSprite.sprite = numberSprites[selectedFloor + 1];
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                OpenDoor();
                selectedFloor = Mathf.Clamp(selectedFloor - 1, -1, 1);
                floorSprite.sprite = numberSprites[selectedFloor + 1];
            }
        }
    }

    private void OpenDoor()
    {
        if (!doorOpen)
        {
            doorOpen = true;
            animator.SetTrigger("ElevatorOpen");
        }
    }

    private void CheckForKeyCard()
    {
        playerInventory = player.GetComponent<PlayerInventory>();

        foreach (Item item in playerInventory.PlayerItems)
        {
            if (item.Name == "Key Card")
            {
                elevatorLight.color = Color.green;
                elevatorLight2D.color = Color.green;
                playerHasKeyCard = true;
                break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;

            if (!playerHasKeyCard)
            {
                CheckForKeyCard();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    public override void Interact()
    {
        if (playerHasKeyCard && selectedFloor != currentFloor)
        {
            if (selectedFloor + 1 == 2)
            {
                labGuard.MoveToPosition();
            }
            else if (selectedFloor + 1 == 0)
            {
                prisionGuard.MoveToPosition();
            }

            fadeAnimator.SetTrigger("FadeIn");
            Invoke("TeleportPlayer", 0.5f);
            animator.SetTrigger("ElevatorClose");
        }
    }

    public void TeleportPlayer()
    {
        confiner2D.m_BoundingShape2D = polygonConfiner[selectedFloor + 1];
        player.transform.position = teleportLocations[selectedFloor + 1].position;
    }
}
