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
    }

    void Update()
    {
        Vector3 targetDirection = target.transform.position - player.transform.position;
        Vector3 forwardDirection = mainCamera.transform.forward;

        float dot = Vector3.Dot(targetDirection.normalized, forwardDirection);
        float angle = Vector3.SignedAngle(forwardDirection, targetDirection, Vector3.up);

        float normalizedHorizontalPosition = (angle + 180) / 360;
        float xPosition = Mathf.Clamp(normalizedHorizontalPosition * Screen.width, Screen.width * edgeBuffer, Screen.width * (1 - edgeBuffer));

        Vector3 screenPos;

        // If target is behind, position the waypoint at the bottom edge.
        if (dot < 0)
        {
            screenPos = new Vector3(xPosition, edgeBuffer * Screen.height, 0);
        }
        else
        {
            // If target is in front, position the waypoint directly on the target or at the left/right edge of the screen if the target is off-screen.
            screenPos = mainCamera.WorldToScreenPoint(target.transform.position);
            if (screenPos.x < 0 || screenPos.x > Screen.width)  // Off-screen
            {
                screenPos = new Vector3(xPosition, screenPos.y, 0);
            }
        }

        waypointImage.rectTransform.position = screenPos;
        waypointText.rectTransform.position = screenPos + new Vector3(0, dot < 0 ? -20 : 20, 0);  // Offset the text a bit

        // Update distance text
        float distance = Vector3.Distance(player.transform.position, target.transform.position);
        waypointText.text = distance.ToString("F2") + "m";
    }
}
