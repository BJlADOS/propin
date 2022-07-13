using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DoorController : MonoBehaviour
{
    public Tilemap TileMap;
    public Tile OpenTile;
    public Tile ClosedTile;
    public bool Closed;
    public PolygonCollider2D PhysicalCollider;
    private bool _closed;
    private void Awake()
    {
    }

    private void Update()
    {
        if (Closed != _closed)
        {
            _closed = Closed;
            if (_closed)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    public void Open()
    {
        TileMap.SetTile(TileMap.WorldToCell(transform.position), OpenTile);
        PhysicalCollider.enabled = false;
    }

    public void Close()
    {
        TileMap.SetTile(TileMap.WorldToCell(transform.position), ClosedTile);
        PhysicalCollider.enabled = true;
    }

    public void Toggle()
    {
        Closed = !Closed;
    }
}
