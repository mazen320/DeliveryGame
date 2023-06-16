using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwitcher : MonoBehaviour
{
    public Waypoint waypoint;

    public GameObject[] pickupPoints;
    public GameObject[] deliveryPoints;
    public bool deliveryComplete;

    public KeyCode deliverButton;
    // Start is called before the first frame update
    void Start()
    {
        waypoint.UpdateWaypoint(pickupPoints[Random.Range(0, pickupPoints.Length)]);
        deliveryComplete = false;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CompleteDelivery()
    {
        deliveryComplete = true;
        waypoint.UpdateWaypoint(pickupPoints[Random.Range(0, pickupPoints.Length)]);
    }
    public void FindNewDelivery()
    {
        deliveryComplete = false;
        waypoint.UpdateWaypoint(deliveryPoints[Random.Range(0, deliveryPoints.Length)]);
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var point in pickupPoints)
        {
           
                if (other.tag == point.tag)
                {
                    Debug.Log("YOU'VE DELIVERED!");
                    FindNewDelivery();

                }
            
        }

        foreach (var point in deliveryPoints)
        {
            if (deliveryComplete == false)
            {
                if (other.tag == point.tag && Input.GetKeyDown(deliverButton))
                {
                    CompleteDelivery();
                }
            }
        }
    }
}
