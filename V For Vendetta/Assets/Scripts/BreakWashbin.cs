using UnityEngine;

public class BreakWashbin : Interactible
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private SpriteRenderer washbinBroken;
    [SerializeField] private GameObject floorWater;

    private BoxCollider2D boxCollider2D;
    private SpriteRenderer washbin;

    public bool washbinIsBroken { get; private set; }

    private void Start()
    {
        washbin = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        washbinIsBroken = false;
    }

    public override void Interact()
    {
        foreach (Item item in playerInventory.PlayerItems)
        {
            if (item.Name == "Crowbar")
            {
                washbin.enabled = false;
                washbinBroken.enabled = true;
                washbinIsBroken = true;
                floorWater.SetActive(true);
                boxCollider2D.enabled = false;
            }
        }
    }
}
