using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class IsometricPlayerMovementController : MonoBehaviour
{

    public float MoveSpeed = 1f;
    IsometricCharacterRenderer isoRenderer;
    private Vector3 newPosition;
    private Camera camera;
    private bool isMouseHold => Input.GetMouseButton(0);
    //public Tilemap map;
    Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        camera = Camera.main;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (isMouseHold)
        {
            SetNewPosition();
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, MoveSpeed * Time.deltaTime);
        Vector2 movement = newPosition - transform.position;
        isoRenderer.SetDirection(movement);
        //Vector2 currentPos = rbody.position;
        //float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        //Vector2 inputVector = new Vector2(horizontalInput, verticalInput);
        //inputVector = Vector2.ClampMagnitude(inputVector, 1);
        //Vector2 movement = inputVector * MoveSpeed;
        //Vector2 newPos = currentPos + movement * Time.fixedDeltaTime;
        //isoRenderer.SetDirection(movement);
        //rbody.MovePosition(newPos);
    }

    private void SetNewPosition()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        //Vector3Int gridPosition = map.WorldToCell(mousePosition);

        
        newPosition = mousePosition;
        
        
    }
}
