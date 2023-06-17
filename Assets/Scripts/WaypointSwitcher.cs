using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwitcher : MonoBehaviour
{
    public Waypoint waypoint;

    public GameObject[] pickupPoints = new GameObject[20];
    public GameObject[] deliveryPoints = new GameObject[20];
    public bool deliveryComplete;

    public KeyCode deliverButton;

    public GameObject currentWaypoint;

    public float maxRange;

    private Collider[] deliverCount;
    private Collider[] pickupCount;

    public LayerMask deliverMask;
    public LayerMask pickupMask;

    bool deliver;
    bool pickup;

    public Score score;
    // Start is called before the first frame update
    void Start()
    {
        waypoint.UpdateWaypoint(pickupPoints[Random.Range(0, pickupPoints.Length)]);
        deliveryComplete = false;
        score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        DetectReaching();
    }

    public void DetectReaching()
    {
        deliverCount = Physics.OverlapSphere(transform.position, maxRange, deliverMask);
        pickupCount = Physics.OverlapSphere(transform.position, maxRange, pickupMask);


        deliver = deliverCount.Length > 0;
        pickup = pickupCount.Length > 0;

        if (deliver)
        {
            Debug.Log("YOU REACHED A DELIVERY!");
            waypoint.UpdateWaypoint(pickupPoints[0].gameObject);
            bool added = false;
            if (!added)
            {
                score.IncreaseScore();
                added = true;
            }
        }
        if (pickup)
        {
            Debug.Log("YOU REACHED A PICKUP!");
            waypoint.UpdateWaypoint(deliveryPoints[0].gameObject);
        }

    }
}
