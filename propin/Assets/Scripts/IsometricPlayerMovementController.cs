using UnityEngine;
using UnityEngine.EventSystems;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float MoveSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    private Vector3 newPosition;
    private Camera camera;
    private bool isMouseHold => Input.GetMouseButton(0);
    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        camera = Camera.main;
        newPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //                 Filters out clicks on ui
        if (isMouseHold && !EventSystem.current.IsPointerOverGameObject())
        {
            SetNewPosition();
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, MoveSpeed * Time.fixedDeltaTime);
        Vector2 movement = newPosition - transform.position;
        isoRenderer.SetDirection(movement);
    }

    private void SetNewPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        newPosition = mousePosition;              
    }
}
