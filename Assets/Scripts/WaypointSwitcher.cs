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

    public GameObject pickupUI;     // Reference to the pickup UI Popup object
    public GameObject deliveryUI;   // Reference to the delivery UI Popup object

    private bool pickupUIShown = false;
    private bool deliveryUIShown = false;

    private float popupDuration = 3f;   // Duration in seconds for the popup to stay visible
    private float popupTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        waypoint.UpdateWaypoint(pickupPoints[Random.Range(0, pickupPoints.Length)]);
        deliveryComplete = false;
        score = GetComponent<Score>();

        // Disable the UI Popups at the start
        pickupUI.SetActive(false);
        deliveryUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectReaching();

        // Update the popup timer
        if (popupTimer > 0f)
        {
            popupTimer -= Time.deltaTime;

            // Check if the timer has expired
            if (popupTimer <= 0f)
            {
                // Hide the UI Popups
                pickupUI.SetActive(false);
                deliveryUI.SetActive(false);
            }
        }
    }

    public void DetectReaching()
    {
        deliverCount = Physics.OverlapSphere(transform.position, maxRange, deliverMask);
        pickupCount = Physics.OverlapSphere(transform.position, maxRange, pickupMask);

        foreach (var delivery in deliverCount)
        {
            if (delivery.gameObject == waypoint.target && !deliveryUIShown)
            {
                Debug.Log("YOU REACHED A DELIVERY!");
                waypoint.UpdateWaypoint(pickupPoints[Random.Range(0, pickupPoints.Length)]);
                bool added = false;
                if (!added)
                {
                    score.IncreaseScore();
                    added = true;
                }

                // Enable the delivery UI Popup and start the timer
                deliveryUI.SetActive(true);
                popupTimer = popupDuration;
                deliveryUIShown = true;

                // Disable the pickup UI Popup if it was shown previously
                pickupUI.SetActive(false);
                pickupUIShown = false;
            }
        }

        foreach (var pickup in pickupCount)
        {
            if (pickup.gameObject == waypoint.target && !pickupUIShown)
            {
                Debug.Log("YOU REACHED A PICKUP!");
                waypoint.UpdateWaypoint(deliveryPoints[Random.Range(0, deliveryPoints.Length)]);

                // Enable the pickup UI Popup and start the timer
                pickupUI.SetActive(true);
                popupTimer = popupDuration;
                pickupUIShown = true;

                // Disable the delivery UI Popup if it was shown previously
                deliveryUI.SetActive(false);
                deliveryUIShown = false;
            }
        }
    }

}
