using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> playerItems;
    public List<Item> PlayerItems { get => playerItems;
        set {
            if (value is Item) {
                playerItems.Add((Item)value);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerItems = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            foreach(Item item in playerItems) 
            {
                print(item.Name);
            }
        }
    }
}
