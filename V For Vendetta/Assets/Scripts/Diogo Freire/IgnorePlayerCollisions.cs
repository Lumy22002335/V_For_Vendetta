using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnorePlayerCollisions : MonoBehaviour
{
    private Collider2D myCollider;
    [SerializeField] private Collider2D playerCollider;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(myCollider, playerCollider);
    }
}
