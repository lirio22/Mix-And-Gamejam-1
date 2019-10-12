using UnityEngine;

public class VacuumRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Vector2 mousePosition;
    private Vector2 direction;

    private void Update()
    {
        FollowMouse();
    }

    private void FollowMouse()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.right = direction;
    }
}