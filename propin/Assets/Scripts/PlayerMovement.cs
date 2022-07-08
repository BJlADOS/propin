using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public Tilemap map;

    private Camera camera;
    private Rigidbody2D rb;
    private Vector3 newPosition;
    private bool isMouseHold => Input.GetMouseButton(0);

    private void Start()
    {
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        newPosition = transform.position;
    }

    private void Update()
    {
        if (isMouseHold)
        {
            SetNewPosition();
        }
        transform.position = Vector3.MoveTowards(transform.position, newPosition, MoveSpeed * Time.deltaTime);
    }

    private void SetNewPosition()
    {     
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector3Int gridPosition = map.WorldToCell(mousePosition);

        if (map.HasTile(gridPosition))
        {
            newPosition = mousePosition;
        }
        Debug.Log(newPosition);
        
    }
}
