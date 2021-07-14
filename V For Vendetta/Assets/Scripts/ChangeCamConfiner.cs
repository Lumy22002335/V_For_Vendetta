using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamConfiner : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D cellV;
    [SerializeField] private PolygonCollider2D lobby;
    [SerializeField] private PolygonCollider2D garden;
    [SerializeField] private PolygonCollider2D gardenHouse;

    private CinemachineConfiner2D confiner2D;

    private float counter;

    private void Start()
    {
        confiner2D = GetComponent<CinemachineConfiner2D>();
        counter = 0;

        confiner2D.m_BoundingShape2D = cellV;
    }

    private void Update()
    {
        counter += Time.deltaTime;

        if (counter >= 122.4f)
        {
            confiner2D.m_BoundingShape2D = gardenHouse;
            enabled = false;
        }
        else if (counter >= 111.3f) 
        {
            confiner2D.m_BoundingShape2D = garden;
        }
        else if (counter >= 88.1f)
        {
            confiner2D.m_BoundingShape2D = lobby;
        }
    }
}
