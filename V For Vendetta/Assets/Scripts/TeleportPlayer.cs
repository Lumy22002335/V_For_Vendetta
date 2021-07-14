using UnityEngine;
using Cinemachine;

public class TeleportPlayer : Interactible
{
    [SerializeField] private CinemachineConfiner2D confiner2D;
    [SerializeField] private PolygonCollider2D polygonConfiner;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform teleportLocation;
    [SerializeField] private bool isLocked;
    [SerializeField] private Animator fadeAnimator;

    private PlayerInventory playerInventory;

    public override void Interact()
    {
        if (isLocked)
        {
            playerInventory = player.GetComponent<PlayerInventory>();

            foreach ( Item item in playerInventory.PlayerItems) {
                if (item.Name == "Master Key")
                {
                    fadeAnimator.SetTrigger("FadeIn");
                    Invoke("Teleport", 0.5f);
                    break;
                }
            }
        }
        else
        {
            fadeAnimator.SetTrigger("FadeIn");
            Invoke("Teleport", 0.5f);
        }
    }

    public void Teleport()
    {
        confiner2D.m_BoundingShape2D = polygonConfiner;
        player.transform.position = teleportLocation.position;
    }

}
