using UnityEngine;

public class LightSwitch : Interactible
{
    [SerializeField] private GameObject[] lamps;

    public override void Interact()
    {
        for (int i = 0; i < lamps.Length; i++)
        {
            lamps[i].SetActive(!lamps[i].activeSelf);
        }
    }
}
