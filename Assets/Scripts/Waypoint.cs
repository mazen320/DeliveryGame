using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Waypoint : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    public Image waypointImage;
    public TextMeshProUGUI waypointText;

    private Camera mainCamera;

    // This buffer is a percentage of screen width
    private float edgeBuffer = 0.05f;

    void Start()
    {
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player");

    }

    public void Update()
    {
        Vector3 targetDirection = target.transform.position - player.transform.position;
        Vector3 forwardDirection = mainCamera.transform.forward;

        float dot = Vector3.Dot(targetDirection.normalized, forwardDirection);
        float angle = Vector3.SignedAngle(forwardDirection, targetDirection, Vector3.up);

        float normalizedHorizontalPosition = (angle + 180) / 360;

        Vector3 screenPos;

        if (dot < 0)
        {
            float xPosition = Mathf.Clamp01(normalizedHorizontalPosition + edgeBuffer);
            screenPos = new Vector3(xPosition * Screen.width, edgeBuffer * Screen.height, 0);
        }
        else
        {
            screenPos = mainCamera.WorldToScreenPoint(target.transform.position);
            screenPos.x = Mathf.Clamp(screenPos.x, edgeBuffer * Screen.width, (1 - edgeBuffer) * Screen.width);

            if (screenPos.y < 0 || screenPos.y > Screen.height)  // Off-screen
            {
                float xPosition = Mathf.Clamp01(normalizedHorizontalPosition + edgeBuffer);
                screenPos = new Vector3(xPosition * Screen.width, screenPos.y, 0);
            }
        }

        waypointImage.rectTransform.position = screenPos;
        waypointText.rectTransform.position = screenPos + new Vector3(0, dot < 0 ? -20 : 20, 0);

        int distance = Mathf.RoundToInt(Vector3.Distance(player.transform.position, target.transform.position));
        waypointText.text = distance.ToString() + "m";

    }


    /// <summary>
    /// changes the waypoint target to newPosition
    /// </summary>
    /// <param name="newPosition"></param>
    public GameObject UpdateWaypoint(GameObject newPosition)
    {
        target = newPosition;
        return target;
    }
}
