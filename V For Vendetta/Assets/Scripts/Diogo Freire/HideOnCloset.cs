using UnityEngine;

public class HideOnCloset : Interactible
{
    [SerializeField] private Movement playerMovement;
    [SerializeField] private SpriteRenderer playerRender;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite playerInSprite;

    private SpriteRenderer spriteRenderer;
    private bool playerInside;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerInside = false;
    }

    public override void Interact()
    {
        if (playerInside)
        {
            spriteRenderer.sprite = defaultSprite;
            playerRender.gameObject.layer = LayerMask.NameToLayer("Player");

            playerInside = false;
        }
        else
        {
            spriteRenderer.sprite = playerInSprite;
            playerRender.gameObject.layer = LayerMask.NameToLayer("Default");

            playerInside = true;
        }

        playerMovement.enabled = !playerMovement.enabled;
        playerRender.enabled = !playerRender.enabled;
    }
}
