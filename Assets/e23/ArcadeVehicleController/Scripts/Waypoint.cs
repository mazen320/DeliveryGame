using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Waypoint : MonoBehaviour
{
    public GameObject[] deliveryPoints;
    public GameObject target;
    public GameObject player;

    public Image img;
    public TextMeshProUGUI waypointNumber;

    private float minX;
    private float maxX;
    private float minY; 
    private float maxY;

    public Vector3 pos;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FindWaypoint();
    }

    public void FindWaypoint()
    {
        minX = img.GetPixelAdjustedRect().width / 2;
        maxX = Screen.width - minX;

        minY = img.GetPixelAdjustedRect().height / 2;
        maxY = Screen.height - minY;

        pos = Camera.main.ScreenToWorldPoint(target.transform.position + offset);

        if (Vector3.Dot((target.transform.position - player.transform.position), transform.forward) < 0)
        {
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        img.transform.position = pos;
        waypointNumber.text = ((int)Vector3.Distance(target.transform.position, player.transform.position)).ToString() + "m";

    }

    public void UpdateWaypoint(GameObject newPosition)
    {
        target = newPosition;
    }
}
