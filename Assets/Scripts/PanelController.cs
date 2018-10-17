using UnityEngine;
using UnityEngine.AI;


public class PanelController : MonoBehaviour
{
    Camera _camera;
    public LayerMask groundLayer;
    public NavMeshAgent playerAgent;

    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            playerAgent.SetDestination(GetPointUnderCursor());
        }
    }

    private Vector3 GetPointUnderCursor()
    {
        Vector2 screenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = _camera.ScreenToWorldPoint(screenPosition);

        RaycastHit hitPosition;

        Physics.Raycast(mouseWorldPosition, _camera.transform.forward, out hitPosition, 100, groundLayer);
        return hitPosition.point;
    }
}